using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeEF
{
    [Serializable]
    public class Employee
    {
        public string Name { get; set; }
        public string Company { get; set; }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmployeeID { get; set; }
        public string Address { get; set; }

        public Employee() { }
        public Employee(string name, string company, int id, string address)
        {
            Name = name;
            Company = company;
            EmployeeID = id;
            Address = address;
        }
    }
}