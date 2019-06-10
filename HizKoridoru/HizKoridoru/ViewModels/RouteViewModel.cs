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

namespace HizKoridoru.ViewModels
{
   public class RouteViewModel : BaseViewModel
   {
      public ObservableCollection<Route> Routes { get; set; }
      public Command LoadItemsCommand { get; set; }

      public static bool IsFirstFrame { get; set; }

      public RouteViewModel()
      {
         Title = "Browse";
         Routes = new ObservableCollection<Route>();
         Routes.Add(new Route { StartDestination = "Bati Hereke",
            EndDestination = "Dil Iskelesi",
            Date = DateTime.Today.ToShortDateString(),
            IsSelected = false});

         Routes.Add(new Route { StartDestination = "Tuzla",
            EndDestination = "Gebze",
            Date = DateTime.Today.ToShortDateString(),
            IsSelected = false });

         Routes.Add(new Route
         {
            StartDestination = "Kartal",
            EndDestination = "Samandira",
            Date = DateTime.Today.ToShortDateString(),
            IsSelected = false
         });
         ExtendedFrame.CurrentRoutes = Routes.ToList();
         LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
         IsSelected = true;
        
         MessagingCenter.Subscribe<NewRoute, Route>(this, "AddNewRoute", async (obj, item) =>
         {
            var newRoute = item as Route;
            Routes.Add(newRoute);
            await DataStore.AddItemAsync(newRoute);
         });
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
