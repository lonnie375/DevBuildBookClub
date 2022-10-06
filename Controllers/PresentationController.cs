using DevBuildMVCBookClub.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevBuildMVCBookClub.Controllers
{
    public class PresentationController : Controller
    {
        public IActionResult Index()
        {
            List<Presentation> presentation = DAL.GetAllPresentations();
            return View(presentation);
        }

        public IActionResult AddForm()
        {
            List<Person> list = DAL.GetAllPeople();
          
            return View(list);  
        }

        public IActionResult Add(Presentation present)
        {
          
            bool errorFound = false; 
            if (present.PresentationDate < DateTime.Now)
            {
                ViewBag.PresentMessage = "Please enter a valid date";
                errorFound = true; 
            }
            if (present.BookTitle == null)
            {
                ViewBag.TitleMessage = "Please enter a Book Title";
                errorFound = true; 
            }
            if (present.BookAuthor == null)
            {
                ViewBag.AuthorMessage = "Please enter a Book Author";
                errorFound = true; 
            }
            if (present.Genre == null)
            {
                ViewBag.GenreMessage = "Please enter a Genre";
                errorFound = true; 
            }

            if (errorFound == false)
            {
                DAL.InsertPresentation(present);
                return Redirect("/presentation"); 
            }
            else
            {
                List<Person> list = DAL.GetAllPeople();
                return View("AddForm",list);   
            }
          
        }

        public IActionResult EditPresentation(int id)
        {
            Presentation p = DAL.GetOnePresentation(id);
            return View(p); 
        }

        public IActionResult SaveChanges(Presentation p)
        {
            DAL.UpdatePresentation(p);
            return Redirect("/presentation"); 
        }

        public IActionResult Details(int id)
        {
            return View(DAL.GetOnePresentation(id)); 
        }

        public IActionResult Delete(int id)
        {
            DAL.DeletePresentation(id);
            return Redirect("/presentation"); 
        }
    }

    
}
