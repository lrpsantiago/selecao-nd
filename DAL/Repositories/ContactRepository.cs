using Entities;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    internal class ContactRepository : Repository<Contact>, IContactRepository
    {
        public ContactRepository(ContactBookContext context)
            : base(context)
        {

        }

        public IEnumerable<Contact> GetContactsByPerson(Person person)
        {
            if (person != null)
            {
                return from c in this.Entities
                       where c.PersonId == person.Id
                       select c;
            }

            return Enumerable.Empty<Contact>();
        }
    }
}
