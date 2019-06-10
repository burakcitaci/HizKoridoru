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

      private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
      {

      }

      private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
      {

      }

      private void ExtendedFrame_NormalPressed(object sender)
      {

      }

      private async void ExtendedFrame_LongPressed(object sender)
      {
         await Navigation.PushAsync(new RouteDeletePage((sender as ExtendedFrame).CurrentRoute));
      }
   }
}
