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
    class GlobalClass
    {
        private static string mainemail;
        public static void Setemail(string emailid)
        {
            mainemail = emailid;

        }
        public static string GetEmail()
        {
            return mainemail;
        }
    }
}