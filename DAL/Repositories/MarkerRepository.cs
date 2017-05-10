using Entities;
using System.Linq;

namespace DAL
{
    internal class MarkerRepository : Repository<Marker>, IMarkerRepository
    {
        public MarkerRepository(ContactBookContext context)
            : base(context)
        {

        }

        public Marker GetMarkerByDescription(string description)
        {
            return (from m in this.Entities
                    where m.Description == description
                    select m).SingleOrDefault<Marker>();
        }
    }
}
