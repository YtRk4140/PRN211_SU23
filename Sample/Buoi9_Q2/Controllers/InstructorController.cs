using Buoi9_Q2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Buoi9_Q2.Controllers
{
    public class InstructorController : Controller
    {
        public IActionResult List()
        {
            using (var context = new PE_PRN_Spr23_B5Context())
            {
                List<Department> listd = context.Departments.ToList();
                List<Instructor> listi = context.Instructors.ToList();
                List<Instructor2> list2 = new List<Instructor2>();
                foreach(Instructor item in listi)
                {
                    Instructor2 i2 = new Instructor2();
                    i2.InstructorId = item.InstructorId;
                    i2.Fullname = item.Fullname;
                    i2.ContractDate = item.ContractDate;
                    i2.IsFulltime = item.IsFulltime;
                    i2.Department = item.Department;
                    i2.DepartmentName = context.Departments.FirstOrDefault(x => x.DepartmentId == item.Department).DepartmentName;
                    list2.Add(i2);
                }

                ViewBag.listd = listd;
                ViewBag.listi = list2;

            }
                return View();
        }

        [HttpPost]
        public IActionResult Search()
        {
            using (var context = new PE_PRN_Spr23_B5Context())
            {
                string de = HttpContext.Request.Form["de"];
                string con= HttpContext.Request.Form["con"];
                string sort= HttpContext.Request.Form["sort"];

              

                List<Department> listd = context.Departments.ToList();
                List<Instructor> listi = context.Instructors
                    .Where(x=>x.Department== int.Parse(de)&& x.IsFulltime== bool.Parse(con)).ToList();
                List<Instructor2> list2 = new List<Instructor2>();
                foreach (Instructor item in listi)
                {
                    Instructor2 i2 = new Instructor2();
                    i2.InstructorId = item.InstructorId;
                    i2.Fullname = item.Fullname;
                    i2.ContractDate = item.ContractDate;
                    i2.IsFulltime = item.IsFulltime;
                    i2.Department = item.Department;
                    i2.DepartmentName = context.Departments.FirstOrDefault(x => x.DepartmentId == item.Department).DepartmentName;
                    list2.Add(i2);
                }
                if(sort == "1")
                {
                    list2 = list2.OrderBy(x => x.Fullname).ToList();
                }
                else if (sort == "2")
                {
                    list2 = list2.OrderBy(x => x.InstructorId).ToList();
                }
                else
                {
                    list2 = list2.OrderBy(x => x.ContractDate).ToList();
                }

                ViewBag.listd = listd;
                ViewBag.listi = list2;

            }
            return View();
        }
    }
}
