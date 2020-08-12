using Foco_Delivery_Network.Models;
using Foco_Delivery_Network.Services;
using Foco_Delivery_Network.ViewModels;
using Plugin.FirebaseAuth;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Foco_Delivery_Network.Views
{
    public class UserDetailViewModel : BaseViewModel
    {
        public new IDataStore<User> DataStore => DependencyService.Get<IDataStore<User>>();
        public Command LoadUserInfoCommand { get; set; }
        public User User { get; set; }
        public IObservable<Delivery> DeliveryObserver { get; set; }
        public UserDetailViewModel(User user = null)
        {
            Title = "User Info";

            LoadUserInfoCommand = new Command(async () => await ExecuteLoadUserInfoCommand());

            User = user;
        }

        public async Task Update(User user)
        {
            await DataStore.UpdateItemAsync(user);

            LoadUserInfoCommand = new Command(async () => await ExecuteLoadUserInfoCommand());
        }

        async Task ExecuteLoadUserInfoCommand()
        {
            IsBusy = true;

            try
            {
                var user = await DataStore.GetItemAsync(User.Id);

                User = user;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}