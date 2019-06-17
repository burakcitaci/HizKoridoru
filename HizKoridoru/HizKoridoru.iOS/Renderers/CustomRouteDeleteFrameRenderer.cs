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
     
      UITapGestureRecognizer gestureRecognizer;

      

      protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
      {
         base.OnElementChanged(e);
         var extendedFrame = (Element as ExtendedRouteDetailFrame);
         if (extendedFrame == null)
            return;

         if(gestureRecognizer == null)
         {
            gestureRecognizer = new UITapGestureRecognizer(LongPress);
         }
         if (extendedFrame != null && extendedFrame.CurrentRoute != null && 
            !string.IsNullOrEmpty(extendedFrame.CurrentRoute.StartDestination))
         {
          
            if (gestureRecognizer != null)
            {
               this.AddGestureRecognizer(gestureRecognizer);
            }
         }
      }

      private void LongPress()
      {
         if (gestureRecognizer.State == UIGestureRecognizerState.Ended)
         {

            (Element as ExtendedRouteDetailFrame).InvokeNormalPressedEvent((Element as ExtendedRouteDetailFrame));

         }
      }
   }

  
}