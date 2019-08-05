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

        
        //complain table
        public static string tableComplain = "ComplainTable";
        public static string complain_id = "c_id";
        public static string complain = "complaint";
        public static string comp_Date = "Complaint_date";

        



        //create database
        public string creatTable = "Create Table " + tableName + "(" + userId + " int, "+ nameFiled + " Text, " + email + " Text, " +
        contact + " Text, " + pass + " Text);";

        public string createTable = "Create Table " + tableComplain + "(" + complain_id + " int, " + complain + " Text," +email+ " Text," +comp_Date+ "Text);";

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
            db.ExecSQL(createTable);
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

        //insert complaint
        public void InsertmyComplaint(string myid, string myComplaint, string user_email, string dt)
        {
            string insertStm = "Insert into " +
           tableComplain + " values (" + myid + ", '" + myComplaint + "'" + "," + "'" + user_email + "'" + "," + "'" + dt + "'); ";
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
        //complain id starts from here
        public ICursor SelectComplainMyId()
        {
            String selectStm = "Select ifnull(max(" + complain_id + "), 0) as " + complain_id + " from " + tableComplain;
            ICursor myresut = connectionObj.RawQuery(selectStm, null);
            return myresut;
        }
        //update complain
        public ICursor SelectMyDataToUpdate(string id,string complaintxt)
        {
            String myData = "Update " + tableComplain + " set " + complain + " = '" + complaintxt + "' where c_id = " + id + ";";
            ICursor record = connectionObj.RawQuery(myData, null);

            record.MoveToFirst();
            Console.WriteLine(myData);
            System.Console.WriteLine("My SQL  update STM \n  \n" + record);

            //var complaints = record.GetString(record.GetColumnIndexOrThrow("complain"));
           //System.Console.WriteLine("Name from complain " + complaints);
            return record;
        }

        public void Delete_data(string myid)
        {
            string dltStm = "Delete from " + tableComplain + " where c_id=" + myid + ";";
            Console.WriteLine(dltStm);
            System.Console.WriteLine("My SQL  delete STM \n  \n" + dltStm);
            connectionObj.ExecSQL(dltStm);
        }
        //selct complain
        public ICursor SelectComplaintList()
        {
            String selectStm = "Select * from " + tableComplain;

            ICursor myresut = connectionObj.RawQuery(selectStm, null);
            return myresut;
        }


        public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
        {
            throw new NotImplementedException();
        }
    }

}

