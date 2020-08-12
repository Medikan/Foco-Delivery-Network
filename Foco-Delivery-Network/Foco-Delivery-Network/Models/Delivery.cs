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

        private DeliveryStatusEnum _defaultEnum;

        [Id]
        public string Id { get; set; }
        [MapTo("minInfo")]
        public string MinInfo { get; set; }
        [MapTo("fullInfo")]
        public string FullInfo { get; set; }
        [ServerTimestamp(CanReplace = false)]
        public Timestamp CreatedOn { get; set; }
        [ServerTimestamp(CanReplace = true)]
        public Timestamp AssignedOn { get; set; }
        [MapTo("isAccepted")]
        public bool IsAccepted { get; set; }
        [MapTo("isDelivered")]
        public bool IsDelivered { get; set; }
        [MapTo("takenBy")]
        public string TakenBySource { get; set; }        
        public User TakenBy { get; set; }
        public DeliveryStatusEnum Status
        {
            get
            {
                if (!string.IsNullOrEmpty(TakenBySource) && !IsAccepted && !IsDelivered)
                    return DeliveryStatusEnum.PendingAcceptance;
                else if (!string.IsNullOrEmpty(TakenBySource) && IsAccepted && !IsDelivered)
                    return DeliveryStatusEnum.Accepted;
                else if (!string.IsNullOrEmpty(TakenBySource) && IsAccepted && IsDelivered)
                    return DeliveryStatusEnum.Completed;
                return DeliveryStatusEnum.PendingAssignment;
            }
            set
            {
                _defaultEnum = value;
            }
        }
    }
}
