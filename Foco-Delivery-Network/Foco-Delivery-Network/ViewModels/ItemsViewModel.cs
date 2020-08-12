using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using Foco_Delivery_Network.Models;
using Foco_Delivery_Network.Views;
using Plugin.CloudFirestore;
using System.Reactive.Threading.Tasks;
using Plugin.CloudFirestore.Extensions;
using System.Reactive.Linq;
using Foco_Delivery_Network.Services;
using Plugin.FirebaseAuth;

namespace Foco_Delivery_Network.ViewModels
{
    //TODO: make base class for deliveries & users
    public class ItemsViewModel : BaseViewModel
    {
        public virtual new IDataStore<Delivery> DataStore => DependencyService.Get<IDataStore<Delivery>>();
        //TODO make dto, only grab necessary info
        public ObservableCollection<Delivery> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Browse";

            Items = new ObservableCollection<Delivery>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            //MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            //{
            //    var newItem = item as Item;
            //    Items.Add(newItem);
            //    await DataStore.AddItemAsync(newItem);
            //});
        }

        protected virtual async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();

                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
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