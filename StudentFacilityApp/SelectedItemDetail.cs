using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace StudentFacilityApp
{
    
    [Activity(Label = "SelectedItemDetail")]
    public class SelectedItemDetail : Activity
    {
        TextView Iname;
        TextView idesc;
        TextView iemail;
        ImageView II;
        string valueList;
        string v1;
        string v2;
        int v3;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.selectItem);
            Iname = FindViewById<TextView>(Resource.Id.TextItemName);
            idesc = FindViewById<TextView>(Resource.Id.TextItemdesc);
            iemail = FindViewById<TextView>(Resource.Id.TextItemeEmail);
            II =FindViewById<ImageView>(Resource.Id.im);

            valueList = Intent.GetStringExtra("name");
            v1 = Intent.GetStringExtra("desc");
            v2 = Intent.GetStringExtra("email");
            v3 = Convert.ToInt32(Intent.GetStringExtra("image"));
            // myUser = FindViewById<TextView>(Resource.Id.welcomeuser);
            Iname.Text = "Welcome," + valueList;
            idesc.Text = "Welcome," + v1;
            iemail.Text= "jhhj," +v2;
            II.SetImageResource(v3);
            // Create your application here
        }
    }
}