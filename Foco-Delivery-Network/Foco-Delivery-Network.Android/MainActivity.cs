using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Firebase;
using Xamarin.Forms;

namespace Foco_Delivery_Network.Droid
{
    [Activity(Label = "Foco_Delivery_Network", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            //var options = new FirebaseOptions.Builder()
            //    .SetApplicationId("1:798580476081:android:22073be21cc691e9c4ba90")
            //    .SetProjectId("focodeliveryproject")
            //    .SetApiKey("AIzaSyA1b0RhXFJ-LB6DfUnWCcH5JlvHGiFeAms")
            //    .SetDatabaseUrl("https://focodeliveryproject.firebaseio.com")
            //    .SetStorageBucket("focodeliveryproject.appspot.com").Build();

            //var fapp = FirebaseApp.InitializeApp(this, options);

            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}