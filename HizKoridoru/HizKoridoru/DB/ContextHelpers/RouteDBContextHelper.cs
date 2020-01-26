using HizKoridoru.DB.Contexts;
using HizKoridoru.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HizKoridoru.DB.ContextHelpers
{
   public class RouteDBContextHelper <T> where T : RouteDBContext
   {
      public List<Route> SavedRoutes { get; set; }
      public RouteDBContext CrateContext()
      {
         RouteDBContext routeDBContext = (T)Activator.CreateInstance(typeof(T));
         routeDBContext.Database.EnsureCreated();
         routeDBContext.Database.Migrate();
         return routeDBContext;
      }

      public async Task AddOrUpdatePostsAsync(List<Route> routes)
      {
         using (var context = CrateContext())
         {
            // add posts that do not exist in the database
            var newPosts = routes.Where(route => context.Routes.Any(dbRoute => dbRoute.ID == route.ID) == false);
            await context.Routes.AddRangeAsync(newPosts);
            int result = await context.SaveChangesAsync();
            SavedRoutes = newPosts.ToList();
            //if(result == 1)
            //{
            //   SavedRoutes = newPosts.ToList();
            //}
         }
      }

      public async Task UpdateRoute(Route route)
      {
         using (var context = CrateContext())
         {
            context.Routes.Update(route);
            await context.SaveChangesAsync();
         }
      }
      /// <summary>
      /// 
      /// </summary>
      /// <returns></returns>
      public async Task<IEnumerable<Route>> GetRoutes()
      {
         using (var context = CrateContext())
         {
            var routes = context.Routes.ToList();
            return context.Routes.ToList();
         }
      }
   }
}
