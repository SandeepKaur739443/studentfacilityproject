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
    [Activity(Label = "View_Item")]
    public class ViewItemsLF : AppCompatActivity
    {
        ListView lv1;
        SearchView sv1;
        DBHelperClass myDB;

       // Custom Adaptor edited thing
        string emailPrint;

        List<UserObject> myUsersList = new List<UserObject>();

        public static string emailValue = "email";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ViewItem);
            myDB = new DBHelperClass(this);

            lv1 = FindViewById<ListView>(Resource.Id.listView1);
            sv1 = FindViewById<SearchView>(Resource.Id.searchView1);

            emailPrint = Intent.GetStringExtra("username");

            // Custom Adaptor Editing
            ICursor cs = myDB.SelectIteme();
            if (cs.MoveToFirst())
            {
                do
                {
                    string image = cs.GetString(cs.GetColumnIndexOrThrow("item_sub"));
                    int im = Convert.ToInt32(image);
                    myUsersList.Add(new UserObject(cs.GetString(cs.GetColumnIndexOrThrow("item_name")), cs.GetString(cs.GetColumnIndexOrThrow("email")),
                        cs.GetString(cs.GetColumnIndexOrThrow("description")), im));
                }

                while (cs.MoveToNext());
                {


                }
                cs.Close();
                // custom adapton code added
                MyCustomAdapterList myAdapter = new MyCustomAdapterList(this, myUsersList);
                lv1.Adapter = myAdapter;
                lv1.ItemClick += Lv1_ItemClick;
                sv1.QueryTextChange += Sv1_QueryTextChange;

            }
        }

        private void Lv1_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var index = e.Position;
            var myvalue = myUsersList[index];

            Intent newScreen = new Intent(this, typeof(SelectedItemDetail));
            newScreen.PutExtra("name", myvalue.name);
            newScreen.PutExtra("desc", myvalue.desc);
            newScreen.PutExtra("email", myvalue.email);
            newScreen.PutExtra("image", myvalue.image.ToString());
            StartActivity(newScreen);
        }

        private void Sv1_QueryTextChange(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(e.NewText))
            {
                MyCustomAdapterList myAdapter = new MyCustomAdapterList(this, myUsersList);
                lv1.Adapter = myAdapter;
            }
            else
            {
                MyCustomAdapterList myAdapter = new MyCustomAdapterList(this, myUsersList.Where(us => us.email.StartsWith(e.NewText)).ToList());
                lv1.Adapter = myAdapter;
            }

        }    }
}