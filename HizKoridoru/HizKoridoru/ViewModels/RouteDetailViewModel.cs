using HizKoridoru.ViewModels.BaseViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
using HizKoridoru.Models;
using System.Threading.Tasks;
using System.Diagnostics;
using Xamarin.Forms;

namespace HizKoridoru.ViewModels
{
   public class RouteDetailViewModel : BaseViewModel
   {
      public ObservableCollection<Route> Routes { get; set; }

      public Command LoadItemsCommand { get; set; }

      public Command DeleteItemsCommand { get; set; }


      public Route CurrentRoute { get; set; }
      public RouteDetailViewModel(Route route)
      {
         Routes = new ObservableCollection<Route>();
         LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
         CurrentRoute = route;
         LoadItemsCommand.Execute(null);
         DeleteItemsCommand = new Command<Route>(async (model) => await ExecuteDeleteRouteCommand(model));
      }

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
               if(CurrentRoute != null &&
                  (item.StartDestination == CurrentRoute.StartDestination && 
                  item.EndDestination == CurrentRoute.EndDestination))
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

      async Task ExecuteDeleteRouteCommand(Route route)
      {
         if (IsBusy)
            return;

         IsBusy = true;

         try
         {
            //Routes.Clear();
            var items = await DataStore.DeleteItemAsync(route);
            //foreach (var item in items)
            //{
            //   if (route != null &&
            //      (item.StartDestination != route.StartDestination &&
            //      item.EndDestination != route.EndDestination))
            //   {
            //      Routes.Add(item);
            //   }
            //}
           
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
