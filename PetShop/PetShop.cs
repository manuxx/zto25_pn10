using System;
using System.Collections.Generic;

namespace Training.DomainClasses
{
    public class PetShop
    {
        private IList<Pet> _petsInTheStore;

        public PetShop(IList<Pet> petsInTheStore)
        {
            this._petsInTheStore = petsInTheStore;
        }

        public IEnumerable<Pet> AllPets()
        {
            return new ReadOnlyOf<Pet>(_petsInTheStore);
        }

        public void Add(Pet newPet)
        {
            
            foreach (var pet in _petsInTheStore)
            {

                if (pet.name==newPet.name)
                {
                    return;
                }
            }
            _petsInTheStore.Add(newPet);
        }

        public IEnumerable<Pet> AllCats()
        {
            return AllItemsThatSatisfy(p => p.species == Species.Cat);

        }

        public IEnumerable<Pet> AllPetsSortedByName()
        {

            var tmp = new List<Pet>(_petsInTheStore);
                tmp.Sort((p1,p2)=>p1.name.CompareTo(p2.name));
            return tmp;
        }

        public IEnumerable<Pet> AllMice()
        {
            return AllItemsThatSatisfy(p => p.species == Species.Mouse);
        }

        public IEnumerable<Pet> AllFemalePets()
        {
            return AllItemsThatSatisfy(pet => pet.sex == Sex.Female);
        }

        private IEnumerable<Pet> AllItemsThatSatisfy(Func<Pet, bool> condition)
        {
            foreach (var pet in _petsInTheStore)
            {
                if (condition(pet))
                    yield return pet;
            }
        }

        public IEnumerable<Pet> AllCatsOrDogs()
        {
            return AllItemsThatSatisfy(pet => pet.species == Species.Cat || pet.species==Species.Dog);

        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            return AllItemsThatSatisfy(p => p.species != Species.Mouse);
        }

        public IEnumerable<Pet> AllPetsBornAfter2010()
        {
            return AllItemsThatSatisfy(p => p.yearOfBirth > 2010);
        }

        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            return AllItemsThatSatisfy(p => p.species == Species.Dog && p.yearOfBirth>2010);
        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            return AllItemsThatSatisfy(p => p.species == Species.Dog && p.sex == Sex.Male);
        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            return AllItemsThatSatisfy(p => p.species == Species.Rabbit || p.yearOfBirth>2011);
        }
    }
}