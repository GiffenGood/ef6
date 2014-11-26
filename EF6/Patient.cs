using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

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
        [Required]
        [MaxLength(50)]
        public string Last { get; set; }
        [NotMapped]
        public string FullName
        {
            get { return string.Format("{0}, {1} -- {2}", First, Last, PatientType); }
        }
        public DateTime? BirthDate { get; set; }
        public PatientType PatientType { get; set; }

        public virtual ICollection<Address> Addresses
        {
            get { return addresses; }
            set { addresses = value; }
        }
    }

    public enum PatientType { Student, Employee, Other}

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
