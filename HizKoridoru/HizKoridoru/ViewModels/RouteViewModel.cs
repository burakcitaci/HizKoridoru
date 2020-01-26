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

      public Command LoadBookmarkedItemsCommand { get; set; }

      public Command LoadBackgroundColorCommand { get; set; }

      public Command ResetItemsCommand { get; set; }
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
         ResetItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
         LoadBookmarkedItemsCommand = new Command<List<Route>>(async (routes) => await ExecuteBookmarkedItems(routes));
         LoadBackgroundColorCommand = new Command<Route>(async (route) => await ExecuteBackgroundColor(route));
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
         if (routes != null)
         {
            foreach (Route route in routes)
            {
               this.Routes.Remove(route);
            }
         }
      }

      async Task ExecuteResetItemsCommand()
      {
         if (IsBusy)
            return;

         IsBusy = true;

         Routes.Clear();
         var items = await DataStore.GetItemsAsync(true);
         items = items.OrderBy(x => x.IsBookmarked);
         foreach (var item in items)
         {
            //item.BGColorHexCode = "#52597F";
            Routes.Add(item);
         }

         IsBusy = false;
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
            items = items.OrderBy(x => x.IsBookmarked);
            foreach (var item in items)
            {
               //item.BGColorHexCode = "#52597F";
               if (this.SelectedRoute != null && this.SelectedRoute.StartDestination == item.StartDestination)
               {
                  item.IsSelected = true;
               }
               Routes.Add(item);
            }

            foreach(var frame in ExtendedCollectionView.ExtendedFrameList)
            {
               frame.BackgroundColor = Color.FromHex("#52597F");
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

      async Task ExecuteBookmarkedItems(List<Route> routes)
      {
         if (routes != null)
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
                  Route route = routes.Where(x => x.ID == item.ID)
                     .FirstOrDefault();
                  if (route != null)
                  {
                     item.IsBookmarked = !route.IsBookmarked;
                     await DataStore.UpdateItemAsync(item);
                  }

                  Routes.Add(item);
               }
               //await DataStore.UpdateItemAsync(Routes.ToList());
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

      async Task ExecuteBackgroundColor(Route route)
      {
         if (IsBusy)
         {
            return;
         }

         IsBusy = true;
         Routes.Clear();
         var items = await DataStore.GetItemsAsync(true);

         foreach (var item in items)
         {
            if (item.ID == route.ID)
            {

               //if (route.BGColorHexCode == "#900C3F")
               //{
               //   route.BGColorHexCode = "#52597F";
               //}
               //else
               //{
               //   route.BGColorHexCode = "#900C3F";
               //}
               Routes.Remove(item);
               Routes.Add(route);
               await DataStore.UpdateItemAsync(route);
            }
            else
            {
               Routes.Add(item);
            }
         }
         IsBusy = false;
      }
   }
}
