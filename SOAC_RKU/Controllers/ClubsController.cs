using Microsoft.AspNetCore.Mvc;
using SOAC_RKU.Data;
using SOAC_RKU.Models;
using Microsoft.AspNetCore.Http;
using NuGet.DependencyResolver;

namespace SOAC_RKU.Controllers
{
   

    public class ClubsController : Controller
    {
        private readonly SOAC_RKUContext   _context;

        public ClubsController(SOAC_RKUContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public IActionResult ClubReg()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ClubReg(Clubs c)
        {
            if (ModelState.IsValid)
            {
                var club = new Clubs()
                {
                    Enrollment_id = HttpContext.Session.GetString("EnrollmentId").Trim().ToUpper(),
                    Club_name = c.Club_name,
                    Mentor_name = c.Mentor_name,
                    Fees = c.Fees,
                };
                _context.Clubs.Add(club);
                _context.SaveChanges();
                return View("ClubDetails","Clubs");
            }
            else
            {
                return View();

            }
            
                
               
        }

        [HttpGet]
        public IActionResult Clubdetails() {
            
                var result = _context.Clubs.ToList();
                return View(result);
        }

        
        
    }
}
