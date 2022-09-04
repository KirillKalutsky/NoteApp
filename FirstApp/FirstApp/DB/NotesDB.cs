using FirstApp.Models;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Linq;

namespace FirstApp.DB
{
    public class NotesDB
    {
        private readonly SQLiteConnection _connection;
        public NotesDB(string connectionString)
        {
            _connection = new SQLiteConnection(connectionString);

            _connection.CreateTable<Note>();
        }

        public async Task<PageList<Note>> GetNotesPageAsync(int pageNumber = 1, int pageSize = 10)
        {
            return new PageList<Note>(_connection.Table<Note>().OrderBy(note=>note.Date).ToList(), pageNumber, pageSize);
        }

        public async Task<Note> GetNoteByIdAsync(int id)
        {
            return _connection.Table<Note>().Where(x => x.Id == id).FirstOrDefault();
        }

        public async Task<int> InsertOrCteateNoteAsync(Note note)
        {
            if(note.Id==0)
                return _connection.Insert(note);

            return _connection.Update(note);
        }

        public async Task<int> DeleteNoteAsync(Note note)
        {
            return _connection.Delete(note);
        }
    }
}
