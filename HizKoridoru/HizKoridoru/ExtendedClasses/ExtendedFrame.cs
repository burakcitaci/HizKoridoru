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
            if (CurrentRoutes.Count > 0)
            {
               CurrentRoute = CurrentRoutes.First();
               CurrentRoutes.Remove(CurrentRoute);
            }
         }
         HasShadow = false;
      }

      /// <summary>
      /// Long Pressed event for frame
      /// </summary>
      /// <param name="sender">Current frame with current route</param>
      public delegate void LongPress(object sender);
      public event LongPress LongPressed;
      public void InvokeLongPressedEvent(object sender)
      {
         LongPressed(sender);
      }

      /// <summary>
      /// Normal Pressed Event for frame
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
