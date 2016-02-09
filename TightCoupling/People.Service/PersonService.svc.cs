using Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace People.Service
{
    public class PersonService : IPersonService
    {
        public List<Person> GetPeople()
        {
            var p = new List<Person>()
            {
                new Person() { FirstName="John", LastName="Koenig",
                    StartDate = new DateTime(1975, 10, 17), Rating=6 },
                new Person() { FirstName="Dylan", LastName="Hunt",
                    StartDate = new DateTime(2000, 10, 2), Rating=8 },
                new Person() { FirstName="John", LastName="Crichton",
                    StartDate = new DateTime(1999, 3, 19), Rating=7 },
                new Person() { FirstName="Dave", LastName="Lister",
                    StartDate = new DateTime(1988, 2, 15), Rating=9 },
                new Person() { FirstName="John", LastName="Sheridan",
                    StartDate = new DateTime(1994, 1, 26), Rating=6 },
                new Person() { FirstName="Dante", LastName="Montana",
                    StartDate = new DateTime(2000, 11, 1), Rating=5 },
                new Person() { FirstName="Isaac", LastName="Gampu",
                    StartDate = new DateTime(1977, 9, 10), Rating=4 }
            };
            return p;
        }

        public Person GetPerson(string lastName)
        {
            var p = GetPeople();
            Person selPerson = p.Where(s => s.LastName == lastName).FirstOrDefault();
            return selPerson;
        }

        public void AddPerson(Person newPerson)
        {
            throw new NotImplementedException();
        }

        public void UpdatePerson(string lastName, Person updatedPerson)
        {
            throw new NotImplementedException();
        }

        public void DeletePerson(string lastName)
        {
            throw new NotImplementedException();
        }

        public void UpdatePeople(List<Person> updatedPeople)
        {
            throw new NotImplementedException();
        }
    }
}
