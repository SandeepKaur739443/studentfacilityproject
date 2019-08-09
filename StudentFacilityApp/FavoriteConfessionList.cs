using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Database;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace StudentFacilityApp
{
    [Activity(Theme = "@style/AppTheme")]
    public class FavoriteConfessionList : AppCompatActivity
    {
        ListView list2;
        string fav;
        DBHelperClass myDB;
        ICursor cr;
        string valueFromLoginUser;
        string conff;
        string email;
        string dates;
        List<ConfessionUserObj> myUsersList = new List<ConfessionUserObj>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.FavConfessionList);
            valueFromLoginUser = Intent.GetStringExtra("email");
            cr = myDB.SelectFavConfession(valueFromLoginUser);
            cr.MoveToFirst();
            // mypid.Text = cr.GetString(cr.GetColumnIndexOrThrow("id"));
            if (cr.MoveToFirst())
            {
                do
                {
                    myUsersList.Add(new ConfessionUserObj(cr.GetString(cr.GetColumnIndexOrThrow("fav_confession")), cr.GetString(cr.GetColumnIndexOrThrow("Confession_date"))));
                }

                while (cr.MoveToNext());
                {


                }
                cr.Close();
                // custom adapton code added
                ConfessionAdapterList myAdapter = new ConfessionAdapterList(this, myUsersList);
                list2.Adapter = myAdapter;
                
            }
        }
    }
}
