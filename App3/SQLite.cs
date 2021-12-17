using System;
using System.Collections;
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
        //User_id、PK
        [PrimaryKey,AutoIncrement,Column("User_id")]
        //[unique]
        public int User_id { get;  set; }

        //性別血液型など
        [NotNull]
        public DateTime Date_of_birth { get; set; }
        [NotNull]
        public string  Sex { get; set; }
        [NotNull]
        public string BoodType { get; set; }
        [NotNull]
        public int Height { get; set; }
        [NotNull]
        public  int Weight { get; set; }
        [NotNull]
        public string Tabako { get; set; }
        [NotNull]
        public string Drinking { get; set; }
        [NotNull]
        public string Taking_history { get; set; }

        //ご飯食べるタイミングなど
        [NotNull]
        public DateTime Day_breakfast { get; set; }
        [NotNull]
        public DateTime Clockin_time { get; set; }
        [NotNull]
        public DateTime Day_lunch { get; set; }
        [NotNull]
        public DateTime End_breakfast { get; set; }
        [NotNull]
        public DateTime End_lunch { get; set; }
    }

    public class Medicine
    {
        //Medicine_id、ｐｋ
        [PrimaryKey,AutoIncrement,Column("Medicine_id")]
        public int Medicine_id { get; set; }
        [NotNull]
        public string Medicine_name { get; set; }
        public string Url { get; set; }
    }

    public class Allergie
    {
        [PrimaryKey, AutoIncrement, Column("User_id")]
        public int User_id { get; set; }
        [NotNull]
        public string Allergie_id{ get; set; }
    }

    public class TakeMedicine
    {
        [PrimaryKey, AutoIncrement, Column("User_id")]
        public int User_id { get; set; }
        [PrimaryKey, AutoIncrement, Column("Medicine_id")]
        public int Medicine_id { get; set; }
        [NotNull]
        public string Taking_history { get; set; }
        [NotNull]
        public int Quantity { get; set; }
        public string Side_effect { get; set; }
    }

    public class TakeTime
    {
        [PrimaryKey,AutoIncrement,Column("User_id")]
        public int User_id { get; set; }
        [PrimaryKey, AutoIncrement, Column("Medicine_id")]
        public int Medicine_id { get; set; }
        [NotNull]
        public DateTime Medicine_time { get; set; }
    }

}
