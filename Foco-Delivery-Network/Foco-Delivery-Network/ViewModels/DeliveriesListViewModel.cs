using Foco_Delivery_Network.Models;
using Foco_Delivery_Network.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Foco_Delivery_Network.ViewModels
{
    class DeliveriesListViewModel : ItemsViewModel
    {
        public new IDataStore<Delivery> DataStore => DependencyService.Get<IDataStore<Delivery>>();

        public DeliveriesListViewModel()
        {
            Title = "Deliveries";
        }
    }
}
