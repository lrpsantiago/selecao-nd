using DAL;
using Entities;
using System.Collections.Generic;

namespace Business
{
    public class MarkerBusiness
    {
        public Marker Get(int id)
        {
            using (ContactBookUOW uow = new ContactBookUOW(new ContactBookContext()))
            {
                return uow.Markers.Get(id);
            }
        }

        public List<Marker> GetAll()
        {
            using (ContactBookUOW uow = new ContactBookUOW(new ContactBookContext()))
            {
                return new List<Marker>(uow.Markers.GetAll());
            }
        }

        public void Add(Marker marker)
        {
            using (ContactBookUOW uow = new ContactBookUOW(new ContactBookContext()))
            {
                uow.Markers.Add(marker);
                uow.SaveChanges();
            }
        }

        public void Remove(Marker marker)
        {
            using (ContactBookUOW uow = new ContactBookUOW(new ContactBookContext()))
            {
                uow.Markers.Remove(marker);
                uow.SaveChanges();
            }
        }
    }
}
