using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Foundation;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using HizKoridoru.ExtendedClasses;
using HizKoridoru.iOS.Renderers;
using CoreGraphics;

[assembly: ExportRenderer(typeof(ExtendedListView), typeof(CustomListViewRenderer))]
namespace HizKoridoru.iOS.Renderers
{
   public class CustomListViewRenderer : ListViewRenderer
   {
      public CustomListViewRenderer()
      {
        
      }
      protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ListView> e)
      {
         base.OnElementChanged(e);

         if (e.OldElement != null)
         {
            // Unsubscribe
         }

         if (e.NewElement != null)
         {
            Control.TableFooterView = new UIView(CGRect.Empty);
            Control.SeparatorInset = UIEdgeInsets.Zero;


            if (e.NewElement.IsGroupingEnabled)
            {
               var groupedTableView = new UITableView(Control.Frame, UITableViewStyle.Grouped);
               
               SetNativeControl(groupedTableView);
            }
         }
      }
   }
}