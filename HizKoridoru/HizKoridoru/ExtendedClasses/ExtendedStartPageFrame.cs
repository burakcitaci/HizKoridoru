using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace HizKoridoru.ExtendedClasses
{
   public class ExtendedStartPageFrame : Frame
   {
      public new Thickness Padding { get; set; } = 0;
      public int BorderThickness { get; set; }
      public ExtendedStartPageFrame()
      {
         base.Padding = this.Padding;
      }
   }
}
