using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;

namespace RestaurantApp
{
    [Activity(Label = "@string/app_name",  MainLauncher = true)]
    public class MainActivity : Activity
    {
        EditText myUserName;
        EditText myPassword;

        Button myBtn;
        Button registerBtn;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            myUserName = FindViewById<EditText>(Resource.Id.user);
            myPassword = FindViewById<EditText>(Resource.Id.password);
            myBtn = FindViewById<Button>(Resource.Id.loginBtn);
            registerBtn = FindViewById<Button>(Resource.Id.signup);
            DBHelper obj = new DBHelper(this);
            Android.App.AlertDialog.Builder alert = new Android.App.AlertDialog.Builder(this);
            obj.InsertRestaurant("Alo", "Queen Street", "Salad and Subway", Resource.Drawable.alo);





            myBtn.Click += delegate {

                var value1 = myUserName.Text;
                var value2 = myPassword.Text;
                if (value1.Equals(" ") || value1.Equals("") || value2.Equals(" ") || value2.Equals(""))
                {
                    alert.SetTitle("Error Message");
                    alert.SetMessage(" Please Enter the valid Username and password....");
                    alert.Create();
                    
                    alert.SetPositiveButton("OK", (senderAlert, args) => {
                        
                        Toast.MakeText(this, "Please Enter a Valid! Value", ToastLength.Short).Show();
                    });
                    alert.SetNegativeButton("Cancel", (senderAlert, args) => {
                        Toast.MakeText(this, "Cancelled!", ToastLength.Short).Show();
                    });

                    Dialog dialog = alert.Create();


                    dialog.Show();





                }
                else
                {

                    bool userExist = obj.SelectMyValues(value1, value2);
                    if (userExist)
                    {
                        Intent newScreen = new Intent(this, typeof(UserTab));
                        GlobalVariables.SetUsername(value1);
                        GlobalVariables.SetPassword(value2);
                        newScreen.PutExtra("userName", value1);
                        newScreen.PutExtra("userPassword", value2);


                        StartActivity(newScreen);
                    }
                }
                
                
                
            };
            registerBtn.Click += delegate
            {
                Intent registerScreen = new Intent(this, typeof(NewRegisterScreen));
                StartActivity(registerScreen);
            };

        }
    }
}