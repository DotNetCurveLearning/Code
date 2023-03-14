using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packt.Shared
{
    public class Person
    {

        public Person()
        {

        }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public HashSet<Person> Children { get; set; }
        public decimal Salary { get; set; }

        public Person(decimal initialSalary)
        {
            initialSalary = initialSalary;
        }
    }
}
