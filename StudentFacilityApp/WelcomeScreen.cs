﻿using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.Design.Internal;
using Android.Support.V4.View;
using System.Collections.Generic;
using Android.Support.V4.App;
using Android.Views;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using System;
using Android.Widget;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Content;
using Android.Database;


namespace StudentFacilityApp
{

    [Android.App.Activity(Theme = "@style/AppTheme", MainLauncher = false)]

    public class WelcomeScreen : AppCompatActivity
    {
        ViewPager _viewPager;
        BottomNavigationView _navigationView;
        Fragment[] _fragments;
        DBHelperClass myDB;

        Spinner spinnerView;
        Toolbar toolb;
        string[] myCategory = { "MENU", "Complaint Box", "Lost & Found", "Confessions" };
        TextView myUser;
        String valueFromLoginUser;

        ListView lv1;
        TextView mytextcomp;
        List<UserObject> myusersList = new List<UserObject>();
        MyCustomAdapter myAdapter;


        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.WelcomeScreen);
            myDB = new DBHelperClass(this);



            /* myDB.SelectComplaintList();
             cursor = myDB.SelectComplaintList();
             cursor.MoveToFirst();
             while(cursor.MoveToNext())
             {


             }*/
            mytextcomp = FindViewById<TextView>(Resource.Id.mycomp);
          /*  myDB.Selectcomplain();
            ICursor cur = myDB.Selectcomplain();
            cur.MoveToFirst();
            if (cur.MoveToFirst())
            {
                do
                {
                    string image = cur.GetString(cur.GetColumnIndexOrThrow("item_sub"));
                    int im = Convert.ToInt32(image);
                    myusersList.Add(new UserObject("myDB.Selectcomplain();","myDB.Selectcomplain();",im));
                }

                while (cur.MoveToNext());
                {


                }
                cur.Close(); */
                // lv1 = FindViewById<ListView>(Resource.Id.listView1);
                var myAdatper = new MyCustomAdapter(this, myusersList);
                //lv1.Adapter = myAdapter;
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

                InitializeTabs();

                _viewPager = FindViewById<ViewPager>(Resource.Id.viewpager);
                _viewPager.PageSelected += ViewPager_PageSelected;
                _viewPager.Adapter = new ViewPagerAdapter(SupportFragmentManager, _fragments);

                _navigationView = FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation);
                RemoveShiftMode(_navigationView);
                _navigationView.NavigationItemSelected += NavigationView_NavigationItemSelected;

            }

        
        private void MyItemSelectedMethod(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            var index = e.Position;

            var value = myCategory[index];
            System.Console.WriteLine("value is " + value);


            if (value.Equals("Complaint Box"))
            {
                //create a veg array and create as a new adater 
                Android.Content.Intent newScreen = new Intent(this, typeof(ComplaintBox));
                newScreen.PutExtra("email", valueFromLoginUser);
                StartActivity(newScreen);
            }
            else if (value.Equals("Lost & Found"))
            {
                Android.Content.Intent newScreen = new Intent(this, typeof(LostandFound));
                newScreen.PutExtra("email", valueFromLoginUser);
                StartActivity(newScreen);
            }
            else if (value.Equals("Confessions"))
            {
                Intent newScreen = new Intent(this, typeof(ComplaintBox));
                StartActivity(newScreen);
            }

        
    }

        void InitializeTabs()
        {

                _fragments = new Fragment[] {
                 new Fragment1(this),
               // new Fragment2(),
               // new Fragment1(),
                //new Fragment2()
            };
        }

        private void ViewPager_PageSelected(object sender, ViewPager.PageSelectedEventArgs e)
        {
            var item = _navigationView.Menu.GetItem(e.Position);
            _navigationView.SelectedItemId = item.ItemId;
        }

        void NavigationView_NavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
        {
            _viewPager.SetCurrentItem(e.Item.Order, true);
        }

        void RemoveShiftMode(BottomNavigationView view)
        {

            var menuView = (BottomNavigationMenuView)view.GetChildAt(0);

            try
            {
                var shiftingMode = menuView.Class.GetDeclaredField("mShiftingMode");
                shiftingMode.Accessible = true;
                shiftingMode.SetBoolean(menuView, false);
                shiftingMode.Accessible = false;

                for (int i = 0; i < menuView.ChildCount; i++)
                {
                    var item = (BottomNavigationItemView)menuView.GetChildAt(i);
                    item.SetShiftingMode(false);
                    // set once again checked value, so view will be updated
                    item.SetChecked(item.ItemData.IsChecked);
                }
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine((ex.InnerException ?? ex).Message);
            }
        }

        protected override void OnDestroy()
        {
            _viewPager.PageSelected -= ViewPager_PageSelected;
            _navigationView.NavigationItemSelected -= NavigationView_NavigationItemSelected;
            base.OnDestroy();
        }
        public  override bool OnCreateOptionsMenu(IMenu menu)
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