using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace EmployeeEF
{
    public class EmployeeBusinessLogic : Employee
    {
        public List<Employee> Emps { get; private set; }
        static EmployeeDAO eDAO = new EmployeeDAO();

        public EmployeeBusinessLogic() { }

        public static void Create(Employee e)
        {
            using(var context = new EmployeeContext())
            {
                //check if the id already exists before creating otherwise create
                if (context.Employees.FirstOrDefault(emp=> emp.EmployeeID == e.EmployeeID) == null)
                {
                    //PK does not exist
                    eDAO.Create(e);
                    MessageBox.Show("Data Saved!");
                }
                else
                {
                    //if the user is trying to create a user with a pre-existant PK
                    MessageBox.Show("A user id with this id already exists. Please update this user or create a user with a different id");
                }
            }
        }
        public static DataTable GetAllFill()
        {
            return eDAO.Fill();
        }
        public static DataTable GetAll()
        {
            return eDAO.ReadAll();
        }

        public static Employee GetByID(string id)
        {
            using (var context = new EmployeeContext()) {
                //check if id exists first, check if it is a number
                try
                {
                    int x = Int32.Parse(id);
                    if (context.Employees.FirstOrDefault(emp => emp.EmployeeID == x) == null)
                    {
                        MessageBox.Show("A user with this id does not exist");
                        return null;
                    }
                    else
                    {
                        Employee emp = eDAO.Read(x);
                        return emp;
                    }
                }
                catch
                {
                    MessageBox.Show("Please input an integer as id");
                    return null;
                }
            }
            
        }

        public static void Update(Employee e)
        {
            using (var context = new EmployeeContext())
            {
                //check for the employee's id existing
                if (context.Employees.FirstOrDefault(emp => emp.EmployeeID == e.EmployeeID) == null)
                {
                    MessageBox.Show("A user with this id does not exist");
                }
                else
                {
                    eDAO.Update(e);
                    MessageBox.Show("Updated!");
                }
            }
            
        }

        public static void Delete(string id)
        {
            //check if that id is an integer
            try
            {
                int x = Int32.Parse(id);
                using (var context = new EmployeeContext())
                {
                    var result = context.Employees.SingleOrDefault(b => x == b.EmployeeID);
                    if (result != null)
                    {
                        eDAO.Delete(result);
                    }
                    else
                    {
                        MessageBox.Show("A user with this id does not exist");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Please input an integer as id");
            }
            
        }
    }
}