using HizKoridoru.ExtendedClasses;
using HizKoridoru.HelperClasses;
using HizKoridoru.Models;
using HizKoridoru.ViewModels.BaseViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Xamarin.Forms;
using HizKoridoru.Views;

namespace HizKoridoru.ViewModels
{
   public class RouteViewModel : BaseViewModel
   {
      #region Public Properties
      /// <summary>
      /// 
      /// </summary>
      public ObservableCollection<Route> Routes { get; set; }

      /// <summary>
      /// 
      /// </summary>
      public Command LoadItemsCommand { get; set; }

      /// <summary>
      /// 
      /// </summary>
      public static bool IsFirstFrame { get; set; }

      public Route SelectedRoute { get; set; }
      #endregion

      public RouteViewModel()
      {
         Routes = new ObservableCollection<Route>();
         this.ExecuteLoadItemsCommand();
         LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
         RouteDeletePage.RouteDeleted += RouteDeletePage_RouteDeleted;
         MessagingCenter.Subscribe<NewRoutePage, Route>(this, "AddNewRoute", async (obj, item) =>
         {
            var newRoute = item as Route;
            Routes.Add(newRoute);
            await DataStore.AddItemAsync(newRoute);
         });
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void RouteDeletePage_RouteDeleted(object sender, EventArgs e)
      {
         List<Route> routes = sender as List<Route>;
         if(routes != null)
         {
            foreach(Route route in routes)
            {
               this.Routes.Remove(route);
            }
         }
      }

      /// <summary>
      /// 
      /// </summary>
      /// <returns></returns>
      async Task ExecuteLoadItemsCommand()
      {
         if (IsBusy)
            return;

         IsBusy = true;

         try
         {
            Routes.Clear();
            var items = await DataStore.GetItemsAsync(true);
            foreach (var item in items)
            {
               if(this.SelectedRoute != null && this.SelectedRoute.StartDestination == item.StartDestination)
               {
                  item.IsSelected = true;
               }
               Routes.Add(item);
            }
         }
         catch (Exception ex)
         {
            Debug.WriteLine(ex);
         }
         finally
         {
            IsBusy = false;
         }
      }
   }
}
