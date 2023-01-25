using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models
{
    public class Employee : Person
    {
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public int YearsOfExperience { get; set; }
        public List<Task> Tasks { get; set; }

        public Employee(string name, string lastName, string position, decimal salary, int yearsOfExperience)
            : base(name, lastName)
        {
            this.Position = position;
            this.Salary = salary;
            this.YearsOfExperience = yearsOfExperience;
            this.Tasks = new List<Task>();
        }

        public override string ToString()
        {
            return $"{this.Name} {this.LastName} \n{string.Join("\n", this.Tasks)}";
        }
    }
}
