using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models
{
    public class Task
    {
        public string TaskName { get; set; }
        public string Definition { get; set; }
        public string Deadline { get; set; }

        public Task(string taskName, string definition, string deadline)
        {
            this.TaskName = taskName;
            this.Definition = definition;
            this.Deadline = deadline;
        }

        public override string ToString()
        {
            return $"--Task: {this.TaskName}/ Task Objective: {this.Definition}/ Deadline: {this.Deadline}";
        }
    }
}
