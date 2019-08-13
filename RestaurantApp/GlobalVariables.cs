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
    public static class GlobalVariables
    {
        private static string username;

        private static string password;

        public static void SetUsername(string uname)
        {
            username = uname;
        }

        public static string GetUsername()
        {
            return username;
        }

        public static void SetPassword(string pwd)
        {
            password = pwd;
        }

        public static string GetPassword()
        {
            return password;
        }



    }
}