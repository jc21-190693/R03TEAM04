using System.Collections.Generic;
using System.Threading.Tasks;
using System.Collections;
using SQLite;

namespace NavPageSample
{
    public class Database

        //SQLiteDBへのアクセスクラス
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            //DBパスを渡して、
            _database = new SQLiteAsyncConnection(dbPath);
            //パス.create_tableでUSERテーブルを作るメソッド
            _database.CreateTableAsync<User>().Wait();
        }

        //USERテーブルからデータを取得し、リストにするメソッド
        public Task<List<User>>GetUsersAsync()
        {   
            return _database.Table<User>().ToListAsync();
        }

        //DBパスを渡して、
        public Task<User> GetUserAsync(int id)
        {
            return _database.Table<User>().Where(i => i.User_id == id).FirstOrDefaultAsync();
        }

        //ユーザテーブルにデータを保存するメソッド
        public Task<int> SaveUserAsync(User user)
        {   
            //ユーザIDっでどっちのメソッドにするか判別
            if (user.User_id != 0)
            {
                //USE_IDがあったら更新.
                return _database.UpdateAsync(user);
            }
            else
            {
                //なかったらuserインサート
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