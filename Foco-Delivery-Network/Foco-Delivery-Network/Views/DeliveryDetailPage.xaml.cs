using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Foco_Delivery_Network.Models;
using Foco_Delivery_Network.ViewModels;
using System.ComponentModel;
using Plugin.FirebaseAuth;
using Foco_Delivery_Network.Services;

namespace Foco_Delivery_Network.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class DeliveryDetailPage : ContentPage
    {
        DeliveryDetailViewModel viewModel;

        private Button takeBtn, assignBtn, unassignBtn, completeBtn;

        public DeliveryDetailPage(DeliveryDetailViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;

            takeBtn = this.FindByName<Button>("take_btn");
            assignBtn = this.FindByName<Button>("assign_btn");
            unassignBtn = this.FindByName<Button>("unassign_btn");
            completeBtn = this.FindByName<Button>("complete_btn");

            ShowButtons();

        }

        public DeliveryDetailPage()
        {
            InitializeComponent();

            var delivery = new Delivery
            {
                MinInfo = "Placeholder Name",
                FullInfo = "Placeholder Comments."
            };

            viewModel = new DeliveryDetailViewModel(delivery);
            BindingContext = viewModel;
        }

        private void ShowButtons()
        {
            //TODO: move to observable properties, this way sucks
            takeBtn.IsVisible = false;
            assignBtn.IsVisible = false;
            unassignBtn.IsVisible = false;
            completeBtn.IsVisible = false;

            if (viewModel.Delivery.Status == DeliveryStatusEnum.PendingAssignment)
            {
                takeBtn.IsVisible = true;
            }
            else if (viewModel.Delivery.Status == DeliveryStatusEnum.Accepted)
            {
                unassignBtn.IsVisible = true;
                completeBtn.IsVisible = true;
            }
            else if (viewModel.Delivery.Status == DeliveryStatusEnum.Completed)
            {
                unassignBtn.IsVisible = true;
            }

            if (App.CurrentUser != null && App.CurrentUser.IsAdmin)
                assignBtn.IsVisible = true;
        }

        async void TakeDelivery(object sender, EventArgs args)
        {
            var delivery = viewModel.Delivery;

            delivery.TakenBySource = App.CurrentUser.Id;

            await viewModel.Update(delivery);
            ShowButtons();
        }

        async void AssignDelivery(object sender, EventArgs args)
        {
            throw new NotImplementedException();
        }

        async void UnassignDelivery(object sender, EventArgs args)
        {
            var delivery = viewModel.Delivery;

            delivery.TakenBySource = null;
            delivery.IsDelivered = false;

            await viewModel.Update(delivery);
            ShowButtons();
        }

        async void CompleteDelivery(object sender, EventArgs args)
        {
            var delivery = viewModel.Delivery;

            delivery.IsDelivered = true;

            await viewModel.Update(delivery);
            ShowButtons();
        }
    }
}