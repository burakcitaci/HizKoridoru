using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using HizKoridoru.ExtendedClasses;
using HizKoridoru.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ExtendedFrame), typeof(CustomFrameRenderer))]
namespace HizKoridoru.iOS.Renderers
{
   public class CustomFrameRenderer : FrameRenderer
   {
      ExtendedFrame extendedFrame;
      UILongPressGestureRecognizer longPressGestureRecognizer;
      protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
      {
         base.OnElementChanged(e);
         longPressGestureRecognizer = longPressGestureRecognizer ??
            new UILongPressGestureRecognizer(() =>
            {
               var extendedFrame = (Element as ExtendedFrame);
               if (extendedFrame != null)
               {
                  if (longPressGestureRecognizer.State == UIGestureRecognizerState.Began)
                  {
                     (Element as ExtendedFrame).InvokeLongPressedEvent(extendedFrame.CurrentRoute);
                     extendedFrame.IsFrameSelected = false;
                  }
                  else
                  {
                     extendedFrame.IsFrameSelected = true;
                  }
               }
            });

         if (longPressGestureRecognizer != null)
         {
            if (e.NewElement == null)
            {
               this.RemoveGestureRecognizer(longPressGestureRecognizer);
            }
            else if (e.OldElement == null)
            {
               this.AddGestureRecognizer(longPressGestureRecognizer);
            }
           
         }
         //if (e.NewElement != null && (e.NewElement as ExtendedFrame).CurrentRoute != null)
         //{

         //   if (e.OldElement == null)
         //   {

         //   }

         //}
      }
      //UILongPressGestureRecognizer longPressGestureRecognizer;
      //UIGestureRecognizer normalPressGestureRecognizer;
      //protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
      //{

      //   longPressGestureRecognizer = longPressGestureRecognizer ??
      //      new UILongPressGestureRecognizer(() =>
      //      {
      //         var extendedFrame = (Element as ExtendedFrame);
      //         if (extendedFrame != null)
      //         {
      //            if (extendedFrame.IsFrameSelected) { 
      //               (Element as ExtendedFrame).InvokeLongPressedEvent();
      //               extendedFrame.IsFrameSelected = false;
      //            }
      //            else
      //            {
      //               extendedFrame.IsFrameSelected = true;
      //            }
      //         }
      //      });

      //   if (longPressGestureRecognizer != null)
      //   {
      //      if (e.NewElement == null)
      //      {
      //         this.RemoveGestureRecognizer(longPressGestureRecognizer);
      //      }
      //      else if (e.OldElement == null)
      //      {
      //         this.AddGestureRecognizer(longPressGestureRecognizer);
      //      }
      //      longPressGestureRecognizer.State = UIGestureRecognizerState.Began;
      //   }
      //}

      //private void CustomFrameRenderer_LongPressed(object sender)
      //{

      //}
   }
}