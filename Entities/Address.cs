namespace Entities
{
    public class Address
    {
        public int Id { get; set; }

        public int PersonId { get; set; }
        public virtual Person Person { get; set; }

        public AddressType Type { get; set; }
        public string StreetName { get; set; }
        public int Number { get; set; }
        public string Complement { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
