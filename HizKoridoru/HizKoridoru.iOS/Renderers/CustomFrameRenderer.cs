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
      UILongPressGestureRecognizer longPressGestureRecognizer;
      UITapGestureRecognizer gestureRecognizer;

      protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
      {
         base.OnElementChanged(e);
         var extendedFrame = (Element as ExtendedFrame);
         if (extendedFrame == null)
            return;
       
         if (extendedFrame != null && extendedFrame.CurrentRoute != null)
         {
            gestureRecognizer = new UITapGestureRecognizer(() =>{
               if (gestureRecognizer.State == UIGestureRecognizerState.Ended)
               {
                 (Element as ExtendedFrame).InvokeNormalPressedEvent(extendedFrame);
                 extendedFrame.IsFrameSelected = false;
               }
               else
               {
                  extendedFrame.IsFrameSelected = true;
               }
            });

            longPressGestureRecognizer = new UILongPressGestureRecognizer(() => {
               if (gestureRecognizer.State == UIGestureRecognizerState.Failed)
               {
                  (Element as ExtendedFrame).InvokeLongPressedEvent(extendedFrame);
                  extendedFrame.IsFrameSelected = false;
               }
               else
               {
                  extendedFrame.IsFrameSelected = true;
               }
            });
            if (longPressGestureRecognizer != null && gestureRecognizer != null)
            {
               this.AddGestureRecognizer(longPressGestureRecognizer);
               this.AddGestureRecognizer(gestureRecognizer);
            }
            //if (longPressGestureRecognizer != null && gestureRecognizer != null)
            //{
            //   if (e.NewElement == null)
            //   {
            //      this.RemoveGestureRecognizer(longPressGestureRecognizer);
            //      this.RemoveGestureRecognizer(gestureRecognizer);
            //   }
            //   else if (e.OldElement == null)
            //   {
            //      this.AddGestureRecognizer(longPressGestureRecognizer);
            //      this.AddGestureRecognizer(gestureRecognizer);
            //   }

            //}
         }
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