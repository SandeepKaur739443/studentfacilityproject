using Android.App;
using Android.OS;

using Android.Runtime;
using Android.Widget;
using System;
using Android.Views;
using Android.Content;
using Android.Database;

namespace StudentFacilityApp
{

    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]

    public class MainActivity : Activity
    {
        EditText myUserName;
        EditText myUserPasswd;
        Button myLoginbtn;
        Button mySignupBtn;

        Android.App.AlertDialog.Builder alert;
        DBHelperClass myDB;
        ICursor c_login;
        private readonly object myUser;
     

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            //fatching information from login page
            myUserName = FindViewById<EditText>(Resource.Id.uname);
            myUserPasswd = FindViewById<EditText>(Resource.Id.userpassword);
            myLoginbtn = FindViewById<Button>(Resource.Id.loginBtn);
            mySignupBtn = FindViewById<Button>(Resource.Id.button1);

            alert = new Android.App.AlertDialog.Builder(this);
            myDB = new DBHelperClass(this);

            //fatching information from signup page

            mySignupBtn.Click += delegate
            {
                Intent newScreen = new Intent(this, typeof(SignUp));
                StartActivity(newScreen);
           };
            myLoginbtn.Click += delegate
            {
                
                if(myUserName.Equals("") || myUserPasswd.Equals(""))
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
                    var email = myUserName.Text;
                    var myPassword = myUserPasswd.Text;

                    string userValue = myUserName.Text.ToString();
                    var showResult = FindViewById<TextView>(Resource.Id.emailResult);
                    var emailLoginResult = isValidEmail(userValue);

                    System.Console.WriteLine("Username: ---- > " + email);
                    System.Console.WriteLine("Password: ---- > " + myPassword);

                    //myUserName.Error = "Plase enter Email Id";

                    c_login = myDB.Validate_LogIn(myUserName.Text);
                    c_login.MoveToFirst();


                    var uname = c_login.GetString(c_login.GetColumnIndexOrThrow("email"));
                    var upass = c_login.GetString(c_login.GetColumnIndexOrThrow("password"));
                    if (uname == myUserName.Text && myUserPasswd.Text == upass)

                    {
                        
                        Intent newScreen = new Intent(this, typeof(WelcomeScreen));
                        GlobalClass.Setemail(email);
                        StartActivity(newScreen);
                    }

                    else
                    {
                        alert.SetTitle("Error");
                        alert.SetMessage("Please Enter Valid Data");
                        alert.SetPositiveButton("OK", alertOKButton);
                        alert.SetNegativeButton("Cancel", alertOKButton);
                        Dialog myDialog = alert.Create();
                        myDialog.Show();

                    }
                }
                
                };
        }
        
        private void alertOKButton(object sender, DialogClickEventArgs e)
        {
            System.Console.WriteLine("OK Button Pressed");
        }

        public bool isValidEmail(string email)
        {
            return Android.Util.Patterns.EmailAddress.Matcher(email).Matches();
        }
       
    }

    }