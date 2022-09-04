using Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Text;

namespace PopUp
{
    public class NumericValidationBehavior:Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(bindable);
        }

        private void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            var isValid = double.TryParse(args.NewTextValue, out var result);

            ((Entry)sender).TextColor = isValid ? Color.Green : Color.Red;
        }
    }
}
