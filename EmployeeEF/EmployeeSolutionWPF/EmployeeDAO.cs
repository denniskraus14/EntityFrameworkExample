using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeEF
{

    class EmployeeDAO
    {
        private SqlCommand command;
        private DataTable dtEmployee;
        private SqlDataAdapter sda;
        static string conString = @"data source=LNAR-5CG0338FJ0\SQLEXPRESS;initial catalog=SQLConnection;integrated security=true";

        internal void Create(Employee e)
        {
            using (var context = new EmployeeContext())
            {
                context.Employees.Add(e);
                context.SaveChanges();
            }
        }

        internal Employee Read(int id)
        {
            using(var context = new EmployeeContext())
            {
                return context.Employees.Find(id);
            }
        }

        internal void Update(Employee e)
        {
            using(var context = new EmployeeContext())
            {
                var result = context.Employees.SingleOrDefault(b => e.EmployeeID == b.EmployeeID);
                if (result != null)
                {
                    result.Address = e.Address;
                    result.Company = e.Company;
                    result.Name = e.Name;
                    context.SaveChanges();
                }
            }
        }

        internal void Delete(Employee result)
        {
            using(var context = new EmployeeContext()){
                context.Employees.Remove(result);
                context.SaveChanges();
            }
        }

        internal DataTable Fill()
        {
            using (SqlConnection con1 = new SqlConnection(conString))
            {
                con1.Open();
                command = new SqlCommand("select * from Employees", con1);
                dtEmployee = new DataTable();
                sda = new SqlDataAdapter(command);
                sda.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                sda.Fill(dtEmployee);
                dtEmployee.AcceptChanges();
                sda.Update(dtEmployee);
                return dtEmployee;
            }
        }

        internal DataTable ReadAll()
        {
            using (SqlConnection con1 = new SqlConnection(conString))
            {
                con1.Open();
                command = new SqlCommand();
                command.Connection = con1;
                command.CommandText = $"select * from Employees";
                sda = new SqlDataAdapter(command); 
                SqlDataReader reader = command.ExecuteReader();
                dtEmployee = new DataTable();
                dtEmployee.Load(reader);
                dtEmployee.AcceptChanges();
                sda.Update(dtEmployee);
                return dtEmployee;
            }
        }

    }
}
