using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foco_Delivery_Network.Models;
using Plugin.CloudFirestore;

namespace Foco_Delivery_Network.Services
{
    public class UserDataStore : IDataStore<User>
    {
        readonly List<Delivery> deliveries;

        public UserDataStore()
        {

        }

        public async Task<bool> AddItemAsync(User item)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateItemAsync(User item)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetItemAsync(string id)
        {
            var delivery = await CrossCloudFirestore.Current
                                     .Instance
                                     .GetCollection(User.CollectionPath)
                                     .GetDocument(id)
                                     .GetDocumentAsync();

            return delivery.ToObject<User>();
        }

        public async Task<IEnumerable<User>> GetItemsAsync(bool forceRefresh = false)
        {
            var group = await CrossCloudFirestore.Current.Instance.GetCollectionGroup(User.CollectionPath).GetDocumentsAsync();

            var items = group.ToObjects<User>();

            return items;
        }
    }
}