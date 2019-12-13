using HizKoridoru.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace HizKoridoru.DB.Contexts
{
   public class RouteDBContext : DbContext
   {
      public DbSet<Route> Routes { get; set; }

      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      {
         var dbPath = "SQLiteDataBaseDestionationNew.db";
         switch (Device.RuntimePlatform)
         {
            case Device.iOS:
            case Device.Android:
               dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), dbPath);
               break;
         }
         optionsBuilder.UseSqlite($"FileName={dbPath}");
      }
   }
}
