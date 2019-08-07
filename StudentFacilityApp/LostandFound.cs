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
using Toolbar = Android.Support.V7.Widget.Toolbar;
namespace StudentFacilityApp
{
    [Activity(Theme = "@style/AppTheme")]
    public class LostandFound : AppCompatActivity
    {
        string user_email;
        TextView itemid;
        EditText itemName;
        RadioButton lost;
        RadioButton found;
        EditText item_loc;
        EditText item_des;
        Button btn_Submit;
        Button btn_editt;
        Button btn_delete;
        DBHelperClass myDB;
        ICursor item_cr;
        Spinner spinnerView;
        Toolbar toolb;
        string[] myCategory = { "MENU", "Welcome", "Complaint Box", "Confessions" };
        TextView myUser;
        String valueFromLoginUser;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.LostandFound);

            //toolbar
            toolb = FindViewById<Toolbar>(Resource.Id.my_toolbar);

            SetSupportActionBar(toolb);
            spinnerView = FindViewById<Spinner>(Resource.Id.spinner1);

            spinnerView.Adapter = new ArrayAdapter
                (this, Android.Resource.Layout.SimpleListItem1, myCategory);

            valueFromLoginUser = Intent.GetStringExtra("email");
            myUser = FindViewById<TextView>(Resource.Id.welcomeuser);
            myUser.Text = "Welcome," + valueFromLoginUser;
            spinnerView.ItemSelected += MyItemSelectedMethod;

            //page coding
           
            myDB = new DBHelperClass(this);
            user_email = Intent.GetStringExtra("email");

            itemName = FindViewById<EditText>(Resource.Id.item_Name);
            lost = FindViewById<RadioButton>(Resource.Id.radioLost);
            found = FindViewById<RadioButton>(Resource.Id.radioFound);
            item_loc = FindViewById<EditText>(Resource.Id.location);
            item_des = FindViewById<EditText>(Resource.Id.decs);
            btn_Submit = FindViewById<Button>(Resource.Id.submit);
            btn_editt = FindViewById<Button>(Resource.Id.edit);
            btn_delete = FindViewById<Button>(Resource.Id.delete);

            //item_cr id
            itemid = FindViewById<TextView>(Resource.Id.item_Idd);
            item_cr = myDB.SelectmyItemId();
            item_cr.MoveToFirst();
            itemid.Text = (item_cr.GetInt(item_cr.GetColumnIndex("item_ID")) + 1).ToString();


            btn_Submit.Click += delegate
            {
                if (lost.Checked)
                {
                    myDB.InsertmyLostFound(itemid.Text, itemName.Text, lost.Text, item_loc.Text, item_des.Text, user_email);
                }
                else
                    {
                    myDB.InsertmyLostFound(itemid.Text, itemName.Text, found.Text, item_loc.Text, item_des.Text, user_email);

                }
            };
            btn_editt.Click += delegate
             {
                 myDB.SelectMyItemToUpdate(itemid.Text, itemName.Text, found.Text, item_loc.Text, item_des.Text);
             };
            btn_delete.Click += delegate
            {
                myDB.Delete_myItem(itemid.Text);
            };


        }
       
        private void MyItemSelectedMethod(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            var index = e.Position;

            var value = myCategory[index];
            System.Console.WriteLine("value is " + value);


            if (value.Equals("Welcome"))
            {
                //create a veg array and create as a new adater 
                Android.Content.Intent newScreen = new Intent(this, typeof(WelcomeScreen));
                newScreen.PutExtra("userName", valueFromLoginUser);
                StartActivity(newScreen);
            }
            else if (value.Equals("Complaint Box"))
            {
                Intent newScreen = new Intent(this, typeof(ComplaintBox));
                newScreen.PutExtra("email", valueFromLoginUser);
                StartActivity(newScreen);
            }
            else if (value.Equals("Confessions"))
            {
                Intent newScreen = new Intent(this, typeof(ComplaintBox));
                StartActivity(newScreen);
            }
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            // set the menu layout on Main Activity  
            MenuInflater.Inflate(Resource.Menu.menu1, menu);
            return base.OnCreateOptionsMenu(menu);
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.menuItem1:
                    {
                        Android.Content.Intent newScreen = new Intent(this, typeof(Profile));
                        newScreen.PutExtra("userName", valueFromLoginUser);
                        StartActivity(newScreen); return true;
                    }
                case Resource.Id.menuItem2:
                    {
                        Android.Content.Intent newScreen = new Intent(this, typeof(MainActivity));
                        newScreen.PutExtra("userName", valueFromLoginUser);
                        StartActivity(newScreen);
                        return true;
                    }
                case Resource.Id.menuItem3:
                    {
                        // add your code  
                        return true;
                    }
            }

            return base.OnOptionsItemSelected(item);
        }
    }
}
