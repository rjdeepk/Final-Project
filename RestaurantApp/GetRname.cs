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
    class GetRname : BaseAdapter<Rname>
    {
        List<Rname> myUserList;
        Activity localContext;
        private Profile profile;

        public GetRname(Activity myContext, List<Rname> myUsers) : base()
        {
            localContext = myContext;
            myUserList = myUsers;
        }

        public GetRname(Profile profile, List<Rname> myUserList)
        {
            this.profile = profile;
            this.myUserList = myUserList;
        }

        public override Rname this[int position]
        {
            get { return myUserList[position]; }
        }

        

        public override int Count
        {
            get { return myUserList.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }



        public override View GetView(int position, View convertView, ViewGroup parent)
        {

            Rname myObject = myUserList[position];

            View myView = convertView; // re-use an existing view, if one is

            if (myView == null)
            {
                myView = localContext.LayoutInflater.Inflate(Resource.Layout.Profile, null);

                myView.FindViewById<TextView>(Resource.Id.mymovieName).Text = myObject.moviename;
                myView.FindViewById<TextView>(Resource.Id.movieyear).Text = myObject.yrs;
                myView.FindViewById<ImageView>(Resource.Id.mymovieImage).SetImageResource(myObject.id);
                myView.FindViewById<TextView>(Resource.Id.movieyear).Text = myObject.typeofmovie;
            }

            return myView;
        }
    }
}