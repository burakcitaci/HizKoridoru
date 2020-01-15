using HizKoridoru.Models;
using HizKoridoru.ViewModels;
using HizKoridoru.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Linq;
namespace HizKoridoru.ExtendedClasses
{
   public class ExtendedFrame : Frame
   {
      /// <summary>
      /// 
      /// </summary>
      public bool IsFrameSelected { get; set; }

      /// <summary>
      /// 
      /// </summary>
      public static List<Route> CurrentRoutes { get; set; }

      /// <summary>
      /// 
      /// </summary>
      public Route CurrentRoute { get; set; }

      private string mycolor = "Accent";

      public string MyColor
      {
         get
         {
            return mycolor;
         }
         set
         {
            if (mycolor != value)
            {
               mycolor = value;
            }
         }
      }
      //private List<ExtendedFrame> Frames = ExtendedCollectionView.ExtendedFrameList;
      /// <summary>
      /// 
      /// </summary>
      public ExtendedFrame()
      {
         
         if (CurrentRoutes != null)
         {
            if (CurrentRoutes.Count > 0)
            {
               CurrentRoute = CurrentRoutes.First();
               //this.GetParentPage();
               ////if(ExtendedCollectionView.ExtendedFrames.Count > 0)
               //{
               //   if (ExtendedCollectionView.ExtendedFrameList.Where(x => x.CurrentRoute.ID != this.CurrentRoute.ID).FirstOrDefault() == null)
               //   {
               //      ExtendedCollectionView.ExtendedFrameList.Add(this);
               //   }
               //}
               //var existingValues = new HashSet<int>(from x in CurrentRoutes select x.ID);
               //// pick items that have a property bar that doesn't exist yet
               //var newItems = ExtendedCollectionView.ExtendedFrameList.Where(x => !existingValues.Contains(x.CurrentRoute.ID));
               //if(newItems == null || newItems.ToList().Count == 0)
               //{
               //   ExtendedCollectionView.ExtendedFrameList.Add(this);
               //}
               //ExtendedCollectionView.ExtendedFrameList.Add(this);
               //foreach(var frame in ExtendedCollectionView.ExtendedFrameList)
               //{
               //   if(frame.CurrentRoute.ID != this.CurrentRoute.ID)
               //   {
               //      ExtendedCollectionView.ExtendedFrameList.Add(this);
               //   }
               //}

               ExtendedCollectionView.ExtendedFrameList.Add(this);
               ExtendedCollectionView.ExtendedFrameList = ExtendedCollectionView.ExtendedFrameList.DistinctBy(x => x.CurrentRoute.ID).ToList();
               // Add them
               //foreach (var item in newItems)
               //{
               //   ExtendedCollectionView.ExtendedFrameList.Add(this);
               //}
               //if (ExtendedCollectionView.ExtendedFrameList.Where(x => x.CurrentRoute.ID != this.CurrentRoute.ID).FirstOrDefault() == null)
               //{
               //   ExtendedCollectionView.ExtendedFrameList.Add(this);
               //}
               CurrentRoutes.Remove(CurrentRoute);

               //ExtendedCollectionView.ExtendedFrameList.Add(this);
               //ExtendedCollectionView.ExtendedFrameList = ExtendedCollectionView.ExtendedFrameList.DistinctBy(x => x.CurrentRoute.ID).ToList();
            }
         }
         HasShadow = false;
      }

      /// <summary>
      /// Long Pressed event for frame
      /// </summary>
      /// <param name="sender">Current frame with current route</param>
      public delegate void LongPress(object sender);
      public event LongPress LongPressed;
      public void InvokeLongPressedEvent(object sender)
      {
         if(LongPressed != null)
         {
            LongPressed(sender);
         }
        
      }

      /// <summary>
      /// Normal Pressed Event for frame
      /// </summary>
      /// <param name="sender"></param>
      public delegate void NormalPress(object sender);
      public event NormalPress NormalPressed;
      public void InvokeNormalPressedEvent(object sender)
      {
         NormalPressed?.Invoke(sender);
      }
   }
}
