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
        protected override bool TryParseValueFromString(
            string value, out T result, out string validationErrorMessage)
        {
            throw new NotImplementedException();
        }
    }


    //public class ComboboxBase<T> : InputBase<T> 
    //{
    //    [Parameter]
    //    public T SelectedItem { get; set; }

    //    [Parameter]
    //    public IEnumerable<T> Items { get; set; } = Enumerable.Empty<T>();

    //    [Parameter]
    //    public Func<string, Func<T, bool>> ItemFilter { get; set; } = _ => _ => true;

    //    [Parameter]
    //    public string Placeholder { get; set; } = "";

    //    [Parameter]
    //    public int MaxSuggestions { get; set; } = 10;

    //    [Parameter]
    //    public RenderFragment<T> ItemTemplate { get; set; }

    //    [Parameter]
    //    public Func<T, string> SelectedItemFormat { get; set; } = _ => "";

    //    public IEnumerable<T> SuggestedItems { get; set; } = Enumerable.Empty<T>();

    //    public string Text { get; set; } = "";

    //    public void OnSelectItem(T item)
    //    {
    //        SelectedItem = item;
    //        Text = SelectedItemFormat(item);
    //        SuggestedItems = Enumerable.Empty<T>();
    //    }

    //    public void OnFocusIn(FocusEventArgs _)
    //    {
    //        UpdateSuggestedItems();
    //    }

    //    public void OnFocusOut(FocusEventArgs _)
    //    {
    //        SuggestedItems = Enumerable.Empty<T>();
    //    }

    //    public void OnChange(ChangeEventArgs e)
    //    {
    //        if (e is null) throw new ArgumentNullException(nameof(e));

    //        Text = e.Value.ToString() ?? "";
    //        UpdateSuggestedItems();
    //    }

    //    protected void UpdateSuggestedItems()
    //    {
    //        if (!String.IsNullOrEmpty(Text))
    //        {
    //            SuggestedItems = Items.Where(ItemFilter(Text)).Take(MaxSuggestions);
    //        }
    //        else
    //        {
    //            SuggestedItems = Items.Take(MaxSuggestions);    
    //        }
    //    }

    //    protected override bool TryParseValueFromString(string value, out T result, out string validationErrorMessage)
    //    {
    //        if (SelectedItemFormat(SelectedItem).Equals(value, StringComparison.OrdinalIgnoreCase))
    //        {
    //            result = SelectedItem;
    //            validationErrorMessage = null;
    //            return true;
    //        }
    //        else
    //        {
    //            foreach (var item in Items)
    //            {
    //                if (SelectedItemFormat(item).Equals(value, StringComparison.OrdinalIgnoreCase))
    //                {
    //                    SelectedItem = item;
    //                    result = SelectedItem;
    //                    validationErrorMessage = null;
    //                    return true;
    //                }
    //            }
    //        }
    //        result = default(T);
    //        validationErrorMessage = "Could not find golfer name";
    //        return false;
    //    }
    //}
}
#nullable restore