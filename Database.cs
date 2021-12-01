using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace App3
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Person>().Wait();
        }

        public Task<List<Person>> GetPeopleAsync()
        {   
            //personを取得
            return _database.Table<Person>().ToListAsync();
        }

        public Task<Person> GetPeopleAsync(int id)
        {
            // Get a specific person.
            return database.Table<Person>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SavePersonAsync(Person person)
        {   
            //
            if (person.ID != 0)
            {
                // Update an existing note.
                return database.UpdateAsync(person);
            }
            else
            {
                //personインサート
                return database.InsertAsync(person);
            }
        }
        public Task<int> DeletePeopleAsync(Person person)
        {
            //person削除.
            return database.DeleteAsync(person);
        }

    }
}