using System.Collections.Generic;
using Training.DomainClasses;

public static class EnumerableExtensions
{
    public static IEnumerable<Pet> OneAtAtime(IList<Pet> petsInTheStore)
    {
        foreach (var pet in petsInTheStore)
        {
            yield return pet;
        }
    }
}