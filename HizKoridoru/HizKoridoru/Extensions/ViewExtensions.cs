using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace HizKoridoru.Extensions
{
   public static class ViewExtensions
   {
      /// <summary>
      /// Gets the page to which an element belongs
      /// </summary>
      /// <returns>The page.</returns>
      /// <param name="element">Element.</param>
      public static Page GetParentPage(this VisualElement element)
      {
         if (element != null)
         {
            var parent = element.Parent;
            while (parent != null)
            {
               if (parent is Page)
               {
                  return parent as Page;
               }
               parent = parent.Parent;
            }
         }
         return null;
      }

      public static IEnumerable<TSource> DistinctBy<TSource, TKey>
    (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
      {
         HashSet<TKey> seenKeys = new HashSet<TKey>();
         foreach (TSource element in source)
         {
            if (seenKeys.Add(keySelector(element)))
            {
               yield return element;
            }
         }
      }
   }
}
