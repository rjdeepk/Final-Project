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
    [Activity(Label = "newRegisterScreen")]
    public class NewRegisterScreen : Activity
    {
        EditText name;
        EditText email;
        EditText password;
        EditText cont;
        Button submit;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.registrationForm);
            name = FindViewById<EditText>(Resource.Id.userRegister);
            email = FindViewById<EditText>(Resource.Id.userEmail);
            password = FindViewById<EditText>(Resource.Id.userPassword);
            cont = FindViewById<EditText>(Resource.Id.userCon);
            submit = FindViewById<Button>(Resource.Id.submitBtn);
            DBHelper obj = new DBHelper(this);

            Android.App.AlertDialog.Builder alert = new Android.App.AlertDialog.Builder(this);



            submit.Click += delegate {

                var value1 = name.Text;
                var value2 = email.Text;
                var value3 = password.Text;
                string value4 = cont.Text;
                if (value1.Equals(" ") || value1.Equals("") || value2.Equals(" ") || value2.Equals("") || value3.Equals(" ") || value3.Equals("") || value4.Equals(" ") || value4.Equals(""))
                {
                    alert.SetTitle("Error");
                    alert.SetMessage(" Please Enter A Value....");

                    alert.SetPositiveButton("OK", (senderAlert, args) => {

                        Toast.MakeText(this, "Please Enter a Valid! Value", ToastLength.Short).Show();
                    });
                    Dialog dialog = alert.Create();


                    dialog.Show();




                }
                else
                {
                    obj.InsertUser(value1, value2, value3, value4);

                    alert.SetMessage(" Registration successfull");
                    alert.SetPositiveButton("OK", (senderAlert, args) => {

                        Toast.MakeText(this, "well done ", ToastLength.Short).Show();
                    });
                    Dialog dialog = alert.Create();

                    dialog.Show();
                    Intent back = new Intent(this, typeof(MainActivity));
                    StartActivity(back);

                }

            };

        }
    }

}