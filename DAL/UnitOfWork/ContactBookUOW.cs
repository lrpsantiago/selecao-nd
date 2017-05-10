using System;

namespace DAL
{
    public class ContactBookUOW : IDisposable
    {
        private ContactBookContext m_context;

        public IPersonRepository Persons { get; private set; }
        public IContactRepository Contacts { get; private set; }
        public IAddressRepository Addresses { get; private set; }
        public IMarkerRepository Markers { get; private set; }

        public ContactBookUOW(ContactBookContext context)
        {
            m_context = context;

            this.Persons = new PersonRepository(m_context);
            this.Contacts = new ContactRepository(m_context);
            this.Addresses = new AddressRepository(m_context);
            this.Markers = new MarkerRepository(m_context);
        }

        public void SaveChanges()
        {
            m_context.SaveChanges();
        }

        public void Dispose()
        {
            m_context.Dispose();
        }
    }
}
