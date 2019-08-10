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
        TextView complains;
        Android.Database.ICursor i;
        ArrayAdapter myAdapterarray;
        List<string> rsname = new List<string>();

        DBHelperClass myDB;

        public String myName;
        public Activity myContext;

        public Fragment1( Activity context)
        {
          
            myContext = context;
        }
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
           
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
          
              DBHelperClass myDB = new DBHelperClass(this.Context);
              myDB.Selectcomplain();
              i = myDB.Selectcomplain();
              while (i.MoveToNext())
              {
                  string a = i.GetString(i.GetColumnIndexOrThrow("complaint"));
                Console.WriteLine(a);
                  rsname.Add(a);
              }
            View myView = inflater.Inflate(Resource.Layout.FFragmentLayout, container, false);
            ListView myList = myView.FindViewById<ListView>(Resource.Id.listID);
            myView.FindViewById<TextView>(Resource.Id.myNameIdl).Text = myName;

            myList.Adapter = new ArrayAdapter(myContext, Android.Resource.Layout.SimpleListItem1, rsname);
            return myView;
          
               
            }
        }
    }
