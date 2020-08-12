using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Foco_Delivery_Network.Models
{
    public enum RoleEnum
    {
        [Description("Dev")]
        Dev,
        [Description("Admin")]
        Admin,
        [Description("Driver")]
        Driver
    }
}
