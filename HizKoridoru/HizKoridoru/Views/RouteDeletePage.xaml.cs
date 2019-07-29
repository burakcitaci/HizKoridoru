using HizKoridoru.ExtendedClasses;
using HizKoridoru.Models;
using HizKoridoru.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HizKoridoru.Views
{
   [XamlCompilation(XamlCompilationOptions.Compile)]
   public partial class RouteDeletePage : ContentPage
   {
      public static event EventHandler RouteDeleted;
      RouteDetailViewModel routeDetailViewModel;
      int SelectedFrameCounter = 0;
      Route CurrentRoute { get; set; }

      List<Route> CurrentRoutes = new List<Route>();
      public RouteDeletePage(Route route)
      {
         InitializeComponent();
         SelectedFrameCounter++;
         BindingContext = routeDetailViewModel = new RouteDetailViewModel(route);
         if (Device.RuntimePlatform == Device.iOS)
            this.extendedListView.IsEnabled = false;
         this.titleText.Text = SelectedFrameCounter + " secildi";
         this.CurrentRoute = route;
         this.CurrentRoutes.Add(CurrentRoute);
      }


      protected override void OnAppearing()
      {
         base.OnAppearing();
         //if (routeDetailViewModel.Routes.Count == 0)
         //   routeDetailViewModel.LoadItemsCommand.Execute(null);
      }

      private void ExtendedFrame_NormalPressed(object sender)
      {
         var extendedFrame = ((ExtendedRouteDetailFrame)sender);
         if (extendedFrame.CurrentRoute != null)
         {
            if (extendedFrame.BackgroundColor == Color.FromHex("#e0e0e0"))
            {
               extendedFrame.BackgroundColor = Color.White;
               CurrentRoutes.Remove(extendedFrame.CurrentRoute);
               SelectedFrameCounter--;
            }
            else
            {
               extendedFrame.BackgroundColor = Color.FromHex("#e0e0e0");
               SelectedFrameCounter++;
               CurrentRoutes.Add(extendedFrame.CurrentRoute);
            }
            if (SelectedFrameCounter == 0)
               this.titleText.Text = string.Empty;
            else
               this.titleText.Text = SelectedFrameCounter + " secildi";
         }
      }

      private void ExtendedFrame_LongPressed(object sender)
      {
         if (Device.RuntimePlatform == Device.Android)
         {

         }
      }


      private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
      {  
         if (RouteDeleted != null)
         {
            StringBuilder stringBuilder = new StringBuilder();
            foreach(Route route in this.CurrentRoutes)
            {
               stringBuilder.Append(route.StartDestination);
               stringBuilder.Append(" <--> ");
               stringBuilder.Append(route.EndDestination);
               stringBuilder.Append("\n");
            }

            bool answer = await DisplayAlert(stringBuilder.ToString(), 
               "Silmek istediginizden emin misiniz?", 
               "Evet", 
               "Hayir");
            if(answer)
               RouteDeleted(this.CurrentRoutes, e);
         }
         await Navigation.PopAsync();
      }
   }
}