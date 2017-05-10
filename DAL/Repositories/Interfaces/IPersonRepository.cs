using Entities;
using System.Collections.Generic;

namespace DAL
{
    public interface IPersonRepository : IRepository<Person>
    {
        IEnumerable<Person> GetByMarker(Marker marker);
        IEnumerable<Person> GetByName(string name);
        IEnumerable<Person> GetByNameOrderedByMarker(string name);
        IEnumerable<Person> GetAllOrderedByName();
        IEnumerable<Person> GetAllOrderedByMarker();
        void AddWithExistingMarker(Person p);
    }
}