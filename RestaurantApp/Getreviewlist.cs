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
    class Getreviewlist: BaseAdapter<Reviewlistclass>
    {
        List<Reviewlistclass> myResList;
        Activity localContext;

        public Getreviewlist(Activity myContext, List<Reviewlistclass> myres) : base()
        {
            localContext = myContext;
            myResList = myres;
        }


        public override Reviewlistclass this[int position]
        {
            get { return myResList[position]; }
        }



        public override int Count
        {
            get { return myResList.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {

            Reviewlistclass myObject = myResList[position];

            View myView = convertView; // re-use an existing view, if one is

            if (myView == null)
            {
                myView = localContext.LayoutInflater.Inflate(Resource.Layout.Showreviewlist, null);

                myView.FindViewById<TextView>(Resource.Id.resName).Text = myObject.resname;
                myView.FindViewById<TextView>(Resource.Id.reviews).Text = myObject.review;
                
                myView.FindViewById<TextView>(Resource.Id.rating).Text = myObject.rate.ToString();

            }

            return myView;
        }
    }
}