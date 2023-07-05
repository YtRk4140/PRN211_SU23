using Buoi5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi5.Repository
{
    public interface IDepartment
    {
        public Department GetDepartment(int id);
        public List<Department> GetAll();
    }
}
