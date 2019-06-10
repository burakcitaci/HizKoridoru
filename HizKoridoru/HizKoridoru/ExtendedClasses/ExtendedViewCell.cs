using HizKoridoru.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Linq;
namespace HizKoridoru.ExtendedClasses
{
   public class ExtendedViewCell : ViewCell
   {
      public bool IsFrameSelected { get; set; }

      public static List<Route> CurrentRoutes { get; set; }
      public Route CurrentRoute { get; set; }
      public ExtendedViewCell()
      {
         if (CurrentRoutes != null && CurrentRoutes.Count > 0)
         {
            CurrentRoute = CurrentRoutes.First();
            CurrentRoutes.Remove(CurrentRoute);

         }
         IsFrameSelected = false;
        
      }
      public delegate void LongPress(object sender);
      public event LongPress LongPressed;
      public void InvokeLongPressedEvent(object sender)
      {
         LongPressed(this);
      }

      public delegate void NormalPress(object sender);
      public event NormalPress NormalPressed;
      public void InvokeNormalPressedEvent()
      {
         NormalPressed(this);
      }
   }
}
