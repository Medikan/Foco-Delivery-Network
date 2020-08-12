using Foco_Delivery_Network.Models;
using Plugin.FirebaseAuth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Foco_Delivery_Network.Services
{
    public class UserService
    {
        //TODO: User persistant data structure to store current user info. *Can be assigned in App.xaml.cs
        public async Task<User> GetCurrentUser() =>
            await DependencyService.Get<IDataStore<User>>().GetItemAsync(CrossFirebaseAuth.Current.Instance.CurrentUser.Uid);
    }
}
