using DevBuildMVCBookClub.Models; 
using Microsoft.AspNetCore.Mvc;

namespace DevBuildMVCBookClub.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            //List all people in this view 
            List<Person> list = DAL.GetAllPeople();
            
            return View(list);
        }

        public IActionResult AddForm()
        {
            //Create the form for people to be added
            return View();
        }

        public IActionResult Add(Person newPerson)
        {
            bool errorFound = false;    
            if (newPerson.FirstName == null)
            {
                ViewBag.FirstNameMessage = "Please enter your first name";
                errorFound = true; 
            }
            if (newPerson.LastName == null)
            {
                ViewBag.LastNameMessage = "Please enter your Last name";
                errorFound = true;
            }
            if ( newPerson.email == null || !newPerson.email.Contains('@') )
            {
                ViewBag.EmailMessage = "Please enter an email with @";
                errorFound = true;
            }

            if (errorFound == false)
            {
                DAL.InsertPerson(newPerson);
                return View("Details", newPerson);
            }
            else
            {
                return View("AddForm"); 
            }
            
          
        }

        public IActionResult Details(int id)
        {
            return View(DAL.GetOnePerson(id));  
        }

        public IActionResult EditPerson(int id)
        {
            Person p = DAL.GetOnePerson(id);    
            return View(p);
        }

        public IActionResult SaveChanges(Person p)
        {
            DAL.UpdatePerson(p); 
            return Redirect("/person");
        }

        public IActionResult Delete(int id)
        {
            DAL.DeletePerson(id);
            return Redirect("/person");
        }
    }
}
