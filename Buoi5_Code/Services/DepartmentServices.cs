using Buoi5_Code.Models;
using Buoi5_Code.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi5_Code.Services
{
    public class DepartmentServices : IDepartment
    {
        private readonly PE_Fall21B5Context dbcontext;
        public DepartmentServices(PE_Fall21B5Context _context)
        {
            dbcontext = _context;
        }

        public List<Department> GetAll()
        {
            List<Department> listd = new List<Department>();
            using (var context = new PE_Fall21B5Context())
            {
                listd = context.Departments.ToList();
            }
            return listd;
        }

        public Department GetDepartment(int id)
        {
            Department d = new Department();
            using (var context = new PE_Fall21B5Context())
            {
                d = context.Departments.FirstOrDefault(x => x.Id == id);
            }
            return d;
        }
    }
}
