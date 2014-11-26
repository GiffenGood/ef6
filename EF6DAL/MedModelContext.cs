using System.Data.Entity;
using System.Diagnostics;
using EF6;

namespace EF6DAL
{
    public class MedModelContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
