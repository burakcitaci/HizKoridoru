using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using HizKoridoru.Droid.Renderers;
using HizKoridoru.ExtendedClasses;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ExtendedFrame), typeof(CustomFrameRenderer))]
namespace HizKoridoru.Droid.Renderers
{
   public class CustomFrameRenderer : FrameRenderer
   {
      private readonly GestureDetector.SimpleOnGestureListener _listener;
      private readonly GestureDetector _detector;
      public CustomFrameRenderer(Context context) : base(context)
      {
         _listener = new GestureDetector.SimpleOnGestureListener();
         _detector = new GestureDetector(context, _listener) { IsLongpressEnabled = true };
      }

      protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Frame> e)
      {
         base.OnElementChanged(e);

         if (e.NewElement == null)
         {
            this.GenericMotion -= HandleGenericMotion;
            this.LongClick -= HandleLongClick;
            this.Click -= CustomFrameRenderer_Click;

         }

         if (e.OldElement == null)
         {
            this.GenericMotion += HandleGenericMotion;
            this.LongClick += HandleLongClick;
            this.Click += CustomFrameRenderer_Click;
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

      private void CustomFrameRenderer_Click(object sender, EventArgs e)
      {
         ExtendedFrame extendedFrame = ((ExtendedFrame)Element);
         extendedFrame.InvokeNormalPressedEvent(extendedFrame);
      }

      void HandleLongClick(object sender, LongClickEventArgs e)
      {
         ExtendedFrame extendedFrame = ((ExtendedFrame)Element);
         extendedFrame.InvokeLongPressedEvent(extendedFrame);

      }

      void HandleGenericMotion(object sender, GenericMotionEventArgs e)
      {
         _detector.OnTouchEvent(e.Event);
      }
   }
}