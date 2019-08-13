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
    class Rname
    {
        public string moviename;
        public String typeofmovie;
        public String yrs;
        public int id;

        public Rname(String mymovieName, int mymovieImageId, String years, String type)
        {
            moviename = mymovieName;
            typeofmovie = type;
            yrs = years;
            id = mymovieImageId;
        }
    }
}