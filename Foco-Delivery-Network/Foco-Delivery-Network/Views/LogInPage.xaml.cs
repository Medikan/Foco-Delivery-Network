using Foco_Delivery_Network.Models;
using Foco_Delivery_Network.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Foco_Delivery_Network.Views
{
	[DesignTimeVisible(true)]
    public partial class LogInPage : ContentPage
    {
        IAuth auth;
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        public LogInPage()
        {
            InitializeComponent();
            auth = DependencyService.Get<IAuth>();
        }

        async void LoginClicked(object sender, EventArgs args)
        {
            try
            {
                //string Token = await auth.LoginWithEmailPassword(EmailInput.Text, PasswordInput.Text);
                string Token = await auth.LoginWithEmailPassword("devtest@devtest.com", "devtest");
                if (Token != "")
                {
                    App.CurrentUser = await new UserService().GetCurrentUser();
                    App.Current.MainPage = new MainPage();
                }
                else
                {
                    ShowError();
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Authentication Failed", ex.Message, "OK");
            }
        }

        async private void ShowError()
        {
            await DisplayAlert("Authentication Failed", "E-mail or password are incorrect. Try again!", "OK");
        }
    }
}