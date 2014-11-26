using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF6
{
    public class Patient : EntityBase
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
        public string Note { get; set; }

        public virtual ICollection<Address> Addresses
        {
            get { return addresses; }
            set { addresses = value; }
        }
    }
}
