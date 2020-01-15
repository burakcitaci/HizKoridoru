using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HizKoridoru.Models
{
   public class Route
   {
      [Key]
      public int ID { get; set; }
      /// <summary>
      /// 
      /// </summary>
      public string StartDestination { get; set; }

      /// <summary>
      /// 
      /// </summary>
      public string EndDestination { get; set; }

      /// <summary>
      /// 
      /// </summary>
      public string VehicleType { get; set; }

      /// <summary>
      /// 
      /// </summary>
      public string Distance { get; set; }

      /// <summary>
      /// 
      /// </summary>
      public string SpeedLimit { get; set; }

      /// <summary>
      /// 
      /// </summary>
      public string Date { get; set; }

      /// <summary>
      /// 
      /// </summary>
      public string BGColorHexCode { get; set; }

      /// <summary>
      /// 
      /// </summary>
      public bool IsBookmarked { get; set; }

      /// <summary>
      /// 
      /// </summary>
      public bool IsSelected { get; set; }

      public override bool Equals(object obj)
      {
         Route q = obj as Route;
         return q != null && q.ID == this.ID;
      }

      public override int GetHashCode()
      {
         return this.ID.GetHashCode();
      }

   }
}
