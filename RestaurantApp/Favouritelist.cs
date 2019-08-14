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
    [Activity(Label = "Favouritelist")]
    public class Favouritelist : Activity
    {
        ListView list;
        SearchView search;
        List<string> rsname1 = new List<string>();
        ArrayAdapter myadp;
        DBHelper ob;
        
        Android.Database.ICursor i;
        readonly string[] myCategory = { "logout" };

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Favorite1);
            list = FindViewById<ListView>(Resource.Id.favlistviewid);
            search = FindViewById<SearchView>(Resource.Id.searchView2);

            ob = new DBHelper(this);
            
            i = ob.FavViewdata();
            while (i.MoveToNext())
            {
                var a = i.GetString(i.GetColumnIndexOrThrow("usrname"));
                rsname1.Add(a);
            }
            myadp = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, rsname1);
            list.Adapter = myadp;
            
            //search
            
        
        search.QueryTextChange += Mysearch;
        }


    public void Mysearch(object sender, SearchView.QueryTextChangeEventArgs e)
    {
        var srch = e.NewText;
        System.Console.WriteLine("Search is:-" + srch);
    }






}

        // Create your application here
    }

