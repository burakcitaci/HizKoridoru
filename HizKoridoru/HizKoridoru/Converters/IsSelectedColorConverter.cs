using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text;
using Xamarin.Forms;
using Color = Xamarin.Forms.Color;

namespace HizKoridoru.Converters
{
   public class IsSelectedColorConverter : IValueConverter
   {
      public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
      {
         string valueAsString = value.ToString();
         switch (valueAsString)
         {
            case ("#2C3359"):
               {
                  return Color.FromHex("#2C3359");
               }
            case ("Accent"):
               {
                  return Color.Accent.ToHex();
               }
            default:
               {
                  return Color.FromHex(value.ToString()).ToHex();
               }
         }
      }

      public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
      {
         throw new NotImplementedException();
      }
   }
}
