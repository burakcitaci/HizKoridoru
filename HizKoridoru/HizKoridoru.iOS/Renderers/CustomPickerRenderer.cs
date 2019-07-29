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

[assembly:ExportRenderer(typeof(ExtendedPicker), typeof(CustomPickerRenderer))]
namespace HizKoridoru.iOS.Renderers
{
   public class CustomPickerRenderer : PickerRenderer
   {
      protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
      {
         base.OnElementChanged(e);
         if(e.NewElement != null)
         {
          
            var view = e.NewElement as ExtendedPicker;
            this.Control.BorderStyle = UITextBorderStyle.Bezel;
         }
      }
   }
}