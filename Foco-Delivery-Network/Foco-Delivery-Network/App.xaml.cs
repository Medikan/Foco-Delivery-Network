using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Foco_Delivery_Network.Services;
using Foco_Delivery_Network.Views;
using Foco_Delivery_Network.Models;
using System.Threading.Tasks;

namespace Foco_Delivery_Network
{
    public partial class App : Application
    {
        public static User CurrentUser;


        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<DeliveryDataStore>();
            DependencyService.Register<UserDataStore>();
            MainPage = new LogInPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
