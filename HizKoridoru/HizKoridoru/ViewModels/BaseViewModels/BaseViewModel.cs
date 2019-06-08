using HizKoridoru.Models;
using HizKoridoru.Services.DataStores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace HizKoridoru.ViewModels.BaseViewModels
{
   public class BaseViewModel : INotifyPropertyChanged
   {
      public IRouteDataStore<Route> DataStore => DependencyService.Get<IRouteDataStore<Route>>() ??null;

      bool isBusy = false;
      public bool IsBusy
      {
         get { return isBusy; }
         set { SetProperty(ref isBusy, value); }
      }

      bool isSelected = false;
      public bool IsSelected
      {
         get { return isSelected; }
         set { SetProperty(ref isSelected, value); }
      }
      bool isVisible = false;
      public bool IsVisible
      {
         get { return isVisible; }
         set { SetProperty(ref isVisible, value); }
      }

      string title = string.Empty;
      public string Title
      {
         get { return title; }
         set { SetProperty(ref title, value); }
      }

      protected bool SetProperty<T>(ref T backingStore, T value,
          [CallerMemberName]string propertyName = "",
          Action onChanged = null)
      {
         if (EqualityComparer<T>.Default.Equals(backingStore, value))
            return false;

         backingStore = value;
         onChanged?.Invoke();
         OnPropertyChanged(propertyName);
         return true;
      }

      #region INotifyPropertyChanged
      public event PropertyChangedEventHandler PropertyChanged;
      protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
      {
         var changed = PropertyChanged;
         if (changed == null)
            return;

         changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }
      #endregion
   }
}
