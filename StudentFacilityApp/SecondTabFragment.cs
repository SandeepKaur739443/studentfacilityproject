using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Support.V4.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace StudentFacilityApp
{
    public class SecondTabFragment : Fragment
    {
        public string listt;
        readonly Fragment localContext;
        public SecondTabFragment(string list1, Fragment myContext)
        {
            localContext = myContext;
            listt = list1;

        }

        public SecondTabFragment(string v, Fragment[] items)
        {
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View myView = inflater.Inflate(Resource.Layout.SFragmentLayout, container, false);
            ListView listview = (ListView)myView.FindViewById(Resource.Id.listView1);

            //EDITED Code 
            String[] items = new String[] { "Item 1", "Item 2", "Item 3" };
            ArrayAdapter<String> adapter =
            new ArrayAdapter<string>(Context, Android.Resource.Layout.SimpleListItem1, items);

#pragma warning disable CS0618 // Type or member is obsolete
            listview.SetAdapter(adapter);
#pragma warning restore CS0618 // Type or member is obsolete
            listview.ItemClick += myTeamClickMethod;

            void myTeamClickMethod(object sender, AdapterView.ItemClickEventArgs e)
            {
                System.Console.WriteLine("Item clicked");

                var ivalue = e.Position;
                var myvalue = items[ivalue];

                System.Console.WriteLine("Value is:-" + myvalue);

            }

            return myView;
            //return base.OnCreateView(inflater, container, savedInstanceState);
        }
    }
}