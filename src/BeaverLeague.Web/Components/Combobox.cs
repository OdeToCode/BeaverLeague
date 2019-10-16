﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeaverLeague.Web.Components
{
    public class ComboboxBase<T> : ComponentBase
    {
        [Parameter]
        public T SelectedItem { get; set; }

        [Parameter]
        public IEnumerable<T> Items { get; set; } = Enumerable.Empty<T>();

        [Parameter]
        public Func<string, Func<T, bool>> ItemFilter { get; set; } = _ => _ => true;

        [Parameter]
        public string Placeholder { get; set; } = "";

        [Parameter]
        public int MaxSuggestions { get; set; } = 10;

        [Parameter]
        public RenderFragment<T>? ItemTemplate { get; set; }

        public IEnumerable<T> SuggestedItems { get; set; } = Enumerable.Empty<T>();

        public string Text { get; set; } = "";

        public void OnFocusIn(FocusEventArgs _)
        {
            UpdateSuggestedItems();
        }

        public void OnFocusOut(FocusEventArgs _)
        {
            SuggestedItems = Enumerable.Empty<T>();
        }

        public void OnChange(ChangeEventArgs e)
        {
            Text = e.Value.ToString() ?? "";
            UpdateSuggestedItems();
        }

        protected void UpdateSuggestedItems()
        {
            if (!String.IsNullOrEmpty(Text))
            {
                SuggestedItems = Items.Where(ItemFilter(Text)).Take(MaxSuggestions);
            }
            else
            {
                SuggestedItems = Items.Take(MaxSuggestions);    
            }
        }
    }
}