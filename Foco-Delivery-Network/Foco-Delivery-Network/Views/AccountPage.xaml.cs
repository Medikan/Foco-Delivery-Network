using Foco_Delivery_Network.Models;
using Foco_Delivery_Network.Services;
using Foco_Delivery_Network.ViewModels;
using Plugin.FirebaseAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Foco_Delivery_Network.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountPage : ContentPage
    {
        AccountViewModel viewModel;
        public AccountPage()
        {
            BindingContext = viewModel = new AccountViewModel();
            InitializeComponent();
        }

        //TODO: Also set user IsOnline to false on logout
        void LogoutClick(object sender, EventArgs args)
        {
            CrossFirebaseAuth.Current.Instance.SignOut(); //TODO: Move to logout function
            App.CurrentUser = null; //TODO: Move to logout function
            App.Current.MainPage = new LogInPage();
        }
    }
}