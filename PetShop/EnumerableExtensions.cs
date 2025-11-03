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

    public static IEnumerable<Pet> AllItemsThatSatisfy(this IList<Pet> items, Func<Pet, bool> condition)
    {
        foreach (var pet in items)
        {
            if (condition(pet))
                yield return pet;
        }
    }
}