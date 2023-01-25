using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Models;
using Exam.DataManagement;

namespace Exam.Interfaces
{
    public interface IDataManager
    {
        public void Save(Supermarket supermarket);

        public Supermarket Load();
    }
}
