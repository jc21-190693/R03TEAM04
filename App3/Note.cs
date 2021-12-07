using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace App3
{
    public class Note
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
    }
}
