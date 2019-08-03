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


namespace StudentFacilityApp
{
    public class MyCustomAdapter : BaseAdapter<UserObject>
    {
        List<UserObject> userList;
        Activity mycontext;

        public MyCustomAdapter(Activity contex, List<UserObject> userArray)
        {
            userList = userArray;
            mycontext = contex;
        }

        public override UserObject this[int position]
        {

            get { return userList[position]; }
        }

        public override int Count
        {
            get
            {
                return userList.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }


        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View myView = convertView;
            UserObject myObj = userList[position];

            if (myView == null)
            {
                myView = mycontext.LayoutInflater.Inflate(Resource.Layout.SFragmentLayout, null);
            }

            myView.FindViewById<TextView>(Resource.Id.myNameIdl).Text = myObj.name;
            myView.FindViewById<TextView>(Resource.Id.listView1).Text = myObj.age;
            
            return myView;
        }
    }
}