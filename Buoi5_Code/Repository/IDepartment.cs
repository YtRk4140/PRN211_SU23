using Buoi5_Code.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi5_Code.Repository
{
    public interface IDepartment
    {
        public Department GetDepartment(int id);
        public List<Department> GetAll();
    }
}
