using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using SQLite;

namespace App5
{
    public class Database
    {
        private readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Game>();
        }

        public Task<List<Game>> GetPeopleAsync()
        {
            return _database.Table<Game>().OrderByDescending(Game=>Game.Id).ToListAsync();
        }

        public Task<int> SavePersonAsync(Game game)
        {
            return _database.InsertAsync(game);
        }
    }
}
