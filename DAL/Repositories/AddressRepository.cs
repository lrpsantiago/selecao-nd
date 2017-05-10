using Entities;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    internal class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(ContactBookContext context)
            : base(context)
        {

        }

        public IEnumerable<Address> GetAddressesByPerson(Person person)
        {
            if (person != null)
            {
                return from a in this.Entities
                       where a.PersonId == person.Id
                       select a;
            }

            return Enumerable.Empty<Address>();
        }
    }
}
