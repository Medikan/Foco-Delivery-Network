using System;
using System.Diagnostics;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Foco_Delivery_Network.Models;
using Foco_Delivery_Network.Services;
using Plugin.FirebaseAuth;
using Xamarin.Forms;

namespace Foco_Delivery_Network.ViewModels
{
    public class DeliveryDetailViewModel : BaseViewModel
    {
        public new IDataStore<Delivery> DataStore => DependencyService.Get<IDataStore<Delivery>>();
        public Command LoadDeliverInfoCommand { get; set; }
        public Delivery Delivery { get; set; }
        public IObservable<Delivery> DeliveryObserver { get; set; }
        //TODO: Move current user to persistant data structure
        public User User { get; set; }
        public DeliveryDetailViewModel(Delivery delivery = null)
        {
            Title = "Delivery Info";

            LoadDeliverInfoCommand = new Command(async () => await ExecuteLoadDeliveryInfoCommand());

            Delivery = delivery;
        }

        public async Task Update(Delivery delivery)
        {
            await DataStore.UpdateItemAsync(delivery);

            LoadDeliverInfoCommand = new Command(async () => await ExecuteLoadDeliveryInfoCommand());
        }

        async Task ExecuteLoadDeliveryInfoCommand()
        {
            IsBusy = true;

            try
            {
                var delivery = await DataStore.GetItemAsync(Delivery.Id);
                var user = await DependencyService.Get<IDataStore<User>>().GetItemAsync(CrossFirebaseAuth.Current.Instance.CurrentUser.Uid); //TODO Remove once in persistant data structure

                Delivery = delivery;
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
