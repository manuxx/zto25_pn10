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

        public static Criteria<Pet> IsSpeciesOf(Species species)
        {
            return new IsASpecies(species);
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

    public class IsASpecies : Criteria<Pet>
    {
        private readonly Species _species;

        public IsASpecies(Species species)
        {
            _species = species;
        }

        public bool IsSatisfiedBy(Pet item)
        {
            return item.species == _species;
        }
    }
}