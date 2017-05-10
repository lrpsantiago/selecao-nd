using DAL;
using Entities;
using System.Collections.Generic;

namespace Business
{
    public class PersonBusiness
    {
        public Person Get(int id)
        {
            using (ContactBookUOW uow = new ContactBookUOW(new ContactBookContext()))
            {
                return uow.Persons.Get(id);
            }
        }

        public List<Person> GetAll()
        {
            using (ContactBookUOW uow = new ContactBookUOW(new ContactBookContext()))
            {
                return new List<Person>(uow.Persons.GetAll());
            }
        }

        public List<Person> GetAllOrderedByName()
        {
            using (ContactBookUOW uow = new ContactBookUOW(new ContactBookContext()))
            {
                return new List<Person>(uow.Persons.GetAllOrderedByName());
            }
        }

        public List<Person> GetAllOrderedByMarker()
        {
            using (ContactBookUOW uow = new ContactBookUOW(new ContactBookContext()))
            {
                return new List<Person>(uow.Persons.GetAllOrderedByMarker());
            }
        }

        public List<Person> GetByName(string name)
        {
            using (ContactBookUOW uow = new ContactBookUOW(new ContactBookContext()))
            {
                return new List<Person>(uow.Persons.GetByName(name));
            }
        }

        public List<Person> GetByNameOrderedByMarker(string name)
        {
            using (ContactBookUOW uow = new ContactBookUOW(new ContactBookContext()))
            {
                return new List<Person>(uow.Persons.GetByNameOrderedByMarker(name));
            }
        }

        public void Add(Person p)
        {
            using (ContactBookUOW uow = new ContactBookUOW(new ContactBookContext()))
            {
                Marker marker = null;

                if (p.Marker != null)
                {
                    marker = uow.Markers.Get(p.Marker.Id);
                }

                p.Marker = marker;

                uow.Persons.Add(p);
                uow.SaveChanges();
            }
        }

        public void Update(Person p)
        {
            using (ContactBookUOW uow = new ContactBookUOW(new ContactBookContext()))
            {
                Person person = uow.Persons.Get(p.Id);
                person.Name = p.Name;

                Marker marker = null;

                if (p.Marker != null)
                {
                    marker = uow.Markers.Get(p.Marker.Id);
                }

                person.Marker = marker;
                uow.SaveChanges();
            }
        }

        public void Remove(Person p)
        {
            using (ContactBookUOW uow = new ContactBookUOW(new ContactBookContext()))
            {
                uow.Persons.Remove(p);
                uow.SaveChanges();
            }
        }
    }
}
