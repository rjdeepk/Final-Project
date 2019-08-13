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
    class Reviewlistclass
    {
        public string resname;
        public String review;
        public int rate;
        

        public Reviewlistclass(String myresName, String rvw, int rt1)
        {
            resname = myresName;
             review = rvw;
            rate = rt1;

        }
    }
}