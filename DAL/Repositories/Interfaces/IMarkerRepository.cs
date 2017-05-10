using Entities;

namespace DAL
{
    public interface IMarkerRepository : IRepository<Marker>
    {
        Marker GetMarkerByDescription(string description);
    }
}