using Foco_Delivery_Network.Models;
using Foco_Delivery_Network.Services;
using Foco_Delivery_Network.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Foco_Delivery_Network.ViewModels
{
    class UsersListViewModel : ItemsViewModel
    {
        public new IDataStore<User> DataStore => DependencyService.Get<IDataStore<User>>();

        public new ObservableCollection<User> Items { get; set; }

        public UsersListViewModel()
        {
            Title = "Users";

            Items = new ObservableCollection<User>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        protected override async Task ExecuteLoadItemsCommand()
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
