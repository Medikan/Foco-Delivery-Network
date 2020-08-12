using Plugin.CloudFirestore.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Foco_Delivery_Network.Models
{
    public class User
    {
        public static string CollectionPath = "users";

        [Id]
        public string Id { get; set; }
        [MapTo("name")]
        public string Name { get; set; }
        public bool IsAdmin { 
            get 
            {
                return !((RoleEnum)Role == RoleEnum.Driver);
            } 
        }
        [MapTo("role")]
        public int Role { get; set; } //TODO: change to enum, need to convert int to enum
        [MapTo("isOnline")]
        public bool IsOnline { get; set; } 
        public bool IsAvailable { get; set; } 
        [MapTo("deliveriesTaken")]
        public int DeliveriesTaken { get; set; }
    }
}
