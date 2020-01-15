using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace HizKoridoru.ExtendedClasses
{
   public class ExtendedCollectionView : CollectionView
   {
      public static List<ExtendedFrame> ExtendedFrameList = new List<ExtendedFrame>();
     
      public ExtendedCollectionView()
      {
         //ExtendedFrameList = new List<ExtendedFrame>();
      }

      private static List<ExtendedFrame> _extendedFrames;

      public static List<ExtendedFrame> ExtendedFrames
      {
         get
         {
            if (_extendedFrames == null)
            {
               _extendedFrames = new List<ExtendedFrame>();
            }
           
            return _extendedFrames;
         }
      }
   }
}
