using HizKoridoru.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Linq;
using HizKoridoru.ViewModels;

namespace HizKoridoru.ExtendedClasses
{
   public class ExtendedViewCell : ViewCell
   {
      public bool IsFrameSelected { get; set; }

      public static List<Route> CurrentRoutes { get; set; }
      public Route CurrentRoute { get; set; }
      public ExtendedViewCell()
      {
         if (Device.RuntimePlatform == Device.Android)
         {
            RouteViewModel.IsFirstFrame = true;
         }

         if (RouteViewModel.IsFirstFrame)
         {
            if (CurrentRoutes.Count > 0)
            {
               CurrentRoute = CurrentRoutes.First();
               CurrentRoutes.Remove(CurrentRoute);
            }
         }

         if (CurrentRoutes.Count == 0)
         {
            RouteViewModel.IsFirstFrame = false;
         }
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
