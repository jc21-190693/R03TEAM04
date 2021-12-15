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
        //user_id、PK
        [PrimaryKey,AutoIncrement,Column("user_id")]
        [NotNull]
        //[unique]
        public int u_id { get;  set; }

        //性別血液型など
        [NotNull]
        public DateTime date_of_birth { get; set; }
        [NotNull]
        public string  sex { get; set; }
        [NotNull]
        public string BloodType { get; set; }
        [NotNull]
        public string tabako { get; set; }
        [NotNull]
        public string Drinking { get; set; }
        [NotNull]
        public string taking_history { get; set; }

        //ご飯食べるタイミングなど
        [NotNull]
        public DateTime day_breakfast { get; set; }
        [NotNull]
        public DateTime Clockin_time { get; set; }
        [NotNull]
        public DateTime day_lunch { get; set; }
        [NotNull]
        public DateTime end_breakfast { get; set; }
        [NotNull]
        public DateTime end_lunch { get; set; }
    }

    [Table("mst_medicine")]
    public class Medicine
    {
        //medicine_id、ｐｋ
        [PrimaryKey,AutoIncrement,Column("medicine_id")]
        [NotNull]
        public int medicine_id { get; set; }
        [NotNull]
        public string medicine_name { get; set; }
        public string url { get; set; }
    }

    [Table("mst_Allergie")]
    public class Allergie
    {
        [PrimaryKey, AutoIncrement, Column("user_id")]
        [NotNull]
        public int u_id { get; set; }
        [NotNull]
        public string allergie { get; set; }
    }

    [Table("mst_take_medicine")]
    public class TakeMedicine
    {
        [PrimaryKey, AutoIncrement, Column("user_id")]
        [NotNull]
        public int u_id { get; set; }
        [PrimaryKey, AutoIncrement, Column("medicine_id")]
        [NotNull]
        public int medicine_id { get; set; }
        [NotNull]
        public string taking_history { get; set; }
        [NotNull]
        public int quantity { get; set; }
        public string side_effect { get; set; }
    }
}
