

using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;

namespace StudentFacilityApp
{
    public class Fragment1 : Fragment
    {
        public String myName;
        public String age;
        DBHelperClass myDB;
        MyCustomAdapter CustomAdapter;
        List<UserObject> myUsersList = new List<UserObject>();
        ListView mylist;
        
        public Fragment1()
        {
            
           /*myName = name;
           age = age1;
           myUsersList = templist;*/
           
        }
        public override void OnCreate(Bundle savedInstanceState)
        {
           base.OnCreate(savedInstanceState);
           //myDB = new DBHelperClass(this);
           //Console.WriteLine("genius bht boln lg gya");
           // Create your fragment here
            
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View myView = inflater.Inflate(Resource.Layout.FFragmentLayout, container, false);
            mylist = myView.FindViewById<ListView>(Resource.Id.mylistview);

            myView.FindViewById<TextView>(Resource.Id.myNameIdl).Text = myName;
            myView.FindViewById<TextView>(Resource.Id.listID).Text = age;

            return myView;
            return inflater.Inflate(Resource.Layout.FFragmentLayout, container, false);
        }
    }


    public class Fragment2 : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            return inflater.Inflate(Resource.Layout.SFragmentLayout, container, false);

        }
    }
}