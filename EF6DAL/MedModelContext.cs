using System;
using System.Data.Entity;
using System.Linq;
using EF6;

namespace EF6DAL
{
    public class MedModelContext : DbContext
    {
        public MedModelContext()
        {
            Configuration.LazyLoadingEnabled = true;
        }

        public override int SaveChanges()
        {
            foreach(var e in ChangeTracker.Entries().Where(e=>e.State == EntityState.Added || e.State == EntityState.Modified))
            {
                var eb = e.Entity as EntityBase;
                if (eb != null)
                    eb.LastModified = DateTime.Now;
            }
            
            return base.SaveChanges();
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
