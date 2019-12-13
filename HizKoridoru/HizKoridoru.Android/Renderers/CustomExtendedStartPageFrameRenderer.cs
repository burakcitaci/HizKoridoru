using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using HizKoridoru.Droid.Renderers;
using HizKoridoru.ExtendedClasses;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ExtendedStartPageFrame), typeof(CustomExtendedStartPageFrameRenderer))]
namespace HizKoridoru.Droid.Renderers
{
   public class CustomExtendedStartPageFrameRenderer : FrameRenderer
   {
      GradientDrawable _gi;
      public CustomExtendedStartPageFrameRenderer(Context context) : base(context)
      {

      }
      //      protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
      //      {
      //         base.OnElementChanged(e);

      //         var origFrame = e.NewElement as ExtendedStartPageFrame;

      //         if (origFrame != null)
      //         {
      //            GradientDrawable gi = new GradientDrawable();

      //            _gi = gi;

      //            this.Elevation = 10;
      //            gi.SetStroke(origFrame.BorderThickness, origFrame.BorderColor.ToAndroid());
      //            gi.SetColor(origFrame.BackgroundColor.ToAndroid());
      //            gi.SetCornerRadius(origFrame.CornerRadius);
      //#pragma warning disable CS0618 // Typ oder Element ist veraltet
      //            SetBackgroundDrawable(gi);
      //#pragma warning restore CS0618 // Typ oder Element ist veraltet
      //         }
      //      }

      //      protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
      //      {
      //         if (ChildCount > 0 && _gi != null)
      //         {
      //#pragma warning disable CS0618 // Type or member is obsolete
      //            SetBackgroundDrawable(_gi);
      //#pragma warning restore CS0618 // Type or member is obsolete
      //         }

      //         base.OnElementPropertyChanged(sender, e);
      //      }
      //   }
      protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
      {
         base.OnElementChanged(e);

         if (Element != null)
         {
            e.NewElement.IsClippedToBounds = true;
            e.NewElement.CornerRadius = (float)(Element as ExtendedStartPageFrame).CornerRadius;
         }
      }

      protected override void OnDraw(Canvas canvas)
      {
         base.OnDraw(canvas);

          DrawOutline(canvas, canvas.Width, canvas.Height, 5f);//set corner radius
      }

      void DrawOutline(Canvas canvas, int width, int height, float cornerRadius)
      {
         using (var paint = new Paint { AntiAlias = true })
         using (var path = new Path())
         using (Path.Direction direction = Path.Direction.Cw)
         using (Paint.Style style = Paint.Style.Stroke)
         using (var rect = new RectF(0, 0, width, height))
         {
            float rx = this.Context.ToPixels(cornerRadius);
            float ry = this.Context.ToPixels(cornerRadius);
            path.AddRoundRect(rect, rx, ry, direction);

            paint.StrokeWidth = 5f;  //set outline stroke
            paint.SetStyle(style);

            paint.Color = Android.Graphics.Color.ParseColor("#757575");//set outline color //_frame.OutlineColor.ToAndroid(); 
            canvas.DrawPath(path, paint);
         }
      }

      protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
      {
         base.OnElementPropertyChanged(sender, e);

         //if (e.PropertyName == ExtendedFrame.CornerRadiusProperty.PropertyName)
         //{
         //   Layer.CornerRadius = (float)(Element as ExtendedFrame).CornerRadius;
         //}
      }
   }
}