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
    public class ViewConfessionList : AppCompatActivity
    {
        ListView list1;
        SearchView sr1;
        DBHelperClass myDB;

        // Custom Adaptor edited thing
        string emailPrint;
        string cfid;
        string conf;
        string date;
        ICursor cn;

        List<ConfessionUserObj> UsersList = new List<ConfessionUserObj>();

      //  public static string emailValue = "email";
        private Android.App.AlertDialog.Builder alert;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ViewConfession);
            myDB = new DBHelperClass(this);

            list1 = FindViewById<ListView>(Resource.Id.listView2);
            sr1 = FindViewById<SearchView>(Resource.Id.searchView2);

            emailPrint = Intent.GetStringExtra("email");

            // Custom Adaptor Editing
            ICursor cs = myDB.SelectConfession();
           
            if (cs.MoveToFirst())
            {
                do
                {
                    string cfid = cs.GetString(cs.GetColumnIndexOrThrow("con_id"));
                    UsersList.Add(new ConfessionUserObj(cs.GetString(cs.GetColumnIndexOrThrow("my_confession")), cs.GetString(cs.GetColumnIndexOrThrow("Confession_date"))));
                
                }

                while (cs.MoveToNext());
                {


                }
                cs.Close();
                // custom adapton code added
                ConfessionAdapterList myAdapter = new ConfessionAdapterList(this, UsersList);
                list1.Adapter = myAdapter;
                list1.ItemClick += Lv1_ItemClick;
                sr1.QueryTextChange += Sv1_QueryTextChange;

            }
        }
        private void Lv1_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var index = e.Position;
            var myvalue = UsersList[index];
            alert = new Android.App.AlertDialog.Builder(this);
            alert.SetTitle("Favorite");
            alert.SetMessage("Do you like It?");
            alert.SetPositiveButton("Yes", alertOKButton);
            alert.SetNegativeButton("No", alertCancelButton);
            Dialog myDialog = alert.Create();
            myDialog.Show();
            // Intent newScreen = new Intent(this, typeof(FavoriteConfessionList));
            // newScreen.PutExtra("name", myvalue.name);
            //newScreen.PutExtra("date", myvalue.date);

            // StartActivity(newScreen);
            conf =  (myvalue.name).ToString();
            date =  (myvalue.date).ToString();
        }

        private void alertOKButton(object sender, DialogClickEventArgs e)
        {
            myDB.insertFavoriteCon( conf, emailPrint, date);
           
            Intent newScreen = new Intent(this, typeof(FavoriteConfessionList));
            GlobalClass.Setemail(emailPrint);
            //newScreen.PutExtra("date", myvalue.date);
            StartActivity(newScreen);


        }
        private void alertCancelButton(object sender, DialogClickEventArgs e)
        {
            

        }

        private void Sv1_QueryTextChange(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.NewText))
            {
                ConfessionAdapterList myAdapter = new ConfessionAdapterList(this, UsersList);
                list1.Adapter = myAdapter;
            }
            else
            {
                ConfessionAdapterList myAdapter = new ConfessionAdapterList(this, UsersList.Where(us => us.name.StartsWith(e.NewText)).ToList());
                list1.Adapter = myAdapter;
            }

        }
    }
}