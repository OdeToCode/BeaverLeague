using AngleSharp.Html.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace BeaverLeague.Tests.Helpers
{
    public static class HttpClientExtensions
    {

        public static Task<HttpResponseMessage> SendFormAsync(
            this HttpClient client, IHtmlDocument content, string formDataPrefix, object formData)
        {
            if (content is null) throw new ArgumentNullException(nameof(content));
            if (formData is null) throw new ArgumentNullException(nameof(formData));

            var form = (IHtmlFormElement)content.QuerySelector("#form");
            Assert.NotNull(form);

            var submitButton = (IHtmlButtonElement)content.QuerySelector("#submit");
            Assert.NotNull(submitButton);

            var formValues = formData.GetType()
                                     .GetProperties()
                                     .ToDictionary(p => $"{formDataPrefix}.{p.Name}", p => p.GetValue(formData)?.ToString() ?? "");

            return client.SendFormAsync(form, submitButton, formValues);
        }

        public static Task<HttpResponseMessage> SendFormAsync(
            this HttpClient client, IHtmlDocument content, IEnumerable<KeyValuePair<string, string>> formValues)
        {
            if (content is null) throw new ArgumentNullException(nameof(content));
            
            var form = (IHtmlFormElement)content.QuerySelector("#form");
            Assert.NotNull(form);

            var submitButton = (IHtmlButtonElement)content.QuerySelector("#submit");
            Assert.NotNull(submitButton);

            return client.SendFormAsync(form, submitButton, formValues);
        }

        public static Task<HttpResponseMessage> SendFormAsync(
            this HttpClient client, IHtmlDocument content)
        {
            if (content is null) throw new ArgumentNullException(nameof(content));

            var form = (IHtmlFormElement)content.QuerySelector("#form");
            Assert.NotNull(form);

            var submitButton = (IHtmlButtonElement)content.QuerySelector("#submit");
            Assert.NotNull(submitButton);

            return client.SendFormAsync(form, submitButton, new Dictionary<string, string>());
        }

        public static Task<HttpResponseMessage> SendFormAsync(
            this HttpClient client,
            IHtmlFormElement form,
            IHtmlElement submitButton)
        {
            return client.SendFormAsync(form, submitButton, new Dictionary<string, string>());
        }

        public static Task<HttpResponseMessage> SendAsync(
            this HttpClient client,
            IHtmlFormElement form,
            IEnumerable<KeyValuePair<string, string>> formValues)
        {
            if (form is null) throw new ArgumentNullException(nameof(form));

            var submitElement = Assert.Single(form.QuerySelectorAll("[type=submit]"));
            var submitButton = Assert.IsAssignableFrom<IHtmlElement>(submitElement);

            return client.SendFormAsync(form, submitButton, formValues);
        }

        public static Task<HttpResponseMessage> SendFormAsync(
            this HttpClient client,
            IHtmlFormElement form,
            IHtmlElement submitButton,
            IEnumerable<KeyValuePair<string, string>> formValues)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (form is null) throw new ArgumentNullException(nameof(form));
            if (submitButton is null) throw new ArgumentNullException(nameof(submitButton));
            if (formValues is null) throw new ArgumentNullException(nameof(formValues));

            foreach (var kvp in formValues)
            {
                var element = form[kvp.Key];
                switch (element)
                {
                    case IHtmlInputElement input:
                        input.Value = kvp.Value;
                        break;

                    case IHtmlSelectElement select:
                        select.Value = kvp.Value;
                        break;
                }
            }

            Assert.True(form.CheckValidity(), "Form contains invalid data");
            var submit = form.GetSubmission(submitButton);

            var target = (Uri)submit.Target;
            if (submitButton.HasAttribute("formaction"))
            {
                var formaction = submitButton.GetAttribute("formaction");
                target = new Uri(formaction, UriKind.Relative);
            }

#pragma warning disable CA2000 // Dispose objects before losing scope
            var submision = new HttpRequestMessage(new HttpMethod(submit.Method.ToString()), target)
            {
                Content = new StreamContent(submit.Body)
            };
#pragma warning restore CA2000 // Dispose objects before losing scope

            foreach (var header in submit.Headers)
            {
                submision.Headers.TryAddWithoutValidation(header.Key, header.Value);
                submision.Content.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }

            return client.SendAsync(submision);
        }
    }
}
