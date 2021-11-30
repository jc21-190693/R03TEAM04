using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace App3
{
    public class Database
    {
        readonly SQLiteAsyncConnection database;

        public Database(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Person>().Wait();
        }

        public Task<List<Person>> GetPeopleAsync()
        {
            return database.Table<Person>().ToListAsync();
        }

        public Task<Person> GetNoteAsync(int id)
        {
            // Get a specific note.
            return database.Table<Person>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SavePersonAsync(Person person)
        {
            if (person.ID != 0)
            {
                // Update an existing note.
                return database.UpdateAsync(person);
            }
            else
            {
                // Save a new note.
                return database.InsertAsync(person);
            }
        }

        public Task<int> DeleteNoteAsync(Person person)
        {
            // Delete a person.
            return database.DeleteAsync(person);
        }
    }
}