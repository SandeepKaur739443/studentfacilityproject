using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Database;
using Android.Database.Sqlite;

namespace StudentFacilityApp
{
    public class DBHelperClass : SQLiteOpenHelper
    {
        Context myContex;


        public static string DBName = "myDatabse.db";
        public static string tableName = "UserTable";
        public static string userId = "id";
        public static string nameFiled = "names";
        public static string email = "email";
        public static string contact = "contact";
        public static string pass = "password";

        


        //create database
        public string creatTable = "Create Table " + tableName + "(" + userId + " int, "+ nameFiled + " Text, " + email + " Text, " +
        contact + " Text, " + pass + " Text);";

        SQLiteDatabase connectionObj;

        public DBHelperClass(Context context) : base(context, name: DBName, factory: null, version: 1)
        {
            myContex = context;
            connectionObj = WritableDatabase;
        }

        public override void OnCreate(SQLiteDatabase db)
        {
            System.Console.WriteLine("My Create Table STM \n \n" + creatTable);

            db.ExecSQL(creatTable);
        }

        //insert data in database
        public void InsertValue(string value_id, string value_username, string value_email, string value_contact, string value_pass)
        {

            string insertStm = "Insert into " +
            tableName + " values (" + value_id + ", '" + value_username + "'" + "," + "'" + value_email + "'" + "," + "'" +
            value_contact + "'" + "," + "'" + value_pass + "'); ";
            Console.WriteLine(insertStm);

            System.Console.WriteLine("My SQL  Insert STM \n  \n" + insertStm);

            connectionObj.ExecSQL(insertStm);

        }
 //show data on screen
        public void SelectMydata()
        {
            String selectStm = "Select * from " + tableName;

            ICursor myresut = connectionObj.RawQuery(selectStm, null);


            //String selectStmwithId = "Select * from "+ tableName " where id="+id +"and name="+nameFiled;
            //myresut.Count >0


            while (myresut.MoveToNext())
            {

                var uId = myresut.GetString(myresut.GetColumnIndexOrThrow(userId));
                System.Console.WriteLine("ID from BD " + uId);

                var nameValue = myresut.GetString(myresut.GetColumnIndexOrThrow(nameFiled));
                System.Console.WriteLine("Name from BD " + nameValue);

                var Email = myresut.GetString(myresut.GetColumnIndexOrThrow(email));
                System.Console.WriteLine("Email from BD " + Email);


                var Contact = myresut.GetString(myresut.GetColumnIndexOrThrow(contact));
                System.Console.WriteLine("contact from BD " + contact);

                var Password = myresut.GetString(myresut.GetColumnIndexOrThrow(pass));
                System.Console.WriteLine("password from BD " + Password);

               

            }

        }

        public ICursor SelectMyId()
        {
            String selectStm = "Select ifnull(max(" + userId + "), 0) as "+ userId + " from " + tableName;
            ICursor myresut = connectionObj.RawQuery(selectStm, null);
            return myresut;
        }
        public ICursor Validate_LogIn(string email)
        {
            String selectStm = "Select * from " + tableName + " where email='" + email + "';"; 
            ICursor myresut = connectionObj.RawQuery(selectStm, null);

            return myresut;
        }
        public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
        {
            throw new NotImplementedException();
        }
    }

}

