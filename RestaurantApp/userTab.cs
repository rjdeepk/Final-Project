using Android.App;
using Android.OS;
using Android.Widget;
using Android.Views;
using Android.Content;

namespace RestaurantApp
{
    [Activity(Label = "@string/app_name")]
    public class UserTab : Activity
    {
        Fragment[] _fragmentsArray;
        //private Fragment myContext;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            // Set our view from the "main" layout resource
            RequestWindowFeature(Android.Views.WindowFeatures.ActionBar);
            //enable navigation mode to support tab layout
            UserTab userTab = this;
            userTab.ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

            base.OnCreate(savedInstanceState);
            

            SetContentView(Resource.Layout.usertab);
            _fragmentsArray = new Fragment[]
            {
            new Profile(this,"res_list"),
            new Review(this),
            new NewEditScreen(this)
            };
            AddTabToActionBar("Home");//First Tab
             
            AddTabToActionBar("Review"); //Second Tab
            AddTabToActionBar("Profile");//Third Tab
        }
        void AddTabToActionBar(string tabTitle)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            Android.App.ActionBar.Tab tab = ActionBar.NewTab();
#pragma warning restore CS0618 // Type or member is obsolete
            tab.SetText(tabTitle);
           
            

            tab.SetIcon(Android.Resource.Drawable.IcInputAdd);

            tab.TabSelected += TabOnTabSelected;

            ActionBar.AddTab(tab);
        }



        void TabOnTabSelected(object sender, Android.App.ActionBar.TabEventArgs tabEventArgs)
        {
#pragma warning disable CS0618 // Type or member is obsolete
#pragma warning disable CS0618 // Type or member is obsolete
            Android.App.ActionBar.Tab tab = (Android.App.ActionBar.Tab)sender;
#pragma warning restore CS0618 // Type or member is obsolete
#pragma warning restore CS0618 // Type or member is obsolete

            //Log.Debug(Tag, "The tab {0} has been selected.", tab.Text);
            Fragment frag = _fragmentsArray[tab.Position];

            tabEventArgs.FragmentTransaction.Replace(Resource.Id.frameLayout11, frag);
        }

        



    }



}
