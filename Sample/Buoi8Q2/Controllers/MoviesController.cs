using Buoi8Q2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Buoi8Q2.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult Director_Movie(int id)
        {
            using (var context = new PE_PRN_Fall22B1Context())
            {
                List<Director> listd = context.Directors.ToList();

                List<Movie> movies = new List<Movie>();
                if (id == 0)
                {
                    movies = context.Movies.Include(x => x.Stars).ToList();
                }
                else
                {
                    movies = context.Movies.Where(x=>x.DirectorId== id).Include(x => x.Stars).ToList();
                    ViewBag.id = id;
                }
                  

                foreach(Movie item in movies)
                {
                    item.Director = context.Directors.FirstOrDefault(x => x.Id == item.DirectorId);
                    item.Producer = context.Producers.FirstOrDefault(x => x.Id == item.ProducerId);
                }

                ViewBag.listd = listd;
                ViewBag.movies = movies;
            }
                return View();
        }
        public IActionResult Delete(int idmovie, int idstar)
        {
            using (var context= new PE_PRN_Fall22B1Context())
            {
                Movie m = context.Movies.Include(x => x.Stars).FirstOrDefault(x => x.Id == idmovie);
                // kem theo no da load ra list start cua movie m
                if(m != null)
                {
                    Star s = context.Stars.FirstOrDefault(x => x.Id == idstar);
                    if(s != null)
                    {
                        m.Stars.Remove(s);
                        context.SaveChanges();
                    }
                }
            }
                return RedirectToAction("Director_Movie");
        }
    }
}
