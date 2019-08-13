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

namespace RestaurantApp
{
    class Rname1
    {
        public string resname;
        public String restype;
        public String place;
         public int id;

        public Rname1(String myresName, String resplace, String type,int myresId)
        {
            resname = myresName;
            restype = type;
            place = resplace;
             id = myresId;

        }
    }
}