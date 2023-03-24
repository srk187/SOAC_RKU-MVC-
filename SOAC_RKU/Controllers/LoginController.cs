using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SOAC_RKU.Data;
using SOAC_RKU.Models;

namespace SOAC_RKU.Controllers
{
    public class LoginController : Controller
    {
        private readonly SOAC_RKUContext _context;

        public LoginController( SOAC_RKUContext context)
        {
            this._context = context; 
        }
        // GET: LoginController
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login l)
        {
            if(ModelState.IsValid == true)
            {
                var credential =  _context.Student.Where(model=> model.Enrollment_Id == l.Enrollment_Id
                && model.Password == l.Password ).FirstOrDefault();
                if (credential == null)
                {
                    ViewBag["Error"] = "Please First Register";
                    return View();
                }
                else
                {
                    HttpContext.Session.SetString("EnrollmentId", l.Enrollment_Id.ToUpper().Trim());

                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return View();
            }
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

    }
}
