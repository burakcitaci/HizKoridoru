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
	public partial class StartPage : ContentPage
	{
		public StartPage ()
		{
			InitializeComponent ();
		}

      private void ClickGestureRecognizer_Clicked(object sender, EventArgs e)
      {

      }

      private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
      {
         await Application.Current.MainPage.Navigation.PushAsync(new MainPage());
      }
   }
}