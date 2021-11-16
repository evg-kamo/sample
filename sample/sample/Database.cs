using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace sample
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            // 非同期SQLite.Net API使用
            _database = new SQLiteAsyncConnection(dbPath);

            // Person.csに記載したテーブル作成
            _database.CreateTableAsync<Person>().Wait();
        }

        public Task<List<Person>> GetPeopleAsync()
        {
            // DBに登録されたデータを表示する
            // 非同期的に列挙する
            return _database.Table<Person>().ToListAsync();
        }

        public Task<int> SavePersonAsync(Person person)
        {
            // テーブルに新しいインスタンスを挿入する
            return _database.InsertAsync(person);
        }
    }
}