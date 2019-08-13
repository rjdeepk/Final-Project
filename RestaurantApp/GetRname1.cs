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
    class GetRname1 : BaseAdapter<Rname1>
    {
        List<Rname1> myResList;
        Activity localContext;

        public GetRname1(Activity myContext, List<Rname1> myres) : base()
        {
            localContext = myContext;
            myResList = myres;
        }


        public override Rname1 this[int position]
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

            Rname1 myObject = myResList[position];

            View myView = convertView; // re-use an existing view, if one is

            if (myView == null)
            {
                myView = localContext.LayoutInflater.Inflate(Resource.Layout.Restname1, null);

                myView.FindViewById<TextView>(Resource.Id.resName).Text = myObject.resname;
                myView.FindViewById<TextView>(Resource.Id.resPlace).Text = myObject.place;
                myView.FindViewById<ImageView>(Resource.Id.myresImg).SetImageResource(myObject.id);
                myView.FindViewById<TextView>(Resource.Id.resType).Text = myObject.restype;

            }

            return myView;
        }
    }
}