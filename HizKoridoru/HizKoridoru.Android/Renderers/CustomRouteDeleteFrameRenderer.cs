using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Content;
using Android.Views;
using HizKoridoru.Droid.Renderers;
using HizKoridoru.ExtendedClasses;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ExtendedRouteDetailFrame), typeof(CustomRouteDeleteFrameRenderer))]
namespace HizKoridoru.Droid.Renderers
{
   public class CustomRouteDeleteFrameRenderer : FrameRenderer
   {
      private readonly GestureDetector.SimpleOnGestureListener _listener;
      private readonly GestureDetector _detector;
      public CustomRouteDeleteFrameRenderer(Context context) : base(context)
      {

      }

      protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
      {
         base.OnElementChanged(e);
         if (e.NewElement == null)
         {
          
            this.Click -= CustomRouteDeleteFrameRenderer_Click;

         }

         if (e.OldElement == null)
         {

            this.Click += CustomRouteDeleteFrameRenderer_Click; ;
         }
         if (e.OldElement != null)
         {
            // Unsubscribe
         }

         if (e.NewElement != null)
         {

            if (e.NewElement != null && e.OldElement == null)
            {
               //this.SetBackgroundResource(Resource.Drawable.XMLFile1);
               //GradientDrawable drawable = (GradientDrawable)this.Background;
               //drawable.SetColor(Android.Graphics.Color.ParseColor("#FFFFFF"));
               //ViewGroup.SetBackgroundResource(Resource.Drawable.shadow);
            }
         }
      }

      private void CustomRouteDeleteFrameRenderer_Click(object sender, EventArgs e)
      {
         ExtendedRouteDetailFrame extendedFrame = ((ExtendedRouteDetailFrame)Element);
         extendedFrame.InvokeNormalPressedEvent(extendedFrame);
      }
   }
}