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
                ctx.Patients.Where(p=>p.Addresses.Count == 0).ToList().ForEach(p=>Debug.WriteLine(p.FullName));
                //var pat = new Patient {First = "Matt", Last = "Bixby"};
                //ctx.Patients.Add(pat);
                //ctx.SaveChanges();
            }
        }
    }
}
