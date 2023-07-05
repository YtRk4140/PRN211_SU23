using Buoi5.Models;
using Buoi5.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi5.Services
{
    public class EmployeeServices : IEmployee
    {
        

        public EmployeeServices()
        {
            
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
                if(e!= null)
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
                list= context.Employees.ToList();
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
