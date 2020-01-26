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

[assembly: ExportRenderer(typeof(ExtendedLabelFrame), typeof(CustomLabelFrameRenderer))]
namespace HizKoridoru.Droid.Renderers
{
   public class CustomLabelFrameRenderer : FrameRenderer
   {
      public CustomLabelFrameRenderer(Context context) : base(context)
      {

      }

      protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
      {
         base.OnElementChanged(e);
         SetBackgroundResource(Resource.Drawable.shape_rounded_blue_rect);
         //SetBackgroundDrawable(Resources.GetDrawable(Resource.Drawable.shape_rounded_blue_rect));
      }
   }
}
