using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Database;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;


namespace RestaurantApp
{
    [Activity(Label = "newEditScreen")]
    public class NewEditScreen : Fragment
    {
        String u;
        String p;

        EditText user;
        EditText pass;
        EditText email;
        EditText cont;
        DBHelper ob;
        ICursor ic;
        Button editb;
        Button favb;
        public override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
        }
        // Create your application here
        
        
       

        readonly string[] myCategory = { "ShowReviews", "logout" };
        readonly Activity localContext;

        public NewEditScreen(Activity myContext)
        {
            localContext = myContext;

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment


            View myView = inflater.Inflate(Resource.Layout.newscreen, container, false);
           
           
            
            user = myView.FindViewById<EditText>(Resource.Id.userRegister);
            pass = myView.FindViewById<EditText>(Resource.Id.userPassword);
            email = myView.FindViewById<EditText>(Resource.Id.userEmail);
            cont = myView.FindViewById<EditText>(Resource.Id.userCon);
            editb = myView.FindViewById<Button>(Resource.Id.submitBtn);
            favb= myView.FindViewById<Button>(Resource.Id.submitBtn1);
            ob = new DBHelper(this.Activity);
            u = GlobalVariables.GetUsername();
            p = GlobalVariables.GetPassword();
            //System.Console.WriteLine("111111111111111111111111111111111 " + u);
            //System.Console.WriteLine("222222222222222222222222 " + p);
        


           
            user.Text = u;
            pass.Text = p;


            user.Enabled = false;
            pass.Enabled = false;
            email.Enabled = false;
            cont.Enabled = false;
            ic = ob.Update(user.Text, pass.Text);
            email.Text = ic.GetString(ic.GetColumnIndex("email"));
            cont.Text = ic.GetString(ic.GetColumnIndex("contact"));

            editb.Click += delegate
            {
                user.Enabled = false;
                pass.Enabled = true;
                email.Enabled = true;
                cont.Enabled = true;
                editb.Text = "Save";
                editb.Click += delegate
                {
                    ob.UpdateMyValues(user.Text, pass.Text, email.Text, cont.Text);
                    Intent newSc = new Intent(this.Activity, typeof(MainActivity));
                    StartActivity(newSc);
                };
            };
                favb.Click += delegate
                {
                    Intent newSc = new Intent(this.Activity, typeof(Favouritelist));
                    StartActivity(newSc);
                };
        return myView;
        }
    
    }
}