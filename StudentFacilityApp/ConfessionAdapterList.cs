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
    class ConfessionAdapterList:BaseAdapter<ConfessionUserObj>
    {
        List<ConfessionUserObj> userList;
        Activity mycontext;

        public ConfessionAdapterList(Activity contex, List<ConfessionUserObj> userArray)
        {
            userList = userArray;
            mycontext = contex;
        }

        public override ConfessionUserObj this[int position]
        {

            get { return userList[position]; }
        }

      //  public override UserObject this[int position] => throw new NotImplementedException();

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
            ConfessionUserObj myObj = userList[position];

            if (myView == null)
            {
                myView = mycontext.LayoutInflater.Inflate(Resource.Layout.CellLayout, null);
            }

            myView.FindViewById<TextView>(Resource.Id.nameID).Text = myObj.name;
            myView.FindViewById<TextView>(Resource.Id.ageID).Text = myObj.date;
           // myView.FindViewById<ImageView>(Resource.Id.userImageId).SetImageResource(myObj.image);
            return myView;
        }
    }
}
   