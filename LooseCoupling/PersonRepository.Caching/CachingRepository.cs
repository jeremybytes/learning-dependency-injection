using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonRepository.Caching
{
    public class CachingRepository : IPersonRepository
    {
        private TimeSpan _cacheDuration = new TimeSpan(0, 0, 30);
        private DateTime _dataDateTime;
        private IPersonRepository _wrappedRepository;
        private IEnumerable<Person> _cachedItems;

        public CachingRepository(IPersonRepository wrappedPersonRepository)
        {
            _wrappedRepository = wrappedPersonRepository;
        }

        private bool IsCacheValid
        {
            get
            {
                var _cacheAge = DateTime.Now - _dataDateTime;
                return _cacheAge < _cacheDuration;
            }
        }

        private void ValidateCache()
        {
            if (_cachedItems == null || !IsCacheValid)
            {
                try
                {
                    _cachedItems = _wrappedRepository.GetPeople();
                    _dataDateTime = DateTime.Now;
                }
                catch
                {
                    _cachedItems = new List<Person>()
                    {
                        new Person(){ FirstName="No Data Available", LastName = string.Empty, Rating = 0, StartDate = DateTime.Today},
                    };
                }
            }
        }

        private void InvalidateCache()
        {
            _dataDateTime = DateTime.MinValue;
        }

        public IEnumerable<Person> GetPeople()
        {
            ValidateCache();
            return _cachedItems;
        }

        public Person GetPerson(string lastName)
        {
            ValidateCache();
            return _cachedItems.FirstOrDefault(p => p.LastName == lastName);
        }

        public void AddPerson(Person newPerson)
        {
            _wrappedRepository.AddPerson(newPerson);
            InvalidateCache();
        }

        public void UpdatePerson(string lastName, Person updatedPerson)
        {
            _wrappedRepository.UpdatePerson(lastName, updatedPerson);
            InvalidateCache();
        }

        public void DeletePerson(string lastName)
        {
            _wrappedRepository.DeletePerson(lastName);
            InvalidateCache();
        }

        public void UpdatePeople(IEnumerable<Person> updatedPeople)
        {
            _wrappedRepository.UpdatePeople(updatedPeople);
            InvalidateCache();
        }
    }
}
