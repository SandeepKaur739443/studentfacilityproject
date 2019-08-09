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
    class ConfessionUserObj
    {
        public String name;
        public string date;


        public ConfessionUserObj(string nameInfo, string dateInfo)
        {
            name = nameInfo;
            date = dateInfo;

        }
    }
}