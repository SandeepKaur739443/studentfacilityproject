using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Database;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;

namespace StudentFacilityApp
{
    [Activity(Label = "SignUp")]
    public class SignUp : Activity
    {
        DBHelperClass myDB;
        ICursor cr;
        TextView myid;
        EditText reg_username;
        EditText reg_email;
        EditText reg_contact;
        EditText reg_passwd;
        EditText reg_confirmpasswd;
        Button RegSignUpBtn;

        Android.App.AlertDialog.Builder alert;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.registration);

            myDB = new DBHelperClass(this);
            alert = new Android.App.AlertDialog.Builder(this);
            reg_username = FindViewById<EditText>(Resource.Id.reguserID);
            reg_email = FindViewById<EditText>(Resource.Id.reguserEmail);
            reg_contact = FindViewById<EditText>(Resource.Id.regContact);
            reg_passwd = FindViewById<EditText>(Resource.Id.pswd);
            reg_confirmpasswd = FindViewById<EditText>(Resource.Id.ConfirmPswd);
            RegSignUpBtn = FindViewById<Button>(Resource.Id.signupBtn);

            //auto generate id

            myid = FindViewById<TextView>(Resource.Id.user_id);
            cr = myDB.SelectMyId();
            cr.MoveToFirst();
            myid.Text = (cr.GetInt(cr.GetColumnIndex("id"))+1).ToString();
            reg_confirmpasswd.TextChanged += check_password;

            //email validation

            RegSignUpBtn.Click += delegate
            {
                var ruserName = reg_username.Text;
                var rEmail = reg_email.Text;
                var rContact = reg_contact.Text;
                var rPassword = reg_passwd.Text;
                var rConfirmPassword = reg_passwd.Text;
                
                if (ruserName.Trim().Equals("") || ruserName.Length < 0 || rEmail.Trim().Equals("") ||
                rEmail.Length < 0 || rContact.Trim().Equals("") ||
                rContact.Length < 0 || rPassword.Trim().Equals("") || rPassword.Length < 0 ||
                rConfirmPassword.Trim().Equals("") || rConfirmPassword.Length < 0)
                {

                    alert.SetTitle("Error");
                    alert.SetMessage("Field can not be empty");
                    alert.SetPositiveButton("OK", alertOKButton);
                    alert.SetNegativeButton("Cancel", alertOKButton);
                    Dialog myDialog = alert.Create();
                    myDialog.Show();
                }

                else
                {

                    myDB.InsertValue(myid.Text, ruserName, rEmail, rContact, rPassword);

                    myDB.SelectMydata();

                    Intent newScreen = new Intent(this, typeof(MainActivity));
                    StartActivity(newScreen);

                }

            }; 

        }

        private void check_password(object sender, TextChangedEventArgs e)
        {
            if(reg_passwd.Text != reg_confirmpasswd.Text)
            {
                reg_confirmpasswd.Error = "wrong password";
                RegSignUpBtn.Enabled = false;
            }
            else if(reg_passwd.Text == reg_confirmpasswd.Text)
            {
                RegSignUpBtn.Enabled = true;
            }
        }

        private void alertOKButton(object sender, DialogClickEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}