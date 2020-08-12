using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Foco_Delivery_Network.Models;

namespace Foco_Delivery_Network.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class NewItemPage : ContentPage
    {
        public Delivery Delivery { get; set; }

        public NewItemPage()
        {
            InitializeComponent();

            Delivery = new Delivery
            {
                MinInfo = "Brief description all users will see",
                FullInfo = "Longer description that only the assigned user will see"
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddDelivery", Delivery);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}