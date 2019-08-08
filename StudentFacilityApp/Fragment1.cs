using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;


namespace StudentFacilityApp
{


    public class Fragment1 : Android.Support.V4.App.Fragment
    {
        public String user1;
        Spinner RestaurantName;
        EditText reviews;
        TextView user;
        Button reviewBtn;
        Button reviewshowBtn;

        Android.Database.ICursor i;

        List<string> rsname = new List<string>();
        readonly Activity localContext;

        string[] movieArray = { "A-Moive", "B-Moive",
                "C-Moive", "D-Moive", "E-Moive", "F - Moive", "G  - Moive", "H  - Moive", "I  - Moive"};

        private object p;
        DBHelperClass myDB;

        public String myName;
        public Activity myContext;

        public Fragment1( Activity context)
        {
          //  myName = name;
            myContext = context;
        }
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
           
            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment

            View myView = inflater.Inflate(Resource.Layout.FFragmentLayout, container, false);
            /* 
             ListView myList = myView.FindViewById<ListView>(Resource.Id.listID3);

             Console.WriteLine("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");

             DBHelperClass obj = new DBHelperClass(localContext);
             i = obj.Selectcomplain();
             while (i.MoveToNext())
             {
                 var a = i.GetString(i.GetColumnIndexOrThrow("complaint"));
                 rsname.Add(a);
             }
             Android.App.AlertDialog.Builder alert = new Android.App.AlertDialog.Builder(localContext);
             myList.Adapter = new ArrayAdapter(localContext, Android.Resource.Layout.SimpleListItem1, rsname);
               */
            return myView;
          
                //return base.OnCreateView(inflater, container, savedInstanceState);
            }
        }
    }
