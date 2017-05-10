using DAL;
using Entities;
using System.Collections.Generic;

namespace Business
{
    public class AddressBusiness
    {
        public Address Get(int id)
        {
            using (ContactBookUOW uow = new ContactBookUOW(new ContactBookContext()))
            {
                return uow.Addresses.Get(id);
            }
        }

        public List<Address> GetAll()
        {
            using (ContactBookUOW uow = new ContactBookUOW(new ContactBookContext()))
            {
                return new List<Address>(uow.Addresses.GetAll());
            }
        }

        public void Add(Address a)
        {
            using (ContactBookUOW uow = new ContactBookUOW(new ContactBookContext()))
            {
                uow.Addresses.Add(a);
                uow.SaveChanges();
            }
        }

        public void Remove(Address a)
        {
            using (ContactBookUOW uow = new ContactBookUOW(new ContactBookContext()))
            {
                uow.Addresses.Remove(a);
                uow.SaveChanges();
            }
        }
    }
}
