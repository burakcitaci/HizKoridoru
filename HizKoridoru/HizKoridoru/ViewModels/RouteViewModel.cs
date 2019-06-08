using HizKoridoru.HelperClasses;
using HizKoridoru.Models;
using HizKoridoru.ViewModels.BaseViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HizKoridoru.ViewModels
{
   public class RouteViewModel : BaseViewModel
   {
      public ObservableCollection<Route> Items { get; set; }
      public Command LoadItemsCommand { get; set; }

      public RouteViewModel()
      {
         Title = "Browse";
         Items = new ObservableCollection<Route>();
         LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
         IsSelected = true;
        
         MessagingCenter.Subscribe<NewRoute, Route>(this, "AddNewRoute", async (obj, item) =>
         {
            var newRoute = item as Route;
            Items.Add(newRoute);
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
            Items.Clear();
            var items = await DataStore.GetItemsAsync(true);
            foreach (var item in items)
            {
               Items.Add(item);
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
