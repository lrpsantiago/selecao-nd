using Entities;
using System.Collections.Generic;

namespace DAL
{
    public interface IContactRepository : IRepository<Contact>
    {
        IEnumerable<Contact> GetContactsByPerson(Person person);
    }
}