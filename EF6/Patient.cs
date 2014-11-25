using System;
using System.Collections.Generic;

namespace EF6
{
    public class Patient
    {
        private ICollection<Address> addresses;

        public Patient()
        {
            addresses = new List<Address>();    
        }

        public int PatientId { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public DateTime BirthDate { get; set; }

        public virtual ICollection<Address> Addresses
        {
            get { return addresses; }
            set { addresses = value; }
        }
    }

    public class Address
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

    public enum AddressType
    {
        Home,
        Work,
        Vacation
    }
}
