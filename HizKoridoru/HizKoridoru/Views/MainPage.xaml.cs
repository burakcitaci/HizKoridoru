using HizKoridoru.ViewModels;
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
      }

      private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
      {

      }

      private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
      {

      }
   }
}
