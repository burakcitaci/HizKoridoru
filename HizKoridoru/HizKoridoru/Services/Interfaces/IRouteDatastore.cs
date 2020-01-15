using HizKoridoru.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HizKoridoru.Services.DataStores
{
   public interface IRouteDataStore<T>
   {
      /// <summary>
      /// 
      /// </summary>
      /// <param name="item"></param>
      /// <returns></returns>
      Task<bool> AddItemAsync(T item);

      /// <summary>
      /// 
      /// </summary>
      /// <param name="item"></param>
      /// <returns></returns>
      Task<bool> UpdateItemAsync(T item);

      Task<bool> UpdateItemAsync(List<T> item);

      /// <summary>
      /// 
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      Task<bool> DeleteItemAsync(Route route);

      /// <summary>
      /// 
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      Task<T> GetItemAsync(string id);

      /// <summary>
      /// 
      /// </summary>
      /// <param name="forceRefresh"></param>
      /// <returns></returns>
      Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
   }
}
