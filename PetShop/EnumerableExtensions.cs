using System;
using System.Collections.Generic;
using Training.DomainClasses;

public static class EnumerableExtensions
{
    public static IEnumerable<TItem> OneAtAtime<TItem>(this IEnumerable<TItem> items)
    {
        foreach (var item in items)
        {
            yield return item;
        }
    }


    public static IEnumerable<TItem> AllItemsThatSatisfy<TItem>(this IEnumerable<TItem> items, Func<TItem, bool> condition)
    {
        foreach (var item in items)
        {
            if (condition(item))
                yield return item;
        }
    }
}