using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Database.Sqlite;
using Android.Database;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace RestaurantApp
{
    public class DBHelper : SQLiteOpenHelper
    {
        private static string _DatabaseName = "mydatabase1.db";
        private const string TableName = "user";
        private const string ColumnName = "username";
        private const string ColumnEmail = "email";
        private const string ColumnPassword = "password";
        private const string ColumnContact = "contact";

        public const string CreateUserTableQuery = "CREATE TABLE " +
       TableName + " ( " + ColumnName + " TEXT," + ColumnEmail + " TEXT," + ColumnPassword + " TEXT,"
           + ColumnContact + " TEXT)";  //Step: 1 - 4


        //Review Table
        private const string RTableName = "Review";
        private const string UserName = "username";
        private const string Restname = "restname";
        private const string Review1 = "review";
        private const string rate = "rating";


        public const string CreateUserTableQuery1 = "CREATE TABLE " +
       RTableName + " ( " + UserName + " TEXT," + Restname + " TEXT," + Review1 + " TEXT," + rate + " TEXT)";

        //Restaurant Table
        private const string ResTableName = "Restaurant";
        private const string rName = "rname";
        private const string rPlace = "rplace";
        private const string rType = "rtype";
        private const string rImage = "rimage";


        public const string CreateUserTableQuery2 = "CREATE TABLE " +
       ResTableName + " ( " + rName + " TEXT," + rPlace + " TEXT," + rType + " TEXT," + rImage + " INT)";
       
        //Favourite Table
        private const string RFavTableName = "Favourite";
        private const string UsrName = "usrname";
        private const string rsName = "rsname";



        public const string CreateUserTableQuery3 = "CREATE TABLE " +
       RFavTableName + " ( " + rsName + " TEXT," + UsrName + " TEXT)";


        SQLiteDatabase myDBObj; // Step: 1 - 5
        readonly Context myContext; // Step: 1 - 6

        public DBHelper(Context context) : base(context, name: _DatabaseName, factory: null, version: 1) //Step 2;
        {
            myContext = context;
            myDBObj = WritableDatabase;
            myDBObj = ReadableDatabase;// Step:3 create a DB objects
        }
        public override void OnCreate(SQLiteDatabase db)
        {
            Console.WriteLine("Table1");
            db.ExecSQL(CreateUserTableQuery);
            Console.WriteLine("Table2");
            db.ExecSQL(CreateUserTableQuery1);
            db.ExecSQL(CreateUserTableQuery2);
            Console.WriteLine("Table3");
            db.ExecSQL(CreateUserTableQuery3);
            /*InsertUser("test", "abc@gmail.com", "test", "134523");


            InsertRestaurant("Richmond", "Richmond", "Bar and Grill");
            InsertRestaurant("Edulis", "Etobicoke", "Sweets and Bakery");
            InsertRestaurant("Alo", "Queen Street", "Salad and Subway");
            InsertRestaurant("Cafe", "King Street", "Salad and Green");
            InsertRestaurant("Canoe", "North York", "Chineese");

            InsertReview("abc@gmail.com", "Edulis", "This is nice Restaurant","3");
            InsertReview("abc@gmail.com", "Cafe", "I like Sugar", "3.5");
            InsertReview("abc@gmail.com", "Richmond", "This is good place", "4");
            InsertFavourite("abc@gmail.com", "Edulis");
            InsertFavourite("abc@gmail.com", "Alo");
            */
        }
        //insert values user/password table
        public void InsertUser(string nameValue, string emailValue, string passwordValue, string contactValue)
        {
            //insert into users value( name, email,password,age)


            String insertSQL = "insert into " + TableName + " values (" + "'" + nameValue + "'" + "," + "'" + emailValue + "'" + "," + "'" + passwordValue + "'" + "," + "'" + contactValue + "'" + ");";

            System.Console.WriteLine("Name: " + nameValue + "\nEmail :" + emailValue + "\nPassword:" + passwordValue + "\nContact:" + contactValue);
            myDBObj.ExecSQL(insertSQL);

        }
        //insert values review table

        public void InsertReview(string username, string restname, string review,string ratee)
        {
         


            String insertSQL1 = "insert into " + RTableName + " values (" + "'" + username + "'" + "," + "'" + restname + "'" + "," + "'" + review + "'" + ","+ "'" + ratee + "'" + ");";

            System.Console.WriteLine("UserName: " + username + "\nRestaurantName :" + restname + "\nReview" + review + "\nRating" + ratee);
            myDBObj.ExecSQL(insertSQL1);

        }
        // insert values for Favourite table 
        public void InsertFavourite(string username, string restname)
        {
            //insert into users value( name, email,password,age)


            String insertSQL1 = "insert into " + RFavTableName + " values (" + "'" + username + "'" + "," + "'" + restname + "'" + ");";

            System.Console.WriteLine("UserName: " + username + "\nRestaurantName :" + restname);
            myDBObj.ExecSQL(insertSQL1);

        }
        // insert values for restaurant table 
        public void InsertRestaurant(string name, string place, string type,int image)
        {



            String insertSQL2 = "insert into " + ResTableName + " values (" + "'" + name + "'" + "," + "'" + place + "'" + "," + "'" + type + "'" + ","+ image +");";

            System.Console.WriteLine("RestarurantName: " + name + "\nRestaurantPlace :" + place + "\nRestaurantType" + type + "\nRestaurantImage" + image);
            myDBObj.ExecSQL(insertSQL2);

        }
        //for user login table
        public bool SelectMyValues(String userName, String passWord)
        {

            String sqlQuery = "Select * from " + TableName + " where " + ColumnName + " = " + "'" + userName + "'" + " and " + ColumnPassword + " = " + "'" + passWord + "'" + ";";

            ICursor result = myDBObj.RawQuery(sqlQuery, null);
            if (result.Count > 0)
            {
                

                return true;
            }
            else
            {
                return false;
            }
        }
        //for review table
        public bool SelectMyValues1(String username)
        {

            String sqlQuery1 = "Select * from " + RTableName + " where " + UserName + " = " + "'" + username + "'" + ";";

            ICursor result1 = myDBObj.RawQuery(sqlQuery1, null);
            if (result1.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }



        }
        //Delete reviews
        public void Deletereview(string user, string rname)
        {
            string dltStm = "Delete from " + RTableName + " where " + UserName + "=" + user + "and" + Restname + "=" + rname + ";";
            Console.WriteLine(dltStm);
            System.Console.WriteLine("My SQL  delete STM \n  \n" + dltStm);
            myDBObj.ExecSQL(dltStm);
        }
        //show reviews
        public List<string> GetReviews()
        {

            List<string> resultr = new List<string>();
            string Query = "select " + UserName + "," + Restname + "," + Review1 + "," + rate + " from " + RTableName + ";";
            System.Console.WriteLine("My SQL  select STM \n  \n" + Query);

            try
            {
                ICursor cursor = myDBObj.RawQuery(Query, new string[] { });

                while (cursor.MoveToNext())
                {
                    var uname = cursor.GetString(cursor.GetColumnIndexOrThrow(UserName));
                    var r = cursor.GetString(cursor.GetColumnIndexOrThrow(Restname));
                    var rr = cursor.GetString(cursor.GetColumnIndexOrThrow(Review1));
                    resultr.Add(uname);
                    resultr.Add(r);
                    resultr.Add(rr);

                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return resultr;

        }


        public ICursor ResViewdata()
        {
            // SQLiteDatabase db = this.GetReadableDatabase();
            String sqlQuery = "Select * from " + ResTableName + ";";
            ICursor resultr = myDBObj.RawQuery(sqlQuery, null);

            return resultr;
        }
        public ICursor FavViewdata()
        {
            // SQLiteDatabase db = this.GetReadableDatabase();
            String sqlQuery = "Select * from " + RFavTableName + ";";
            ICursor resultr = myDBObj.RawQuery(sqlQuery, null);

            return resultr;
        }
        public ICursor ReviewViewdata()
        {
            // SQLiteDatabase db = this.GetReadableDatabase();
            String sqlQuery = "Select * from " + RTableName + ";";
            ICursor resultr = myDBObj.RawQuery(sqlQuery, null);

            return resultr;
        }

        private SQLiteDatabase GetReadableDatabase()
        {
            throw new NotImplementedException();
        }

        public ICursor Update(string userName, string passWord)
        {
            String sqlQuery = "Select * from " + TableName + " where " + ColumnName + " = " + "'" + userName + "'" + " and " + ColumnPassword + " = " + "'" + passWord + "'" + ";";
            ICursor result = myDBObj.RawQuery(sqlQuery, null);
            result.MoveToNext();


            var userDB = result.GetString(result.GetColumnIndexOrThrow(ColumnName));
            var emailDB = result.GetString(result.GetColumnIndexOrThrow(ColumnEmail));
            var passDB = result.GetString(result.GetColumnIndexOrThrow(ColumnPassword));
            var contactDB = result.GetString(result.GetColumnIndexOrThrow(ColumnContact));

            return result;


        }

        public void UpdateMyValues(String un, String pw, String email, String contact)
        {
            String sqlupQuery = "Update " + TableName + " Set " + ColumnName + "='" + un + "', " + ColumnPassword + "=" + "'" + pw + "', " + ColumnEmail + "='" + email + "', " + ColumnContact + "=' " + contact + "';";
            System.Console.WriteLine("Update SQL " + sqlupQuery);
            myDBObj.ExecSQL(sqlupQuery);
        }


        public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
        {
            throw new NotImplementedException();
        }
    }
}