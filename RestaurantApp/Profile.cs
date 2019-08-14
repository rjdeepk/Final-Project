using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace RestaurantApp
{
    public class Profile : Fragment
    {
        readonly string res_list;
        public String user1;
        ListView resllistview;
        readonly Activity localContext;
        SearchView search;
        TextView user;
        Android.Database.ICursor i;
        public Profile(Activity myContext, string list1)
        {
            localContext = myContext;
            res_list = list1;

        }
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }
        List<Rname1> myresList = new List<Rname1>();

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View myView = inflater.Inflate(Resource.Layout.Profile, container, false);
            resllistview = myView.FindViewById<ListView>(Resource.Id.reslistviewid);
            user = myView.FindViewById<TextView>(Resource.Id.logo);
            user.Text = GlobalVariables.GetUsername();
            search = myView.FindViewById<SearchView>(Resource.Id.searchView2);
            DBHelper obj = new DBHelper(localContext);
            search.QueryTextChange += Mysearch;
            i = obj.ResViewdata();
            int e=0;
            while (i.MoveToNext())
            {
                var restname = i.GetString(i.GetColumnIndexOrThrow("rname"));
                var restplace= i.GetString(i.GetColumnIndexOrThrow("rplace"));
                var resttype= i.GetString(i.GetColumnIndexOrThrow("rtype"));
                var id = i.GetInt(i.GetColumnIndexOrThrow("rimage"));

                myresList.Add(new Rname1(restname, restplace,resttype,id));
                
                e++;
            }

            // Get our button from the layout resource,

            var myAdatper = new GetRname1(localContext, myresList);

#pragma warning disable CS0618 // Type or member is obsolete
            resllistview.SetAdapter(myAdatper);

            resllistview.ItemClick += OnItemClick;

            return myView;

        }
        private void OnItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {

            var index = e.Position;
            int ind = index;
            if (index==0)
            {
                
                Intent newSc = new Intent(this.Activity, typeof(RestaurantPage5));
                StartActivity(newSc);
            }
            if (index == 1)
            {
                Intent newSc = new Intent(this.Activity, typeof(RestaurantPage1));
                StartActivity(newSc);
            }
            if (index == 2)
            {
                Intent newSc = new Intent(this.Activity, typeof(RestaurantPage4));
                StartActivity(newSc);
            }
            if (index == 3)
            {
                Intent newSc = new Intent(this.Activity, typeof(RestaurantPage2));
                StartActivity(newSc);
            }
            if (index == 4)
            {
                Intent newSc = new Intent(this.Activity, typeof(RestaurantPage3));
                StartActivity(newSc);
            }
        }
        public void Mysearch(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            var srch = e.NewText;

            srch = srch.ToLower();
            if (string.IsNullOrWhiteSpace(srch))
            {
                resllistview.Adapter = new GetRname1(localContext, myresList); return;
            }
            List<Rname1> filteredList = new List<Rname1>();

            filteredList.AddRange(myresList.Where(x => x.place.ToLower().Contains(srch) || x.resname.ToLower().Contains(srch) || x.restype.ToLower().Contains(srch)));
            resllistview.Adapter = new GetRname1(localContext, filteredList);

        }
       
    }
}