using System.Threading.Tasks;
using FirstApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace FirstApp.Views
{
    public partial class NotesPage : ContentPage
    {
        private ObservableCollection<Note> notes;
        private Random rnd = new Random();
        private PageList<Note> currentPageList;
        public NotesPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            currentPageList = await App.NotesDB.GetNotesPageAsync();
            notes = new ObservableCollection<Note>(currentPageList.Items);
            collectionView.ItemsSource = notes;
            base.OnAppearing();
        }

        private async void AddButton_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(CreateNotePage));
        }

        private async void OnSelectionChenged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                var note = (Note) e.CurrentSelection.FirstOrDefault();
                await Shell.Current.GoToAsync($"{nameof(CreateNotePage)}?{nameof(CreateNotePage.ItemId)}={note.Id}");
            }
        }

        private void UpButton_Clicked(object sender, EventArgs e)
        {
            collectionView.ScrollTo(0);
        }

        private async void BrowseElements(object sender, EventArgs e)
        {
            if(currentPageList.HasNext)
            {
                currentPageList = await App.NotesDB.GetNotesPageAsync(currentPageList.CurrentPage+1, currentPageList.PageSize);
                currentPageList.Items.ForEach(i=>notes.Add(i));
            }
        }
    }
}