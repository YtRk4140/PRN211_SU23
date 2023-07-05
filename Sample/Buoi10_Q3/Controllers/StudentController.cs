using Buoi10_Q3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Buoi10_Q3.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult List()
        {
            using(var context = new PE_PRN211_23SprB1Context())
            {
                List<Student> lists = context.Students.ToList();
                ViewBag.lists = lists;
            }
            return View();
        }
        [HttpPost]
        public IActionResult Search()
        {
            using (var context = new PE_PRN211_23SprB1Context())
            {
                string sex = HttpContext.Request.Form["sex"];
                List<Student> lists = context.Students.Where(x=>x.Sex== sex).ToList();
                ViewBag.lists = lists;
                ViewBag.value = sex;
            }
            return View();
        }
    }
}
