using HizKoridoru.ExtendedClasses;
using HizKoridoru.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Xamarin.Forms;

namespace HizKoridoru.Services.DataStores
{
   public class RouteDataStore : IRouteDataStore<Route>
   {
      private List<Route> routes;
      /// <summary>
      /// 
      /// </summary>
      public RouteDataStore()
      {
         routes = new List<Route>();

         if(Device.RuntimePlatform == Device.iOS)
         {
            routes.Add(new Route
            {
               StartDestination = string.Empty,
               EndDestination = string.Empty,
               Date = string.Empty,
               IsSelected = false
            });

         }
         routes.Add(new Route
         {
            StartDestination = "Tuzla",
            EndDestination = "Gebze",
            Date = DateTime.Today.ToShortDateString(),
            IsSelected = false
         });

         routes.Add(new Route
         {
            StartDestination = "Bati Hereke",
            EndDestination = "Dil Iskelesi",
            Date = DateTime.Today.ToShortDateString(),
            IsSelected = false
         });


         routes.Add(new Route
         {
            StartDestination = "Kartal",
            EndDestination = "Samandira",
            Date = DateTime.Today.ToShortDateString(),
            IsSelected = false
         });

         //ExtendedViewCell.CurrentRoutes = routes.ToList();
         ExtendedFrame.CurrentRoutes = routes.ToList();
         //ExtendedRouteDetailFrame.CurrentRoutes = routes.ToList();
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="item"></param>
      /// <returns></returns>
      public async Task<bool> AddItemAsync(Route item)
      {
         routes.Add(item);

         return await Task.FromResult(true);
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      public async Task<bool> DeleteItemAsync(Route route)
      {
         foreach (var item in routes)
         {
            if (route != null &&
               (item.StartDestination == route.StartDestination &&
               item.EndDestination == route.EndDestination))
            {
               routes.Remove(item);
            }
         }

         return await Task.FromResult(true);
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      public Task<Route> GetItemAsync(string id)
      {
         throw new NotImplementedException();
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="forceRefresh"></param>
      /// <returns></returns>
      public async Task<IEnumerable<Route>> GetItemsAsync(bool forceRefresh = false)
      {
         List<Route> tempRoutes = new List<Route>();
         foreach (var item in routes)
         {
            tempRoutes.Add(item);
         }
         return await Task.FromResult(tempRoutes);
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="item"></param>
      /// <returns></returns>
      public Task<bool> UpdateItemAsync(Route item)
      {
         throw new NotImplementedException();
      }
   }
}
