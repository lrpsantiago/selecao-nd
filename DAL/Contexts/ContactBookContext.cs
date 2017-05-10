using Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DAL
{
    public class ContactBookContext : DbContext
    {
        public DbSet<Person> Persons { get; private set; }
        public DbSet<Contact> Contacts { get; private set; }
        public DbSet<Address> Addresses { get; private set; }
        public DbSet<Marker> Markers { get; private set; }

        public ContactBookContext()
            : base("ContactBookContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
