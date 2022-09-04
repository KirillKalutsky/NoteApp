using FirstApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirstApp.Views
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class CreateNotePage : ContentPage
    {
        public string ItemId
        {
            set
            {
                LoadNote(value);
            }
        }
        public CreateNotePage()
        {
            InitializeComponent();

            BindingContext = new Note();
        }

        private async void LoadNote(string noteId)
        {
            try
            {
                var id = int.Parse(noteId);
                var note = await App.NotesDB.GetNoteByIdAsync(id);
                BindingContext = note;
            }
            catch { }
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            note.Date = DateTime.UtcNow;
            if (!string.IsNullOrWhiteSpace(note.Text))
            {
                await App.NotesDB.InsertOrCteateNoteAsync(note);
            }
            await Shell.Current.GoToAsync("..");
        }
        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            await App.NotesDB.DeleteNoteAsync(note);
            await Shell.Current.GoToAsync("..");
        }

    }
}