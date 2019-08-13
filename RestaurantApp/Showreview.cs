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
    [Activity(Label = "Showreview")]
    public class Showreview : Activity
    {
        ListView list;
        SearchView search;
        Android.Database.ICursor i;
        
       
        List<Reviewlistclass> myresList = new List<Reviewlistclass>();
        
        DBHelper ob;
        
        
        
        
        




        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Showreview);
            list = FindViewById<ListView>(Resource.Id.rlistView1);
            search = FindViewById<SearchView>(Resource.Id.searchView1);

            ob = new DBHelper(this);
            i = ob.ReviewViewdata();
            while (i.MoveToNext())
            {
                var restname = i.GetString(i.GetColumnIndexOrThrow("restname"));
                var rev = i.GetString(i.GetColumnIndexOrThrow("review"));
                int rt = i.GetInt(i.GetColumnIndexOrThrow("rating"));

                myresList.Add(new Reviewlistclass(restname, rev, rt));
                

            }
            var myAdatper = new Getreviewlist(this, myresList);

#pragma warning disable CS0618 // Type or member is obsolete
            list.SetAdapter(myAdatper);

            
           


           // spinnerView.ItemSelected += MyItemSelectedMethod;

            //search
            search.QueryTextChange += Mysearch;
        }


        public void Mysearch(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            var srch = e.NewText;
            System.Console.WriteLine("Search is:-" + srch);
        }
      


        // Create your application here
    }
}
