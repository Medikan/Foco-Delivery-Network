using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Auth;
using Foco_Delivery_Network.iOS;
using Foco_Delivery_Network.Services;
using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(AuthIOS))]
namespace Foco_Delivery_Network.iOS
{
    public class AuthIOS : IAuth
    {
        public async Task<string> LoginWithEmailPassword(string email, string password)
        {
            try
            {
                //TODO Throws keychain error, can't get it to work in simulator. Do workarounds until you have Apple Dev account and hopefully that fixes it
                var user = await Auth.DefaultInstance.SignInWithPasswordAsync(email, password);
                return await user.User.GetIdTokenAsync();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.StackTrace);
                return "";
            }

        }
    }
}