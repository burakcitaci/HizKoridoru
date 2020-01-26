using HizKoridoru.Models;
using HizKoridoru.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HizKoridoru.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RouteDetailPage : ContentPage
	{
      public RouteDetailPage() { InitializeComponent(); }
      
		public RouteDetailPage (Route currentRoute)
		{
         NavigationPage.SetHasNavigationBar(this, false);
         InitializeComponent ();
         //this.Title = currentRoute.StartDestination + " <--> " + currentRoute.EndDestination;
         demo.Text = currentRoute.StartDestination;
         //this.Time.Text = DateTime.UtcNow.ToShortTimeString();
         TimeSpan time = TimeSpan.FromSeconds(2);
         this.Time.Text = time.ToString(@"hh\:mm\:ss");
         navigationBar.On<Android>().SetElevation(10);
      }
   }
}