using System;
using System.Collections.Generic;
using System.Text;

namespace HizKoridoru.Models
{
   public class Route
   {
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
      public bool IsSelected { get; set; }

   }
}
