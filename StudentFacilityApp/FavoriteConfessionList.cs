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
        ListView l2;
        List<ConfessionUserObj> UsersList = new List<ConfessionUserObj>();
        ConfessionAdapterList myAdapters;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.FavConfessionList);
            list2 = FindViewById<ListView>(Resource.Id.conlist);
           // l2 = FindViewById<ListView>(Resource.Id.conDate);
            valueFromLoginUser = GlobalClass.GetEmail();
            myDB = new DBHelperClass(this);
          
            cr = myDB.SelectFavConfession(valueFromLoginUser);
            cr.MoveToFirst();
            // mypid.Text = cr.GetString(cr.GetColumnIndexOrThrow("id"));
            while (cr.MoveToNext())
            {
                var a = cr.GetString(cr.GetColumnIndexOrThrow("fav_confession"));
                var b = cr.GetString(cr.GetColumnIndexOrThrow("Confessionfav_date"));
                UsersList.Add(new ConfessionUserObj(a, b));
               
            }
               
                // custom adapton code added
                myAdapters = new ConfessionAdapterList(this, UsersList);
                list2.Adapter = myAdapters;
                
            }
        }
    }

