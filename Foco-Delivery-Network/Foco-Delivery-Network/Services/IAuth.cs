using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Foco_Delivery_Network.Services
{
    public interface IAuth
    {
        Task<string> LoginWithEmailPassword(string email, string password);
    }
}
