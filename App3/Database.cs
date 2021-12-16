using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace NavPageSample
{
    public class Database

        //SQLiteDBへのアクセスクラス
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<User>().Wait();
        }

        public Task<List<User>> GetUserAsync()
        {   
            //personを取得
            return _database.Table<User>().ToListAsync();
        }

        public Task<User> GetUserAsync(int id)
        {
            // Get a specific person.                   //テーブルで定義したidなど
            return _database.Table<User>().Where(i => i.user_id == id).FirstOrDefaultAsync();
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