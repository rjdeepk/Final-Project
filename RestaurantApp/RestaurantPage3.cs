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
    [Activity(Label = "RestaurantPage3")]
    public class RestaurantPage3 : Activity
    {
        TextView uname1;
        TextView rname1;
        Button favBtn1;
        Button myBtn1;
        Button bmyBtn1;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Canoe);
            uname1 = FindViewById<TextView>(Resource.Id.ur);
            rname1 = FindViewById<TextView>(Resource.Id.info);
            uname1.Text = GlobalVariables.GetUsername();
            favBtn1 = FindViewById<Button>(Resource.Id.favBtn);
            myBtn1 = FindViewById<Button>(Resource.Id.offerBtn);
            bmyBtn1 = FindViewById<Button>(Resource.Id.bck);

            Android.App.AlertDialog.Builder alert = new Android.App.AlertDialog.Builder(this);
            Android.App.AlertDialog.Builder alert1 = new Android.App.AlertDialog.Builder(this);
            String restname;
            restname = rname1.Text;
            favBtn1.Click += delegate
            {
                Dialog dialog = alert.Create();
                alert.SetTitle("Message");
                alert.SetMessage("Add as Favourite?");
                alert.SetPositiveButton("OK", (senderAlert, args) => {
                    DBHelper obj1 = new DBHelper(this);
                    obj1.InsertFavourite(uname1.Text, restname);
                    Toast.MakeText(this, "Added to Favourite List", ToastLength.Short).Show();
                });
                alert.SetNegativeButton("Cancel", (senderAlert, args) => {
                    Toast.MakeText(this, "Cancelled!", ToastLength.Short).Show();
                });
                dialog.Show();
            };


            bmyBtn1.Click += delegate
            {
                Intent newSc = new Intent(this, typeof(UserTab));
                StartActivity(newSc);
            };



            myBtn1.Click += delegate
            {

                Dialog dialog = alert1.Create();

                alert1.SetTitle("Offers");
                alert1.SetMessage("15% Off on all food items for kids");

                alert1.SetPositiveButton("Ok", (senderAlert, args) =>
                {

                    Toast.MakeText(this, "10% Off on all food items for kids", ToastLength.Short).Show();
                });
                dialog.Show();
            };
            // Create your application here
        }
    }
}