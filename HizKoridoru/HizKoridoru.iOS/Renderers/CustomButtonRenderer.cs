using HizKoridoru.Droid.Renderers;
using HizKoridoru.ExtendedClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

//[assembly: ExportRenderer(typeof(ExtendedButton), typeof(CustomButtonRenderer))]
namespace HizKoridoru.Droid.Renderers
{
   public class CustomButtonRenderer : ButtonRenderer
   {
      protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
      {
         base.OnElementChanged(e);
         if(e.NewElement != null)
         {
            (Element as ExtendedButton).WidthRequest = 50;

         }
      }
   }
}