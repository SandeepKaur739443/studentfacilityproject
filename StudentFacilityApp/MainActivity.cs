using Android.App;
using Android.OS;

using Android.Runtime;
using Android.Widget;
using System;
using Android.Views;
using Android.Content;


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
                var myName = myUserName.Text;
                var myPassword = myUserPasswd.Text;

                string userValue = myUserName.Text.ToString();
                var showResult = FindViewById<TextView>(Resource.Id.emailResult);
                var emailLoginResult = isValidEmail(userValue);

                System.Console.WriteLine("Username: ---- > " + myName);
                System.Console.WriteLine("Password: ---- > " + myPassword);
                // System.Console.WriteLine("Age: ---- > " + myage);
                myUserName.Error = "Plase enter Email Id";

                if (myName.Trim().Equals("") || myName.Length < 0)
                {

                    /* alert.SetTitle("Error");
                    alert.SetMessage("Please Enter Valid Data");
                    alert.SetPositiveButton("OK", alertOKButton);
                    alert.SetNegativeButton("Cancel", alertOKButton);
                    Dialog myDialog = alert.Create();
                    myDialog.Show(); */
                    //showResult.Text = "Please enter Email Id";
                   
                }
                else
                {
                    if (emailLoginResult == true)
                    {
                        showResult.Text = "Great...Email id is valid";
                    }

                    else
                    {
                        myUserName.Error = "Wrong Email Id";
                    }

                    //string userPasswordValue = myUserPasswd.Text.ToString();
                    var showpasswdResult = FindViewById<TextView>(Resource.Id.passwordResult);
                   

                    if (myPassword.Trim().Equals("") || myPassword.Length < 0)
                    {
                        showpasswdResult.Text = "Please enetr Password";
                    }

                    else
                    {
                        
                        myDB.SelectMydata();
                        Intent newScreen = new Intent(this, typeof(WelcomeScreen));
                        newScreen.PutExtra("userName", myName);
                        StartActivity(newScreen);

                    }

                }

            };
        }
        
        private void alertOKButton(object sender, DialogClickEventArgs e)
        {
            throw new NotImplementedException();
        }

        public bool isValidEmail(string email)
        {
            return Android.Util.Patterns.EmailAddress.Matcher(email).Matches();
        }
       


    }

       
    }