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
      #endregion

      public RouteViewModel()
      {
         Routes = new ObservableCollection<Route>();
         LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
         
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
