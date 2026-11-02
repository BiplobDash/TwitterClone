using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Utilities.Extensions
{
    public static class ListExtensions
    {
        public static T? LastOrNull<T>(this List<T> items) where T : class
        {
            if (items == null || items.Count == 0)
            {
                return null;
            }

            return items[^1]; 
        }
    }
}
