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
    public class ComplaintBox : AppCompatActivity
    {
        // DBHelperClass myDB;
        Button myAddBtn;
        Button myEditBtn;
        Button myDelBtn;
        Button mycomplaintBtn;
        EditText myComplaint;
        TextView myid;
        DBHelperClass myDB;
        ICursor complain_cr;
        string user_email;
        private string Submit;
        private string Update;
        Spinner spinnerView;
        Toolbar toolb;
        string[] myCategory = { "MENU", "Complaint Box", "Lost & Found", "Confessions" };
        TextView myUser;
        String valueFromLoginUser;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ComplaintBoxLayout);

            toolb = FindViewById<Toolbar>(Resource.Id.my_toolbar);

            SetSupportActionBar(toolb);
            spinnerView = FindViewById<Spinner>(Resource.Id.spinner1);

            spinnerView.Adapter = new ArrayAdapter
                (this, Android.Resource.Layout.SimpleListItem1, myCategory);

            valueFromLoginUser = Intent.GetStringExtra("email");
            myUser = FindViewById<TextView>(Resource.Id.welcomeuser);
            myUser.Text = "Welcome," + valueFromLoginUser;
            spinnerView.ItemSelected += MyItemSelectedMethod;

            // Create your application here
            myDB = new DBHelperClass(this);

            user_email = Intent.GetStringExtra("email");
            myAddBtn = FindViewById<Button>(Resource.Id.AddBtn);
            myEditBtn = FindViewById<Button>(Resource.Id.EditBtn);
            myDelBtn = FindViewById<Button>(Resource.Id.DelBtn);
            mycomplaintBtn = FindViewById<Button>(Resource.Id.sub_complainBtn);
            myComplaint = FindViewById<EditText>(Resource.Id.usercomplaint);

            //complain_cr id
            myid = FindViewById<TextView>(Resource.Id.complaint_id);
            complain_cr = myDB.SelectComplainMyId();
            complain_cr.MoveToFirst();
            myid.Text = (complain_cr.GetInt(complain_cr.GetColumnIndex("c_id")) + 1).ToString();


            //mycomplaintBtn.Text = "Submit";
            
                mycomplaintBtn.Click += delegate
                    {
                        if (mycomplaintBtn.Text.ToLower() == "submit")
                        {
                            myDB.InsertmyComplaint(myid.Text, myComplaint.Text, user_email, DateTime.Now.ToShortDateString().ToString());
                        }
                        else if (mycomplaintBtn.Text.ToLower() == "update")
                        {
                            myDB.SelectMyDataToUpdate(myid.Text, myComplaint.Text);
                        }
                        else if (mycomplaintBtn.Text.ToLower() == "delete")
                        {
                            //myDB.SelectMyDataToUpdate(myid.Text, myComplaint.Text, DateTime.Now.ToShortDateString().ToString());
                            myDB.Delete_data(myid.Text);
                        }
                       
                    };

            myEditBtn.Click += delegate
            {
                //name.Enabled = true;
                myComplaint.Enabled = true;
                mycomplaintBtn.Text = "Update";

            };
            myDelBtn.Click += delegate
            {
                myComplaint.Enabled = true;
                mycomplaintBtn.Text = "Delete";
            };
            myAddBtn.Click += delegate
            {
                myComplaint.Enabled = true;
                mycomplaintBtn.Text = "Submit";
                myComplaint.Text = "";
                complain_cr = myDB.SelectComplainMyId();
                complain_cr.MoveToFirst();
                myid.Text = (complain_cr.GetInt(complain_cr.GetColumnIndex("c_id")) + 1).ToString();


            };

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
                Intent newScreen = new Intent(this, typeof(ComplaintBox));
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
        public void myEditBtnClicEvent(object sender, EventArgs e)
        {
            myComplaint.Enabled = true;
            mycomplaintBtn.Text = "Delete";
           

        }
    }
}
