using HizKoridoru.ExtendedClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HizKoridoru.Views
{
   [XamlCompilation(XamlCompilationOptions.Compile)]
   public partial class CurrentRoutes : ContentPage
   {
      private bool FrameLongPressed;
      public CurrentRoutes()
      {
         InitializeComponent();
      }

      private async void ExtendedFrame_NormalPressed(object sender)
      {
         if (FrameLongPressed)
         {
            if((((ExtendedFrame)sender).Children.First() as Frame).BackgroundColor == Color.Green)
            {
               (((ExtendedFrame)sender).Children.First() as Frame).BackgroundColor = Color.FromHex("#52597F");
            }
            else
            {
               (((ExtendedFrame)sender).Children.First() as Frame).BackgroundColor = Color.Green;
            }
         }
         
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="sender"></param>
      private async void ExtendedFrame_LongPressed(object sender)
      {
         this.favoriteIcon.IsVisible = !this.favoriteIcon.IsVisible;
         this.bookmarkIcon.IsVisible = !this.bookmarkIcon.IsVisible;
         this.deleteIcon.IsVisible = !this.deleteIcon.IsVisible;
         string dest = ((ExtendedFrame)sender).CurrentRoute.StartDestination;
         (((ExtendedFrame)sender).Children.First() as Frame).BackgroundColor = Color.Green;
         this.FrameLongPressed = true;
         this.backgroundBoxView.BackgroundColor = Color.LightGray;
         this.navigationBar.BackgroundColor = Color.FromHex("#2C3359");

      }

      private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
      {
         await Application.Current.MainPage.Navigation.PopAsync();
      }
   }
}