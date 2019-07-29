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
      public Route CurrentRoute { get; set; }

      /// <summary>
      /// Constructor
      /// </summary>
      /// <param name="route"></param>
      public RouteDetailViewModel(Route route)
      {
         Routes = new ObservableCollection<Route>();
         LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
         CurrentRoute = route;
         LoadItemsCommand.Execute(null);
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
   }
}
