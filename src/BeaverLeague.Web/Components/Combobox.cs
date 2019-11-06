using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

#nullable disable
namespace BeaverLeague.Web.Components
{
    public class ComboBoxBase<T> : ComponentBase
    {
        [CascadingParameter] 
        EditContext EditContext { get; set; }

        [Parameter]
        public string Placeholder { get; set; } = "";

        [Parameter]
        public Dictionary<string, T> Items { get; set; }

        [Parameter]
        public RenderFragment<T> ItemTemplate { get; set; }

        [Parameter]
        public int MaxSuggestions { get; set; } = 5;

        [Parameter] 
        public T Value { get; set; }
        
        [Parameter] 
        public EventCallback<T> ValueChanged { get; set; }

        [Parameter] 
        public Expression<Func<T>> ValueExpression { get; set; }

        public FieldIdentifier FieldIdentifier { get; set; }

        public string ValueAsString { get; set; }

        public IEnumerable<KeyValuePair<string, T>> SuggestedItems { get; set; } = empty;

        static Dictionary<string, T> empty = new Dictionary<string, T>();

        public void OnInput(ChangeEventArgs e)
        {
            if (e is null) throw new ArgumentNullException(nameof(e));

            Console.WriteLine($"On input {e.Value}");

            var text = e.Value.ToString() ?? "";
            if (Items.ContainsKey(text))
            {
                OnSelectItem(text);
            }
            else 
            {
                Value = default(T);
                ValueAsString = e.Value.ToString() ?? "";
                UpdateSuggestedItems();
            }
        }

        public void UpdateSuggestedItems()
        {
            SuggestedItems = Items.Where(i => i.Key.Contains(ValueAsString ?? "", StringComparison.OrdinalIgnoreCase))
                                  .Take(MaxSuggestions);
            Console.WriteLine($"Select items: {ValueAsString}:{SuggestedItems.Count()}");
        }

        public void OnFocusIn(FocusEventArgs _)
        {
            UpdateSuggestedItems();
        }

        public void OnFocusOut(FocusEventArgs _)
        {
            SuggestedItems = empty;
        }

        public void OnSelectItem(string key)
        {
            if (Items.ContainsKey(key))
            {
                Value = Items[key];
                ValueAsString = key;
                SuggestedItems = empty;
                ValueChanged.InvokeAsync(Value);
            }
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            FieldIdentifier = FieldIdentifier.Create(ValueExpression);
        }
    }
}
#nullable restore