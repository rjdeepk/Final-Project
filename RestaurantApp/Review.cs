using System;
using System.Collections.Generic;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
namespace RestaurantApp
{

    public class Review : Fragment
    {
        public String user1;
        Spinner RestaurantName;
        EditText reviews;
        TextView user;
        Button reviewBtn;
        Button reviewshowBtn;

        Android.Database.ICursor i;

        List<string> rsname = new List<string>();
        readonly Activity localContext;
        public Review(Activity myContext)
        {
            localContext = myContext;

        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View myView = inflater.Inflate(Resource.Layout.Review1, container, false);
            user = myView.FindViewById<TextView>(Resource.Id.logo);
            RestaurantName = myView.FindViewById<Spinner>(Resource.Id.spinner2);
            var ratingBar = myView.FindViewById<RatingBar>(Resource.Id.star);
            ratingBar.NumStars = 5;
            var subBtn = myView.FindViewById<Button>(Resource.Id.sbBtn);
            var txtRate = myView.FindViewById<TextView>(Resource.Id.ratStar);
            user.Text = GlobalVariables.GetUsername();
            txtRate.Text = "Rate: ";
            subBtn.Click += (s, e) =>
            {
                string ratingvalue = ratingBar.Rating.ToString();
                txtRate.Text = "Rate: " + ratingvalue;

            };

            reviews = myView.FindViewById<EditText>(Resource.Id.comment);
            reviewBtn = myView.FindViewById<Button>(Resource.Id.rbtn);
            reviewshowBtn = myView.FindViewById<Button>(Resource.Id.r1btn);
            DBHelper obj = new DBHelper(localContext);
            i = obj.ResViewdata();
            while (i.MoveToNext())
            {
                var a = i.GetString(i.GetColumnIndexOrThrow("rname"));
                rsname.Add(a);
            }
            Android.App.AlertDialog.Builder alert = new Android.App.AlertDialog.Builder(localContext);
            RestaurantName.Adapter = new ArrayAdapter(localContext, Android.Resource.Layout.SimpleListItem1, rsname);
            reviewBtn.Click += delegate
            {
                DBHelper obj1 = new DBHelper(localContext);
                
                user1 = user.Text;
                var value1 = RestaurantName.SelectedItem.ToString();
                var value2 = reviews.Text;
                var rt = txtRate.Text;
                if (value1.Equals(" ") || value1.Equals("") || value2.Equals(" ") || value2.Equals(""))
                {
                    alert.SetTitle("Error");
                    alert.SetMessage(" Please Enter A Value....");

                    alert.SetPositiveButton("OK", (senderAlert, args) =>
                    {

                        Toast.MakeText(localContext, "Please Enter a Valid! Value", ToastLength.Short).Show();
                    });
                    Dialog dialog = alert.Create();
                    dialog.Show();
                }

                else
                {
                    
                    obj1.InsertReview(user1,value1,value2,rt);

                    alert.SetMessage(" Review Added successfully");
                    alert.SetPositiveButton("OK", (senderAlert, args) =>
                    {

                        Toast.MakeText(localContext, "Thanks ", ToastLength.Short).Show();

                       
                    });
                    Dialog dialog = alert.Create();
                    dialog.Show();
                        

                    
                }
            
                };
                reviewshowBtn.Click += delegate
                {
                    Intent newScreen = new Intent(localContext, typeof(Showreview));
                    StartActivity(newScreen);
                };
                
                
            
                // Create your application here
                return myView;
            }
    }
    } 


