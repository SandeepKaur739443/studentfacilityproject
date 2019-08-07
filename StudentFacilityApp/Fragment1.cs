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


        string[] movieArray = { "A-Moive", "B-Moive",
                "C-Moive", "D-Moive", "E-Moive", "F - Moive", "G  - Moive", "H  - Moive", "I  - Moive"};


        public String myName;
        public Activity myContext;

        public Fragment1(string name, Activity context)
        {
            myName = name;
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
            ListView myList = myView.FindViewById<ListView>(Resource.Id.listID);
            myView.FindViewById<TextView>(Resource.Id.myNameIdl).Text = myName;

            myList.Adapter = new ArrayAdapter(myContext, Android.Resource.Layout.SimpleListItem1, movieArray);


            return myView;

            //return base.OnCreateView(inflater, container, savedInstanceState);
        }
    }
}