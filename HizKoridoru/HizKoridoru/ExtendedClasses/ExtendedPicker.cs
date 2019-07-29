using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
namespace HizKoridoru.ExtendedClasses
{
   public class ExtendedPicker : Picker
   {
      /// <summary>
		/// selectedBackground Color of picker item selected
		/// </summary>
		public static readonly BindableProperty SelectedBackgroundColorProperty =
         BindableProperty.Create("SelectedBackgroundColor", typeof(Xamarin.Forms.Color), typeof(ExtendedPicker), Xamarin.Forms.Color.Transparent);

      public Xamarin.Forms.Color SelectedBackgroundColor
      {
         get
         {
            return (Xamarin.Forms.Color)GetValue(SelectedBackgroundColorProperty);
         }
         set
         {
            this.SetValue(SelectedBackgroundColorProperty, value);
         }
      }
   }
}
