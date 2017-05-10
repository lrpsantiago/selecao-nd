namespace Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public ContactType Type { get; set; }
        public string Value { get; set; }

        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}
