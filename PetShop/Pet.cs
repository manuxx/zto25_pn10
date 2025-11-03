using System;

namespace Training.DomainClasses
{
    public class Pet
    {
        public Sex sex;
        public string name { get; set; }
        public int yearOfBirth { get; set; }
        public float price { get; set; }
        public Species species { get; set; }

        public static Predicate<Pet> IsSpeciesOf(Species species)
        {
            return p => p.species == species;
        }

        public static Predicate<Pet> IsBornAfter(int year)
        {
            return p => p.yearOfBirth > year;
        }

        public static Predicate<Pet> IsFemale()
        {
            return pet => pet.sex == Sex.Female;
        }
    }
}