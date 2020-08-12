using Plugin.CloudFirestore;
using Plugin.CloudFirestore.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Foco_Delivery_Network.Models
{
    public class Delivery
    {
        public static string CollectionPath = "deliveries";

        [Id]
        public string Id { get; set; }
        [MapTo("address")]
        public string Address { get; set; }
        [MapTo("city")]
        public string City { get; set; }
        [MapTo("comments")]
        public string Comments { get; set; }
        [ServerTimestamp(CanReplace = false)]
        public Timestamp CreatedOn { get; set; }
        [MapTo("email")]
        public string Email { get; set; }
        [MapTo("isDelivered")]
        public bool IsDelivered { get; set; }
        [MapTo("items")]
        public string Items { get; set; }
        [MapTo("name")]
        public string Name { get; set; }
        [MapTo("phone")]
        public string Phone { get; set; }
        [MapTo("state")]
        public string State { get; set; }
        [MapTo("takenBy")]
        public string TakenBySource { get; set; }
        public User TakenBy { get; set; }
        [MapTo("zip")]
        public string Zip { get; set; }
    }
}
