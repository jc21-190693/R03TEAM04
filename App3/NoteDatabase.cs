using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using NavPageSample;

//データベースアクセスのクラス
namespace NavPageSample
{
    public class NoteDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public NoteDatabase(string dbPath)
        {
            //DBの作成コネクションクラスコンストラクタのパスを渡す
            _database = new SQLiteAsyncConnection(dbPath);
            //空のＤＢを作成
            _database.CreateTableAsync<Note>().Wait();
        }


        //Noteをリストに
        public Task<List<Note>> GetNotesAsync()
        {
            return _database.Table<Note>().ToListAsync();
        }

        //
        public Task<Note> GetNoteAsync(int id)
        {
            return _database.Table<Note>()
                   .Where(i => i.ID == id)
                   .FirstOrDefaultAsync();
        }

        public Task<int> SaveNoteAsync(Note note)
        {
            if (note.ID != 0)
            {
                return _database.UpdateAsync(note);
            }
            else
            {
                return _database.InsertAsync(note);
            }
        }

        public Task<int> DeleteNoteAsync(Note note)
        {
            return _database.DeleteAsync(note);
        }
    }
}
