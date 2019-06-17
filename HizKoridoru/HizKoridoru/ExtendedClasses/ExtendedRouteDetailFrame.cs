using HizKoridoru.Models;
using HizKoridoru.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xamarin.Forms;

namespace HizKoridoru.ExtendedClasses
{
   public class ExtendedRouteDetailFrame : Frame
   {
      /// <summary>
      /// 
      /// </summary>
      public bool IsFrameSelected { get; set; }

      /// <summary>
      /// 
      /// </summary>
      public static List<Route> CurrentRoutes { get; set; }

      /// <summary>
      /// 
      /// </summary>
      public Route CurrentRoute { get; set; }

      /// <summary>
      /// 
      /// </summary>
      public ExtendedRouteDetailFrame()
      {
         if (CurrentRoutes != null)
         {
            //if (CurrentRoutes.Count > 0)
            //{
            //   CurrentRoute = CurrentRoutes.First();
            //   CurrentRoutes.Remove(CurrentRoute);
            //}
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
         RouteViewModel.IsFirstFrame = true;
         HasShadow = false;
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="sender">Current frame with current route</param>
      public delegate void LongPress(object sender);
      public event LongPress LongPressed;
      public void InvokeLongPressedEvent(object sender)
      {
         LongPressed(sender);
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="sender"></param>
      public delegate void NormalPress(object sender);
      public event NormalPress NormalPressed;
      public void InvokeNormalPressedEvent(object sender)
      {
         NormalPressed(sender);
      }
   }
}

