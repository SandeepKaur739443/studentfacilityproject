using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace StudentFacilityApp
{
    [Activity(Label = "ComplaintBox")]
    public class ComplaintBox : AppCompatActivity
    {
       // DBHelperClass myDB;
        Button myAddBtn;
        Button myEditBtn;
        Button myDelBtn;
        Button mycomplaintBtn;
        EditText myComplaint;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ComplaintBoxLayout);
            // Create your application here

            myAddBtn = FindViewById<Button>(Resource.Id.AddBtn);
            myEditBtn = FindViewById<Button>(Resource.Id.EditBtn);
            myDelBtn = FindViewById<Button>(Resource.Id.DelBtn);
            mycomplaintBtn = FindViewById<Button>(Resource.Id.sub_complainBtn);
            myComplaint = FindViewById<EditText>(Resource.Id.usercomplaint);
        }
    }
}