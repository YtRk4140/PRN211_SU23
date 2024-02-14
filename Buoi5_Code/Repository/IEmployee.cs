using Buoi5_Code.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi5.Repository
{
    public interface IEmployee
    {
        /// <summary>
        /// lay tat ca Emp
        /// </summary>
        public List<Employee> GetAll();
        /// <summary>
        /// lat ra emp theo id
        /// </summary>
        /// <param name="id"></param>
        public Employee GetEmployee(int id);
        public void UpEmp(Employee e);
        public void AddEmp(Employee e);
        public void DeleteEmp(int id);
    }
}