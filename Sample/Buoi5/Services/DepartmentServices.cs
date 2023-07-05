using Buoi5.Models;
using Buoi5.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi5.Services
{
    public class DepartmentServices : IDepartment
    {
      
        public DepartmentServices()
        {
      
        }

        public List<Department> GetAll()
        {
            List<Department> listd = new List<Department>();
            using (var context = new PE_Fall21B5Context())
            {
                listd = context.Departments.ToList();
                context.Dispose();
            }
            return listd;

        }

        public Department GetDepartment(int id)
        {
            Department d = new Department();
            using (var context = new PE_Fall21B5Context())
            {
                d= context.Departments.FirstOrDefault(x => x.Id == id);
                context.Dispose();
            }
            return d;

        }
    }
}
