using Foco_Delivery_Network.Models;
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
    public partial class UserDetailPage : ContentPage
    {
        UserDetailViewModel viewModel;
        public UserDetailPage(UserDetailViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }

        public UserDetailPage()
        {
            InitializeComponent();

            var user = new User
            {
                Name = "Placeholder Name",
                Role = (int)RoleEnum.Driver
            };

            viewModel = new UserDetailViewModel(user);
            BindingContext = viewModel;
        }
    }
}