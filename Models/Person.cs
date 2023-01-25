using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    public abstract class Person
    {
        public string Name { get; set; }
        public string LastName { get; set; }

        public Person(string name, string lastName)
        {
            this.Name = name;
            this.LastName = lastName;
        }
    }
}
