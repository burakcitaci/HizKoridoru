using HizKoridoru.ExtendedClasses;
using HizKoridoru.Models;
using HizKoridoru.ViewModels;
using HizKoridoru.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
      }

      protected override void OnAppearing()
      {
         base.OnAppearing();

         if (routeViewModel.Routes.Count == 0)
            routeViewModel.LoadItemsCommand.Execute(null);
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="sender"></param>
      private async void ExtendedFrame_NormalPressed(object sender)
      {
         ExtendedFrame extendedFrame = sender as ExtendedFrame;
         if(extendedFrame.CurrentRoute != null)
         {
            await Navigation.PushAsync(new RouteDetailPage((sender as ExtendedFrame).CurrentRoute));
         }
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="sender"></param>
      private async void ExtendedFrame_LongPressed(object sender)
      {
         try
         {
            //(sender as ExtendedFrame).BackgroundColor = Color.Gray;
            Route route = (sender as ExtendedFrame).CurrentRoute;
            if(route != null)
            {
               RouteDeletePage routeDeletePage = new RouteDeletePage(route);
               await Application.Current.MainPage.Navigation.PushAsync(routeDeletePage);
            }
            else
            {
               (sender as ExtendedFrame).IsEnabled = false;
            }
         }
         catch(Exception ex)
         {
            Debug.WriteLine(ex.Message);
         }
      }

      private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
      {
         await Application.Current.MainPage.Navigation.PushAsync(new NewRoutePage());
      }

      private async void SwipeGestureRecognizer_Swiped(object sender, SwipedEventArgs e)
      {
         Route route = (sender as ExtendedFrame).CurrentRoute;
         //if (route != null)
         //{
         //   RouteDeletePage routeDeletePage = new RouteDeletePage(route);
         //   await Application.Current.MainPage.Navigation.PushAsync(routeDeletePage);
         //}
         //else
         //{
         //   (sender as ExtendedFrame).IsEnabled = false;
         //}
         if(route != null)
         {
            routeViewModel.SelectedRoute = route;
            routeViewModel.LoadItemsCommand.Execute(null);
            routeViewModel.SelectedRoute = null;
         }
        
         //Veri bankasi üzerinden IsSelected kaydet?

      }
   }
}
