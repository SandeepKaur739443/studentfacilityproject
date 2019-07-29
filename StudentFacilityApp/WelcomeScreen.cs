using Android.App;
using Android.OS;

using Android.Views;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using System;
using Android.Widget;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Content;

namespace StudentFacilityApp
{
    [Activity(MainLauncher = true)]
    public class WelcomeScreen : AppCompatActivity
    {
        Spinner spinnerView;
        Toolbar toolb;
        string[] myCategory = { "Complaint Box", "Lost & Found", "Confessions" };

        TextView myUser;
        String valueFromLoginUser;
       
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Window.RequestFeature(WindowFeatures.NoTitle);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.WelcomeScreen);

            toolb = FindViewById<Toolbar>(Resource.Id.my_toolbar);
            SetSupportActionBar(toolb);
            //SupportActionBar.Title = "Tutorial Toolbar";

            spinnerView = FindViewById<Spinner>(Resource.Id.spinner1);
            spinnerView.Adapter = new ArrayAdapter
                (this, Android.Resource.Layout.SimpleListItem1, myCategory);

            //this.Title = "welcome admin";
            //myUser.Text = "WELLCOME";
            valueFromLoginUser = Intent.GetStringExtra("userName");
            myUser = FindViewById<TextView>(Resource.Id.welcomeuser);
            myUser.Text = "Welcome," +valueFromLoginUser;


            spinnerView.ItemSelected += MyItemSelectedMethod;
        }
                //Menu Code
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
                        // add your code  
                        return true;
                    }
                case Resource.Id.menuItem2:
                    {
                        // add your code  
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
        void MyItemSelectedMethod(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            var index = e.Position;

            var value = myCategory[index];
            System.Console.WriteLine("value is " + value);


            if (value.ToLower().Equals("Complaint Box"))
            {
                //create a veg array and create as a new adater 
                Intent newScreen = new Intent(this, typeof(ComplaintBox));
               // newScreen.PutExtra("userName", myName);
                StartActivity(newScreen);
            }

        }
    }
}