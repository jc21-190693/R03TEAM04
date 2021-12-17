using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace NavPageSample
{
    public class SQLite
    {

    }

    /*表(スキーマ)の定義*/
    public class User
    {
        //user_id、PK
        [PrimaryKey,AutoIncrement,Column("user_id")]
        //[unique]
        public int user_id { get;  set; }

        //性別血液型など
        [NotNull]
        public DateTimeOffset date_of_birth { get; set; }
        [NotNull]
        public string  sex { get; set; }
        [NotNull]
        public string boodType { get; set; }
        [NotNull]
        public int height { get; set; }
        [NotNull]
        public  int weight { get; set; }
        [NotNull]
        public string tabako { get; set; }
        [NotNull]
        public string drinking { get; set; }
        [NotNull]
        public string taking_history { get; set; }

        //ご飯食べるタイミングなど
        [NotNull]
        public DateTimeOffset day_breakfast { get; set; }
        [NotNull]
        public DateTimeOffset clockin_time { get; set; }
        [NotNull]
        public DateTimeOffset day_lunch { get; set; }
        [NotNull]
        public DateTimeOffset end_breakfast { get; set; }
        [NotNull]
        public DateTimeOffset end_lunch { get; set; }
    }

    public class Medicine
    {
        //medicine_id、ｐｋ
        [PrimaryKey,AutoIncrement,Column("medicine_id")]
        public int medicine_id { get; set; }
        [NotNull]
        public string medicine_name { get; set; }
        public string url { get; set; }
    }

    public class Allergie
    {
        [PrimaryKey, AutoIncrement, Column("user_id")]
        public int user_id { get; set; }
        [NotNull]
        public string allergie { get; set; }
    }

    public class TakeMedicine
    {
        [PrimaryKey, AutoIncrement, Column("user_id")]
        public int user_id { get; set; }
        [PrimaryKey, AutoIncrement, Column("medicine_id")]
        public int medicine_id { get; set; }
        [NotNull]
        public string taking_history { get; set; }
        [NotNull]
        public int quantity { get; set; }
        public string side_effect { get; set; }
    }

    public class TakeTime
    {
        [PrimaryKey,AutoIncrement,Column("user_id")]
        public int use_id { get; set; }
        [PrimaryKey, AutoIncrement, Column("medicine_id")]
        public int medicine_id { get; set; }
        [NotNull]
        public DateTimeOffset medicine_time { get; set; }
    }

}
