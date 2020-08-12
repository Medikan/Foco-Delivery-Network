using System;
using System.Collections.Generic;
using System.Text;

namespace Foco_Delivery_Network.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        LogIn,
        Account,
        Users
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }

        public bool IsVisible
        {
            get
            {
                return (Id == MenuItemType.LogIn && App.CurrentUser == null) || App.CurrentUser != null;
            } 
        }
    }
}
