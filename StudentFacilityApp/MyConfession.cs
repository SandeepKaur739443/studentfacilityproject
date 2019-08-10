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
    public class MyConfession : AppCompatActivity
    {
        Button myAddBtn;
        Button myEditBtn;
        Button myDelBtn;
        Button myconBtn;
        EditText myconfession;
        TextView mycid;
        DBHelperClass myDB;
        ICursor con_cr;
        string user_email;

        private string Update;
        Spinner spinnerv;
        Toolbar toolb;
        string[] myCategory = { "MENU", "Welcome", "Complaint Box", "Lost & Found" };
        TextView myUser;
        String valueFromLoginUser;
        ImageView eye;
        string emailPrint;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MyConfessions);
            toolb = FindViewById<Toolbar>(Resource.Id.my_toolbar);
            SetSupportActionBar(toolb);
            spinnerv = FindViewById<Spinner>(Resource.Id.spinners);

            spinnerv.Adapter = new ArrayAdapter
                (this, Android.Resource.Layout.SimpleListItem1, myCategory);

            valueFromLoginUser = Intent.GetStringExtra("email");
            myUser = FindViewById<TextView>(Resource.Id.welcomeuser);
            myUser.Text = "Welcome," + valueFromLoginUser;
            spinnerv.ItemSelected += MyItemSelectedMethod;

            // Create your application here
            myDB = new DBHelperClass(this);
            emailPrint = Intent.GetStringExtra("email");
            user_email = Intent.GetStringExtra("email");
            myAddBtn = FindViewById<Button>(Resource.Id.AddConBtn);
            myEditBtn = FindViewById<Button>(Resource.Id.EditConBtn);
            myDelBtn = FindViewById<Button>(Resource.Id.DelConBtn);
            myconBtn = FindViewById<Button>(Resource.Id.sub_conBtn);
            myconfession = FindViewById<EditText>(Resource.Id.userConfession);

            //complain_cr id
            mycid = FindViewById<TextView>(Resource.Id.con_id);
            con_cr = myDB.SelectConfessionMyId();
            con_cr.MoveToFirst();
            mycid.Text = (con_cr.GetInt(con_cr.GetColumnIndex("con_id")) + 1).ToString();

            eye = FindViewById<ImageView>(Resource.Id.imageeye);

            //mycomplaintBtn.Text = "Submit";

            myconBtn.Click += delegate
            {
                if (myconBtn.Text.ToLower() == "submit")
                {
                    myDB.InsertmyConfession(mycid.Text, myconfession.Text, user_email, DateTime.Now.ToShortDateString().ToString());
                }
                else if (myconBtn.Text.ToLower() == "update")
                {
                    myDB.SelectMyConfessionToUpdate(mycid.Text, myconfession.Text);
                }
                else if (myconBtn.Text.ToLower() == "delete")
                {
                   
                    myDB.Delete_condata(mycid.Text);
                }

            };

            myEditBtn.Click += delegate
            {
                //name.Enabled = true;
                myconfession.Enabled = true;
                myconBtn.Text = "Update";

            };
            myDelBtn.Click += delegate
            {
                myconfession.Enabled = true;
                myconBtn.Text = "Delete";
            };
            myAddBtn.Click += delegate
            {
                myconfession.Enabled = true;
                myconBtn.Text = "Submit";
                myconfession.Text = "";
                con_cr = myDB.SelectConfessionMyId();
                con_cr.MoveToFirst();
                mycid.Text = (con_cr.GetInt(con_cr.GetColumnIndex("con_id")) + 1).ToString();


            };
            eye.Click += delegate
            {
                Intent newScreen = new Intent(this, typeof(ViewConfessionList));
                newScreen.PutExtra("email", valueFromLoginUser);
                StartActivity(newScreen);
            };


        }

        private void MyItemSelectedMethod(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            var index = e.Position;

            var value = myCategory[index];
            System.Console.WriteLine("value is " + value);


             if (value.Equals("Welcome"))
            {
                Intent newScreen = new Intent(this, typeof(WelcomeScreen));
                newScreen.PutExtra("email", valueFromLoginUser);
                //GlobalClass.Setemail(emailPrint);
                StartActivity(newScreen);
            }
            else if (value.Equals("Complaint Box"))
            {
                //create a veg array and create as a new adater 
                Android.Content.Intent newScreen = new Intent(this, typeof(ComplaintBox));
                newScreen.PutExtra("email", valueFromLoginUser);
                StartActivity(newScreen);
            }
            else if (value.Equals("Lost & Found"))
            {
                Intent newScreen = new Intent(this, typeof(LostandFound));
                newScreen.PutExtra("email", valueFromLoginUser);

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
                        StartActivity(newScreen);

                        return true;
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
        public void myEditBtnClicEvent(object sender, EventArgs e)
        {
            myconfession.Enabled = true;
            myconBtn.Text = "Delete";


        }
    }
}


  