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

        public Task<List<User>> GetUsersAsync()
        {   
            //userを取得
            return _database.Table<User>().ToListAsync();
        }

        public Task<User> GetUserAsync(int id)
        {
            // Get a specific user.                   //テーブルで定義したidなど
            return _database.Table<User>().Where(i => i.user_id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveUserAsync(User user)
        {   
            //
            if (user.user_id != 0)
            {
                // Update an existing user.
                return _database.UpdateAsync(user);
            }
            else
            {
                //userインサート
                return _database.InsertAsync(user);
            }
        }
        public Task<int> DeleteUserAsync(User user)
        {
            //user削除.
            return _database.DeleteAsync(user);
        }

    }
}