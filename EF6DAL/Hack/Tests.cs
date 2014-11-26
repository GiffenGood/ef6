using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using EF6;
using EF6DAL.Migrations;

namespace EF6DAL.Hack
{
    public class Tests
    {
        public void GetPatients()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MedModelContext,Configuration>());
            
            using (var ctx = new MedModelContext())
            {
                ctx.Patients.Where(p=>p.Addresses.Count == 1).ToList().ForEach(p=>Debug.WriteLine(p.FullName));
                //var pat = new Patient {First = "Matt", Last = "Bixby"};
                //ctx.Patients.Add(pat);
                //ctx.SaveChanges();
            }
        }

        public void AddAddresses()
        {
            using (var ctx = new MedModelContext())
            {
                var pat = ctx.Patients.Where(p => p.Last == "Bixby").First();
                pat.Addresses.Add(new Address {Street1 =  "123 lane",City = "Collegeville", State =  "PA", Zip = "12345"});
                pat.Addresses.Add(new Address { Street1 = "88 Flow Rd", City = "Flamville", State = "NJ", Zip = "88125" });
                ctx.SaveChanges();
            }
        }

        public void DisplayAddresses()
        {
            using (var ctx = new MedModelContext())
            {
                var pat = ctx.Patients.Where(p => p.Last == "Bixby").Include(p => p.Addresses).First();
                Debug.WriteLine(pat.Addresses.Count);
            }
        }
    }
}
