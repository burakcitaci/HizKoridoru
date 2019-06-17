using HizKoridoru.ExtendedClasses;
using HizKoridoru.Models;
using HizKoridoru.ViewModels;
using HizKoridoru.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HizKoridoru
{
   public partial class MainPage : ContentPage
   {
      RouteViewModel routeViewModel;
      public MainPage()
      {
         InitializeComponent();        
         BindingContext = routeViewModel = new RouteViewModel();
         this.BackgroundColor = Color.White;
         //NavigationPage.SetHasNavigationBar(this, true); 
      }

      protected override void OnAppearing()
      {
         base.OnAppearing();

         if (routeViewModel.Routes.Count == 0)
            routeViewModel.LoadItemsCommand.Execute(null);
      }


      private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
      {

      }

      private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
      {

      }

      private async void ExtendedFrame_NormalPressed(object sender)
      {
         await Navigation.PushAsync(new RouteDetailPage((sender as ExtendedFrame).CurrentRoute));
      }

      private async void ExtendedFrame_LongPressed(object sender)
      {
         try
         {
            //(sender as ExtendedFrame).BackgroundColor = Color.Gray;
            Route route = (sender as ExtendedFrame).CurrentRoute;
            RouteDeletePage routeDeletePage = new RouteDeletePage(route);
            await Application.Current.MainPage.Navigation.PushAsync(routeDeletePage);
         }
         catch(Exception ex)
         {

         }
      }

      private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
      {

      }

      private void ExtendedListView_ItemTapped(object sender, ItemTappedEventArgs e)
      {

      }
   }
}
