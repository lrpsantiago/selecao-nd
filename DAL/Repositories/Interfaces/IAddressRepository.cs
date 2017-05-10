using Entities;
using System.Collections.Generic;

namespace DAL
{
    public interface IAddressRepository : IRepository<Address>
    {
        IEnumerable<Address> GetAddressesByPerson(Person person);
    }
}