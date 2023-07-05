using Buoi7Q3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Buoi7Q3.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult List()
        {
            using (var context = new PE_Fall21B5Context())
            {
                List<Employee> list = context.Employees.ToList();
                var group = list.GroupBy(x => x.Position);
                ViewData["list"]=list;
                ViewBag.listg = group.ToList();
                
                return View();
            }
               
        }
        [HttpPost]
        public IActionResult Search()
        {
            using (var context = new PE_Fall21B5Context())
            {

                List<Employee> list = context.Employees.ToList();
                string pos = HttpContext.Request.Form["pos"];
                var group = list.GroupBy(x => x.Position);
                if (pos == "all")
                {
                    list = list;
                }
                else
                {
                    list = list.Where(x=>x.Position== pos).ToList();   
                }
                ViewBag.pos= pos;
                ViewData["list"] = list;
                ViewBag.listg = group.ToList();

                return View();
            }

        }
        public IActionResult Delete(int id)
        {
            using (var context = new PE_Fall21B5Context())
            {
                Employee e1 = context.Employees.FirstOrDefault(x => x.Id == id);
                context.Employees.Remove(e1);
                context.SaveChanges();
            }
            // sau khi xoa no xong
            // dieu huong ve action List
            return RedirectToAction("List");
           // return Redirect("/Employee/List");
        }
    }
}
