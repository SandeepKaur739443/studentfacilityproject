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
    public class UserObject
    {
        public String name;
        public String age;
        public int image;

        public UserObject(string nameInfo)
        {
            name = nameInfo;
           // age = ageInfo;
           // image = imgInfo;
        }
    }
}