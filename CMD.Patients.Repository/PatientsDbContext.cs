using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Patients.Repository
{
    public class PatientsDbContext : DbContext
    {
        public PatientsDbContext() : base("name=CMDConnectionString") 
        {
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;

            //Data Source=(localdb)\\mssqllocaldb;Initial Catalog=MYDB;Integrated Security=True

            //Data Source = tcp:cmd - atmecs.database.windows.net; Initial Catalog = CMD - DB; Persist Security Info = True;
        }

        public DbSet<Models.Patient> patients { get; set; }
        public DbSet<Models.SignInPatients> patientsSignIn { get; set; }
    }
}
