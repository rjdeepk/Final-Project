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
    class Getfavouritelist: BaseAdapter<favouriteClass1>
    {
        List<favouriteClass1> myfavResList;
        Activity localContext;

        public Getfavouritelist(Activity myContext, List<favouriteClass1> myres) : base()
        {
            localContext = myContext;
            myfavResList = myres;
        }


        public override favouriteClass1 this[int position]
        {
            get { return myfavResList[position]; }
        }



        public override int Count
        {
            get { return myfavResList.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {

            favouriteClass1 myObject = myfavResList[position];

            View myView = convertView; // re-use an existing view, if one is

            if (myView == null)
            {
                myView = localContext.LayoutInflater.Inflate(Resource.Layout.favlistview, null);

                myView.FindViewById<TextView>(Resource.Id.favresName).Text = myObject.resname;
                myView.FindViewById<TextView>(Resource.Id.favresPlace).Text = myObject.place;
                myView.FindViewById<ImageView>(Resource.Id.fmyresImg).SetImageResource(myObject.id);
                myView.FindViewById<TextView>(Resource.Id.favresType).Text = myObject.restype;

            }

            return myView;
        }
    }
}
}