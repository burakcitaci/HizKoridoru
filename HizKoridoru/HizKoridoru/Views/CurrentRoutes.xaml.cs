using HizKoridoru.ExtendedClasses;
using HizKoridoru.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HizKoridoru.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;

namespace HizKoridoru.Views
{
   [XamlCompilation(XamlCompilationOptions.Compile)]
   public partial class CurrentRoutes : ContentPage
   {
      private List<Route> TappedRoutes = new List<Route>();
      private bool FrameLongPressed;
      public CurrentRoutes()
      {
         InitializeComponent();
         this.title.Text = "Rotalar";
      }

      private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
      {
         await Application.Current.MainPage.Navigation.PopAsync();
      }

      private void Cancel_Tapped(object sender, EventArgs e)
      {
         this.collectionView.SelectionMode = SelectionMode.Single;
         this.title.Text = "Rotalar";
         this.bindingContext.ResetItemsCommand.Execute(null);
         this.SetVisibility();
      }

      private void Bookmark_Tapped(object sender, EventArgs e)
      {
         this.bindingContext.LoadBookmarkedItemsCommand.Execute(TappedRoutes);
         this.Cancel_Tapped(sender, e);
      }

      private void SetVisibility()
      {
         //this.favoriteIcon.IsVisible = !this.favoriteIcon.IsVisible;
         this.bookmarkIcon.IsVisible = !this.bookmarkIcon.IsVisible;
         this.deleteIcon.IsVisible = !this.deleteIcon.IsVisible;
         this.addIcon.IsVisible = !this.addIcon.IsVisible;
         this.cancelIcon.IsVisible = !this.cancelIcon.IsVisible;
         this.editIcon.IsVisible = !this.editIcon.IsVisible;
         this.TappedRoutes = new List<Route>();
      }

      private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
      {
         //EDIT ICON and MODe multiple
         if (this.collectionView.SelectionMode == SelectionMode.Multiple)
         {
            if (e.CurrentSelection.ToList().Count > 0)
            {
               Debug.WriteLine((this.collectionView.SelectedItem as Route).StartDestination);
              // Debug.WriteLine(ExtendedCollectionView.ExtendedFrameList
              //.Where(x => x.CurrentRoute.ID == (e.CurrentSelection.Last() as Route).ID).First().CurrentRoute.StartDestination);

               ExtendedFrame extendedFrame = ExtendedCollectionView.ExtendedFrameList
              .Where(x => x.CurrentRoute.ID == (e.CurrentSelection.Last() as Route).ID).First();

               if(extendedFrame.BackgroundColor == Color.Red)
               {
                  extendedFrame.BackgroundColor = Color.Yellow;
               }
               else
               {
                  extendedFrame.BackgroundColor = Color.Red;
               }
            }
         }
      }

      private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
      {
         this.collectionView.SelectionMode = SelectionMode.Multiple;
         this.collectionView.SelectionChanged += CollectionView_SelectionChanged;
      }

      private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
      {
         //this.cancelIcon.IsVisible = true;
         this.collectionView.SelectionMode = SelectionMode.Multiple;
         this.SetVisibility();
         //this.collectionView.SelectionChanged += CollectionView_SelectionChanged;
      }

      private async void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
      {
         //Debug.WriteLine((sender as ExtendedFrame).CurrentRoute.StartDestination);
         if(this.collectionView.SelectionMode == SelectionMode.Multiple)
         {
            ExtendedFrame extendedFrame = ExtendedCollectionView.ExtendedFrameList
             .Where(x => x.CurrentRoute.ID == (sender as ExtendedFrame).CurrentRoute.ID).First();

            if (extendedFrame.BackgroundColor == Color.FromHex("#808080"))
            {
               extendedFrame.BackgroundColor = Color.FromHex("#52597F");
               TappedRoutes.Remove(extendedFrame.CurrentRoute);
            }
            else
            {
               extendedFrame.BackgroundColor = Color.FromHex("#808080");
               TappedRoutes.Add(extendedFrame.CurrentRoute);
            }
            int countSelected = ExtendedCollectionView.ExtendedFrameList
               .Where(x => x.BackgroundColor == Color.FromHex("#808080"))
               .ToList()
               .Count;
            if(countSelected != 0)
            {
               this.title.Text = countSelected.ToString();
            }
            else
            {
               this.title.Text = "Rotalar";
            }
         }
         else
         {
            await Application.Current.MainPage.Navigation.PushAsync(new RouteDetailPage((sender as ExtendedFrame).CurrentRoute));
         }
      }
   }
}