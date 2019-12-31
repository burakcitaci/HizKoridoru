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
using Xamarin.Forms.Platform.Android;

namespace HizKoridoru.Droid.Renderers
{
   public class CustomCollectionViewRenderer : CollectionViewRenderer
   {
      private readonly GestureDetector.SimpleOnGestureListener _listener;
      private readonly GestureDetector _detector;
      public CustomCollectionViewRenderer(Context context) : base(context)
      {
         _listener = new GestureDetector.SimpleOnGestureListener();
         _detector = new GestureDetector(context, _listener) { IsLongpressEnabled = true };
      }
   }
}