using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace StudentFacilityApp
{
    public class FirstFragment : Fragment
    {
        public String myName;
        public String age;

       
        List<UserObject> myUsersList ;

        

        public FirstFragment(string name, string age1, List<UserObject> templist)
        {
            myName = name;
            age = age1;
            myUsersList = templist;


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
            ListView mylist = myView.FindViewById<ListView>(Resource.Id.mylistview);

            
            myView.FindViewById<TextView>(Resource.Id.myNameIdl).Text = myName;
            myView.FindViewById<TextView>(Resource.Id.listID).Text = age;

            return myView;

            //return base.OnCreateView(inflater, container, savedInstanceState);
        }
    }
}