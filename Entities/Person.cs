using System.Collections.Generic;

namespace Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Address> Addresses { get; set; }
        public virtual List<Contact> Contacts { get; set; }
        public virtual Marker Marker { get; set; }

        public Person()
        {
            this.Addresses = new List<Address>();
            this.Contacts = new List<Contact>();
        }
    }
}
