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
using Android.Text;
using Android.Views;
using Android.Widget;
using Toolbar = Android.Support.V7.Widget.Toolbar;


namespace StudentFacilityApp
{
    [Android.App.Activity(Theme = "@style/AppTheme", MainLauncher = false)]
    public class Profile : AppCompatActivity
    {
        
        DBHelperClass myDB;
        ICursor p_cursor;
        Spinner spinnerView;
        Toolbar toolb;
        string[] myCategory = { "MENU", "Welcome", "Complaint Box", "Lost & Found", "Confessions" };
        TextView myUser;
        String valueFromLoginUser;

        TextView mypid;
        EditText _username;
        EditText _email;
        EditText _contact;
        EditText _passwd;
        EditText _confirmpasswd;
        Button SubmitBtn;

        Android.App.AlertDialog.Builder alert;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.User_Profile);

            toolb = FindViewById<Toolbar>(Resource.Id.my_toolbar);

            SetSupportActionBar(toolb);
            spinnerView = FindViewById<Spinner>(Resource.Id.spinner1);

            spinnerView.Adapter = new ArrayAdapter
                (this, Android.Resource.Layout.SimpleListItem1, myCategory);

            valueFromLoginUser = Intent.GetStringExtra("userName");
            myUser = FindViewById<TextView>(Resource.Id.welcomeuser);
            myUser.Text = "Welcome," + valueFromLoginUser;
            // this.Title = "welcome admin";
            spinnerView.ItemSelected += MyItemSelectedMethod;

            alert = new Android.App.AlertDialog.Builder(this);

            //edit buttons
            myDB = new DBHelperClass(this);
            //alert = new Android.App.AlertDialog.Builder(this);
             mypid = FindViewById<TextView>(Resource.Id.user_id);
            _username = FindViewById<EditText>(Resource.Id.userNamee);
            _email = FindViewById<EditText>(Resource.Id.userEmail);
            _contact = FindViewById<EditText>(Resource.Id.userContact);
            _passwd = FindViewById<EditText>(Resource.Id.userpswd);
            _confirmpasswd = FindViewById<EditText>(Resource.Id.userConfirmPswd);
            SubmitBtn = FindViewById<Button>(Resource.Id.usersubmit);

            //disable email
            _email.Enabled = false;
            mypid.Enabled = false;
            p_cursor = myDB.SelectProfile(valueFromLoginUser);
            p_cursor.MoveToFirst();
            mypid.Text = p_cursor.GetString(p_cursor.GetColumnIndexOrThrow("id"));
            _username.Text = p_cursor.GetString(p_cursor.GetColumnIndexOrThrow("names"));
            _email.Text = valueFromLoginUser;
            _contact.Text = p_cursor.GetString(p_cursor.GetColumnIndexOrThrow("contact"));
            _passwd.Text = p_cursor.GetString(p_cursor.GetColumnIndexOrThrow("password"));

            _confirmpasswd.TextChanged += check_password;

            SubmitBtn.Click += delegate
             {
                 string value = _username.Text;
                 string value1 = _contact.Text;
                 string value2 = _passwd.Text;
                 string value3 = _confirmpasswd.Text;



                 System.Console.WriteLine("Text Value ---- > " + value);
                 //check for empty value
                 if (value.Trim().Equals("") || value.Length < 0 || value1.Trim().Equals("") || value1.Length < 0 ||
                 value2.Trim().Equals("") || value2.Length < 0 || value3.Trim().Equals("") || value3.Length < 0)
                 {

                     alert.SetTitle("Error");
                     alert.SetMessage("Please Enter Valid Data");
                     alert.SetPositiveButton("OK", alertOKButton);
                     alert.SetNegativeButton("Cancel", alertOKButton);
                     Dialog myDialog = alert.Create();
                     myDialog.Show();
                 }
                 else
                 {
                     myDB.SelectMyProfileToUpdate(mypid.Text, _username.Text, _contact.Text, _passwd.Text);
                 }
             };

        }

        private void alertOKButton(object sender, DialogClickEventArgs e)
        {
            System.Console.WriteLine("OK Button Pressed");
        }

        private void check_password(object sender, TextChangedEventArgs e)
        {
            if (_passwd.Text != _confirmpasswd.Text)
            {
                _confirmpasswd.Error = "wrong password";
                SubmitBtn.Enabled = false;
            }
            else if (_passwd.Text == _confirmpasswd.Text)
            {
                SubmitBtn.Enabled = true;
            }
        }

        //update on click

    private void MyItemSelectedMethod(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            var index = e.Position;

            var value = myCategory[index];
            System.Console.WriteLine("value is " + value);

            if (value.Equals("Welcome"))
            {
                //create a veg array and create as a new adater 
                Android.Content.Intent newScreen = new Intent(this, typeof(WelcomeScreen));
                newScreen.PutExtra("username", valueFromLoginUser);
                StartActivity(newScreen);
            }
            else if (value.Equals("Complaint Box"))
            {
                //create a veg array and create as a new adater 
                Android.Content.Intent newScreen = new Intent(this, typeof(ComplaintBox));
                newScreen.PutExtra("username", valueFromLoginUser);
                StartActivity(newScreen);
            }
            else if (value.Equals("Lost & Found"))
            {
                Android.Content.Intent newScreen = new Intent(this, typeof(LostandFound));
                newScreen.PutExtra("username", valueFromLoginUser);
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
    }
}