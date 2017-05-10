using Entities;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace DAL
{
    internal class PersonRepository : Repository<Person>, IPersonRepository
    {
        private ContactBookContext m_context;

        public PersonRepository(ContactBookContext context)
            : base(context)
        {
            m_context = context;
        }

        public override Person Get(int id)
        {
            return this.Entities.
                Include(p => p.Marker).
                Include(p => p.Contacts).
                Include(p => p.Addresses).
                SingleOrDefault(p => p.Id == id);
        }

        public override IEnumerable<Person> GetAll()
        {
            return this.Entities.Include(p => p.Marker);
        }

        public IEnumerable<Person> GetByMarker(Marker marker)
        {
            if (marker != null)
            {
                return from person in this.Entities
                       where person.Marker.Id == marker.Id
                       select person;
            }

            return from person in this.Entities
                   where person.Marker == marker
                   select person;
        }

        public IEnumerable<Person> GetByName(string name)
        {
            return from person in this.Entities.Include(p => p.Marker).OrderBy(p => p.Name)
                   where person.Name.ToUpper().Contains(name.ToUpper())
                   select person;
        }

        public IEnumerable<Person> GetByNameOrderedByMarker(string name)
        {
            return from person in this.Entities.Include(p => p.Marker).OrderBy(p => p.Marker.Description)
                   where person.Name.ToUpper().Contains(name.ToUpper())
                   select person;
        }

        public IEnumerable<Person> GetAllOrderedByName()
        {
            return this.Entities.Include(p => p.Marker).OrderBy(p => p.Name);
        }

        public IEnumerable<Person> GetAllOrderedByMarker()
        {
            return this.Entities.Include(p => p.Marker).OrderBy(p => p.Marker.Description);
        }

        public void AddWithExistingMarker(Person p)
        {
            if (p.Marker != null)
            {
                m_context.Markers.Attach(p.Marker);
            }

            m_context.Persons.Add(p);
        }

        //public override void Update(Person entity)
        //{
        //    //this.Entities.Attach(entity);
        //    var entry = this.Context.Entry(entity);
        //    entry.State = EntityState.Modified;

        //    entry.Property(p => p.Marker.Id).IsModified = true;
        //}
    }
}
