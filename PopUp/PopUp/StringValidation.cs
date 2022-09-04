using Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Text;

namespace PopUp
{
    public class StringValidation:Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged-= OnEntryTextChanged;
            base.OnDetachingFrom(bindable);
        }

        private void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            var text = args.NewTextValue;

            ((Entry)sender).TextColor = !text.Contains(" ") ? Color.Green : Color.Red;
        }
    }
}
