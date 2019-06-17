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
      RouteDetailViewModel routeDetailViewModel;
      int SelectedFrameCounter = 0;
      Route CurrentRoute { get; set; }
      public RouteDeletePage(Route route)
      {
         InitializeComponent();
         SelectedFrameCounter++;
         BindingContext = routeDetailViewModel = new RouteDetailViewModel(route);
         this.extendedListView.IsEnabled = false;
         this.titleText.Text = SelectedFrameCounter + " secildi";
         this.CurrentRoute = route;
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
               SelectedFrameCounter--;
            }
            else
            {
               extendedFrame.BackgroundColor = Color.FromHex("#e0e0e0");
               SelectedFrameCounter++;
            }
            if (SelectedFrameCounter == 0)
               this.titleText.Text = string.Empty;
            else
               this.titleText.Text = SelectedFrameCounter + " secildi";
         }
      }

      private void ExtendedFrame_LongPressed(object sender)
      {

      }


      private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
      {
         routeDetailViewModel.DeleteItemsCommand.Execute(this.CurrentRoute);
         var source = (extendedListView.ItemsSource as ObservableCollection<Route>).ToList();
         source.RemoveAt(1);
      }
   }
}