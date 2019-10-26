using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable
namespace BeaverLeague.Web.Components
{
    public class ComboBoxBase<T> : InputBase<T>
    {
        [Parameter]
        public string Placeholder { get; set; } = "";

        [Parameter]
        public Dictionary<string, T> Items { get; set; }

        [Parameter]
        public RenderFragment<T> ItemTemplate { get; set; }

        [Parameter]
        public int MaxSuggestions { get; set; } = 7;

        public IEnumerable<KeyValuePair<string, T>> SuggestedItems { get; set; } = empty;

        public string Text { get; set; } = "";

        static Dictionary<string, T> empty = new Dictionary<string, T>();

        public void OnInput(ChangeEventArgs e)
        {
            if (e is null) throw new ArgumentNullException(nameof(e));

            Text = e.Value.ToString() ?? "";
            UpdateSuggestedItems();
        }

        public void UpdateSuggestedItems()
        {
            SuggestedItems = Items.Where(i => i.Key.Contains(Text, StringComparison.OrdinalIgnoreCase))
                                  .Take(MaxSuggestions);
        }

        public void OnFocusIn(FocusEventArgs _)
        {
            UpdateSuggestedItems();
        }

        public void OnFocusOut(FocusEventArgs _)
        {
            SuggestedItems = empty;
        }

        public void OnSelectItem(KeyValuePair<string, T> item)
        {
            Text = item.Key;
            SuggestedItems = empty;
        }

        protected override bool TryParseValueFromString(
            string value, out T result, out string validationErrorMessage)
        {
            if (Items.ContainsKey(value))
            {
                result = Items[value];
                validationErrorMessage = null;
                return true;
            }
            else
            {
                result = default(T);
                validationErrorMessage = "Couldn't find that value";
                return false;
            }
        }
    }
}
#nullable restore