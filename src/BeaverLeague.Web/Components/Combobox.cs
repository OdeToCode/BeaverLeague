using BeaverLeague.Core.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable
namespace BeaverLeague.Web.Components
{
    public class ComboBoxBase<T> : InputText
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

        static Dictionary<string, T> empty = new Dictionary<string, T>();

        public void OnInput(ChangeEventArgs e)
        {
            if (e is null) throw new ArgumentNullException(nameof(e));  
            
            CurrentValueAsString = e.Value.ToString() ?? "";
            UpdateSuggestedItems();
        }

        public void UpdateSuggestedItems()
        {
            Console.WriteLine("updatesuggest " + CurrentValueAsString);
            SuggestedItems = Items.Where(i => i.Key.Contains(CurrentValueAsString ?? "", StringComparison.OrdinalIgnoreCase))
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
            CurrentValue = item.Key;
            SuggestedItems = empty;
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
        }
    }
}
#nullable restore