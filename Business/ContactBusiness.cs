using DAL;
using Entities;
using System.Collections.Generic;

namespace Business
{
    public class ContactBusiness
    {
        public Contact Get(int id)
        {
            using (ContactBookUOW uow = new ContactBookUOW(new ContactBookContext()))
            {
                return uow.Contacts.Get(id);
            }
        }

        public List<Contact> GetAll()
        {
            using (ContactBookUOW uow = new ContactBookUOW(new ContactBookContext()))
            {
                return new List<Contact>(uow.Contacts.GetAll());
            }
        }

        public void Add(Contact c)
        {
            using (ContactBookUOW uow = new ContactBookUOW(new ContactBookContext()))
            {
                uow.Contacts.Add(c);
                uow.SaveChanges();
            }
        }

        public void Remove(Contact c)
        {
            using (ContactBookUOW uow = new ContactBookUOW(new ContactBookContext()))
            {
                uow.Contacts.Remove(c);
                uow.SaveChanges();
            }
        }
    }
}
