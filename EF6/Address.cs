namespace EF6
{
    public class Address : EntityBase
    {
        public int AddressId { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public AddressType AddressType { get; set; }
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }
    }
}