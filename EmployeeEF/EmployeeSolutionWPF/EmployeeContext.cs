using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeEF
{
    class EmployeeContext:DbContext
    {
        public EmployeeContext() : base("SQLConnection") { }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Database.SetInitializer<EmployeeContext>(new DropCreateDatabaseAlways<EmployeeContext>());
            base.OnModelCreating(modelBuilder);
        }
    }
}
