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
    class UserViewListOb
    {
        public string email;
        public string name;
        public int image;

        public UserViewListOb(string nameInfo, string ageInfo, int imgInfo)
        {
            email = nameInfo;
            name = ageInfo;
            image = imgInfo;
        }
    }
}
