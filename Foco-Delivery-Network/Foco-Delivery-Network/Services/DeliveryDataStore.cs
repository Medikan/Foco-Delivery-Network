using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Foco_Delivery_Network.Models;
using Plugin.CloudFirestore;
using Xamarin.Forms;

namespace Foco_Delivery_Network.Services
{
    public class DeliveryDataStore : IDataStore<Delivery>
    {
        readonly List<Delivery> deliveries;

        private IDataStore<User> Users => DependencyService.Get<IDataStore<User>>();

        public DeliveryDataStore()
        {

        }

        public async Task<bool> AddItemAsync(Delivery item)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateItemAsync(Delivery item)
        {
            await CrossCloudFirestore.Current
                                    .Instance
                                    .GetCollection(Delivery.CollectionPath)
                                    .GetDocument(item.Id)
                                    .UpdateDataAsync(item);

            return true; //TODO Update to return true on success
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Delivery> GetItemAsync(string id)
        {
            var delivery = await CrossCloudFirestore.Current
                                     .Instance
                                     .GetCollection(Delivery.CollectionPath)
                                     .GetDocument(id)
                                     .GetDocumentAsync();

            return await FillUser(delivery.ToObject<Delivery>());
        }

        public async Task<IEnumerable<Delivery>> GetItemsAsync(bool forceRefresh = false)
        {
            var group = await CrossCloudFirestore.Current.Instance.GetCollectionGroup(Delivery.CollectionPath).GetDocumentsAsync();

            return await FillUsers(group.ToObjects<Delivery>());
        }

        private async Task<Delivery> FillUser(Delivery delivery)
        {
            delivery.TakenBy = await Users.GetItemAsync(delivery.TakenBySource);
            return delivery;
        }

        private async Task<List<Delivery>> FillUsers(IEnumerable<Delivery> deliveries)
        {
            List<Delivery> deliveryList = deliveries.ToList();

            foreach (var delivery in deliveryList)
            {
                if (delivery.TakenBySource != null)
                    delivery.TakenBy = await Users.GetItemAsync(delivery.TakenBySource) ?? null;
            }

            return deliveryList;
        }
    }
}