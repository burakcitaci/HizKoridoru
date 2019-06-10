using HizKoridoru.Models;
using HizKoridoru.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Linq;
namespace HizKoridoru.ExtendedClasses
{
   public class ExtendedFrame : Frame
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
      public ExtendedFrame()
      {
         if (CurrentRoutes != null)
         {
            //Somehow Frame called one more than it exists in list.
            //First Frame is allways null
            if (RouteViewModel.IsFirstFrame)
            {
               if (CurrentRoutes.Count > 0)
               {
                  CurrentRoute = CurrentRoutes.First();
                  CurrentRoutes.Remove(CurrentRoute);
               }  
            }
            if(CurrentRoutes.Count == 0)
            {
               RouteViewModel.IsFirstFrame = false;
            }
         }
         RouteViewModel.IsFirstFrame = true;
         HasShadow = false;
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
