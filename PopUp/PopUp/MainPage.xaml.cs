using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PopUp
{
    public partial class MainPage : ContentPage
    {
        public List<Language> Languages {get;set;}
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            Languages = new List<Language>
            {
                new Language
                {
                    Name ="Python",
                    Description="сделано пидорасами для пидорасов",
                    Image="https://www.freeiconspng.com/uploads/c-logo-icon-18.png"
                },
                new Language
                {
                    Name="c#",
                    Description="yes",
                    Image="https://www.freeiconspng.com/uploads/c-logo-icon-18.png"
                }
            };

            BindingContext = this;

            base.OnAppearing();
        }

        private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var language = e.CurrentSelection.FirstOrDefault() as Language;

            await DisplayAlert(language.Name, language.Description, "Ok");
        }
    }
}
