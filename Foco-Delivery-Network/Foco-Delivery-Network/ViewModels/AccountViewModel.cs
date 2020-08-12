using Foco_Delivery_Network.Models;
using Foco_Delivery_Network.Services;
using Plugin.FirebaseAuth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Foco_Delivery_Network.ViewModels
{
    class AccountViewModel : BaseViewModel
    {
        public string Username;
        public string Role;
        public AccountViewModel()
        {
            Title = "Account";       
        }
    }
}
