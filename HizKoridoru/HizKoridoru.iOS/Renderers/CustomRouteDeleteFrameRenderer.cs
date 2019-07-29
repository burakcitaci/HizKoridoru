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

//[assembly: ExportRenderer(typeof(ExtendedRouteDetailFrame), typeof(CustomRouteDeleteFrameRenderer))]
namespace HizKoridoru.iOS.Renderers
{
   public class CustomRouteDeleteFrameRenderer : FrameRenderer
   {

      MyTapGesture gestureRecognizer;



      protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
      {
         base.OnElementChanged(e);
         var extendedFrame = Element as ExtendedRouteDetailFrame;
         if (extendedFrame == null)
            return;

         if (extendedFrame.CurrentRoute == null)
            return;

         gestureRecognizer = new MyTapGesture() { ExtendedRouteDetailFrame = extendedFrame };
         gestureRecognizer.AddTarget(this, new ObjCRuntime.Selector("ResendTrigger:"));
        

         if (e.NewElement == null)
            this.RemoveGestureRecognizer(gestureRecognizer);
         if (e.OldElement == null)
            this.AddGestureRecognizer(gestureRecognizer);

      }

      [Export("ResendTrigger:")]
      private void LongPress(MyTapGesture myTapGesture)
      {
         //if (gestureRecognizer.State == UIGestureRecognizerState.Ended)
         //{

         //   (Element as ExtendedRouteDetailFrame).InvokeNormalPressedEvent((Element as ExtendedRouteDetailFrame));

         //}
      }

 
      public void ResendTrigger(UIGestureRecognizer sender)
      {
         System.Diagnostics.Debug.WriteLine("Triggered");
      }
   }

   class MyTapGesture : UITapGestureRecognizer
   {
      public ExtendedRouteDetailFrame ExtendedRouteDetailFrame { get; set; }
   }
}


