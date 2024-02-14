using Buoi5.Repository;
using Buoi5_Code.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi5_Code.Services
{
    internal class EmployeeServices : IEmployee
    {
        private readonly PE_Fall21B5Context dbcontext;
        public EmployeeServices(PE_Fall21B5Context _context)
        {
            dbcontext = _context;  
        }

        public void AddEmp(Employee e)
        {
            using (var context = new PE_Fall21B5Context())
            {
                context.Employees.Add(e);
                context.SaveChanges();
                context.Dispose();
            }
        }

        public void DeleteEmp(int id)
        {
            using (var context = new PE_Fall21B5Context())
            {
                Employee e = context.Employees.FirstOrDefault(x => x.Id == id);
                if (e != null)
                {
                    context.Employees.Remove(e);
                    context.SaveChanges();
                    context.Dispose();
                }

            }
        }

        public List<Employee> GetAll()
        {
            List<Employee> list = new List<Employee>();
            using (var context = new PE_Fall21B5Context())
            {
                list = context.Employees.ToList();
                context.Dispose();
            }
            return list;
        }

        public Employee GetEmployee(int id)
        {
            Employee e = new Employee();
            using (var context = new PE_Fall21B5Context())
            {
                e = context.Employees.Where(x => x.Id == id).FirstOrDefault();
                context.Dispose();
            }
            return e;
        }

        public void UpEmp(Employee e)
        {
            using (var context = new PE_Fall21B5Context())
            {
                context.Employees.Update(e);
                context.SaveChanges();
                context.Dispose();
            }
        }
    }
}