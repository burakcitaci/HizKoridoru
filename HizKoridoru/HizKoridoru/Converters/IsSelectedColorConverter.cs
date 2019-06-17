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
         return ((bool)value ? Color.FromHex("#e0e0e0") : Color.Transparent);
      }

      public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
      {
         throw new NotImplementedException();
      }
   }
}
