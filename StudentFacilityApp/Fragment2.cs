using Android.App;
using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;

namespace StudentFacilityApp
{
    internal class Fragment2 : Android.Support.V4.App.Fragment
    {
        TextView complains;
        Android.Database.ICursor i;
        ArrayAdapter myAdapterarray;
        List<string> rsname = new List<string>();

        DBHelperClass myDB;

        public String myName;
        public Activity myContext;

        public Fragment2(Activity context)
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
            myDB.SelectConfession();
            i = myDB.SelectConfession();
            while (i.MoveToNext())
            {
                string a = i.GetString(i.GetColumnIndexOrThrow("my_confession"));
                Console.WriteLine(a);
                rsname.Add(a);
            }
            View myView = inflater.Inflate(Resource.Layout.SFragmentLayout, container, false);
            ListView myList = myView.FindViewById<ListView>(Resource.Id.listView1);
            myView.FindViewById<TextView>(Resource.Id.myNameId2).Text = myName;

            myList.Adapter = new ArrayAdapter(myContext, Android.Resource.Layout.SimpleListItem1, rsname);
            return myView;


        }
    }
}

