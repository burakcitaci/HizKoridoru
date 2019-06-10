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

[assembly: ExportRenderer(typeof(ExtendedViewCell), typeof(CustomViewCellRenderer))]
namespace HizKoridoru.iOS.Renderers
{
   public class CustomViewCellRenderer : ViewCellRenderer
   {
     
     
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