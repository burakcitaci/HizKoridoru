using HizKoridoru.ExtendedClasses;
using HizKoridoru.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Xamarin.Forms;
using HizKoridoru.DB.ContextHelpers;
using HizKoridoru.DB.Contexts;

namespace HizKoridoru.Services.DataStores
{
   public class RouteDataStore : IRouteDataStore<Route>
   {
      private List<Route> routes;
      private RouteDBContextHelper<RouteDBContext> routeDBContextHelper;
      public RouteDBContextHelper<RouteDBContext> RouteDBContextHelper
      {
         get
         {
            if(routeDBContextHelper == null)
            {
               return new RouteDBContextHelper<RouteDBContext>();
            }
            else
            {
               return routeDBContextHelper;
            }
         }
      }

      public Command AddRoutesIfNotExists { get; set; }

      /// <summary>
      /// 
      /// </summary>
      public RouteDataStore()
      {
         routes = new List<Route>();

         if (Device.RuntimePlatform == Device.iOS)
         {
            routes.Add(new Route
            {
               StartDestination = string.Empty,
               EndDestination = string.Empty,
               Date = string.Empty,
               BGColorHexCode = "#52597F",
               IsSelected = false
            });

         }

         routes.Add(new Route
         {
            StartDestination = "Tuzla",
            EndDestination = "Gebze",
            BGColorHexCode = "#52597F",
            Date = DateTime.Today.ToShortDateString(),
            IsSelected = false
         });

         routes.Add(new Route
         {
            StartDestination = "Bati Hereke",
            EndDestination = "Dil Iskelesi",
            BGColorHexCode = "#52597F",
            IsBookmarked = true,
            Date = DateTime.Today.ToShortDateString(),
            IsSelected = false
         });


         routes.Add(new Route
         {
            StartDestination = "Kartal",
            EndDestination = "Samandira",
            BGColorHexCode = "#52597F",
            Date = DateTime.Today.ToShortDateString(),
            IsSelected = false
         });

         
        
         //Dört ekli, listede bir eksik
         var t = RouteDBContextHelper.GetRoutes().Result.ToList();
         t = t.OrderBy(x => x.IsBookmarked).ToList();
         if(t.Count == 0)
         {
            RouteDBContextHelper.AddOrUpdatePostsAsync(routes);
            t = RouteDBContextHelper.GetRoutes().Result.ToList().OrderBy(x=>x.IsBookmarked).ToList();
         }

         ExtendedFrame.CurrentRoutes = t;
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
         return await Task.FromResult(RouteDBContextHelper.GetRoutes().Result);
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="item"></param>
      /// <returns></returns>
      public async Task<bool> UpdateItemAsync(Route item)
      {
         await RouteDBContextHelper.UpdateRoute(item);
         return await Task.FromResult(true);
      }

      public async Task<bool> UpdateItemAsync(List<Route> routes)
      {
         await RouteDBContextHelper.AddOrUpdatePostsAsync(routes);
         return await Task.FromResult(true);
      }
   }
}
