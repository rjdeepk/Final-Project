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
    [Activity(Label = "FavoriteActivity1")]
    public class FavoriteActivity1 : Activity
    {
        readonly Button fav;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            /*fav = FindViewById<Button>(Resource.Id.favBtn);
            Android.App.AlertDialog.Builder alert = new Android.App.AlertDialog.Builder(this);
            fav.Click += delegate
            {

                user.Text = user1;
                var value1 = RestaurantName.SelectedItem.ToString();
                var value2 = reviews.Text;

                if (value1.Equals(" ") || value1.Equals("") || value2.Equals(" ") || value2.Equals(""))
                {
                    alert.SetTitle("Error");
                    alert.SetMessage(" Please Enter A Value....");

                    alert.SetPositiveButton("OK", (senderAlert, args) =>
                    {

                        Toast.MakeText(this, "Please Enter a Valid! Value", ToastLength.Short).Show();
                    });
                    Dialog dialog = alert.Create();
                    dialog.Show();
                }

                else
                {
                    DBHelper obj1 = new DBHelper(this);
                    //obj1.InsertValue1(user1, value1, value2);

                    alert.SetMessage(" Review Added successfully");
                    alert.SetPositiveButton("OK", (senderAlert, args) =>
                    {

                        Toast.MakeText(this, "Thanks ", ToastLength.Short).Show();


                    });
                    Dialog dialog = alert.Create();
                    dialog.Show();
                    Intent back = new Intent(this, typeof(UserTab));
                    StartActivity(back);


                }

            };
            // Create your application here
        }*/
        }
    }
}