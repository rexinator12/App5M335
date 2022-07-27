using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace App5
{
    public class Game
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string PublisherName { get; set; }
        public DateTime Publishdate { get; set; }
    }
}
