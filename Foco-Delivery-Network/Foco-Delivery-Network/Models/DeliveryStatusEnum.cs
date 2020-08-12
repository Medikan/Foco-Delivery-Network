using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Foco_Delivery_Network.Models
{
    public enum DeliveryStatusEnum
    {
        [Description("PendingAssignment")]
        PendingAssignment,
        [Description("PendingAcceptance")]
        PendingAcceptance,
        [Description("Accepted")]
        Accepted,
        [Description("Completed")]
        Completed
    }
}
