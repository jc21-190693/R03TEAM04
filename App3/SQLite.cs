using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace NavPageSample
{
    public class SQLite
    {

    }
    [Table("mst_User")]
    public class User
    {
        [PrimaryKey,AutoIncrement,Column("user_id")]
        public int u_id { get;  set; }
        [MaxLength(5)]
        public DateTime date_of_birth { get; set; }
        public String  sex { get; set; }
        public String BloodType { get; set; }
        public String tabako { get; set; }
        public String Drinking { get; set; }
        public String taking_history { get; set; }
        public DateTime day_breakfast { get; set; }
        public DateTime Clockin_time { get; set; }
        public DateTime day_lunch { get; set; }
        public DateTime end_breakfast { get; set; }
        public DateTime end_lunch { get; set; }
    }
}
