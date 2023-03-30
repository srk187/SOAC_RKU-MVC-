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
                return View("Clubdetails", "Clubs");
            }
            else
            {
                return View();

            }
            
                
               
        }

        
        public IActionResult Clubdetails() {

            var result = _context.Clubs.ToList();
                return View(result);
        }

        public IActionResult Delete(string enroll)
        {
            var enrollment = _context.Clubs.SingleOrDefault(e => e.Enrollment_id == enroll);
            _context.Clubs.Remove(enrollment); _context.SaveChanges();
            return RedirectToAction("Index","Home");
        }
        [HttpGet]
        public IActionResult Edit(string enroll)
        {
            var enrollment = _context.Clubs.SingleOrDefault(item => item.Enrollment_id == enroll);
            var result = new Clubs()
            {
                Enrollment_id = enrollment.Enrollment_id,
                Club_name = enrollment.Club_name,
                Mentor_name = enrollment.Mentor_name,
                Fees = enrollment.Fees,
            };
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Clubs sport)
        {
            var update = new Clubs()
            {
                Enrollment_id = sport.Enrollment_id,
                Club_name = sport.Club_name,
                Mentor_name = sport.Mentor_name,
                Fees = sport.Fees,
            };
            _context.Clubs.Update(update);
            _context.SaveChanges();
            return RedirectToAction("Clubdetails");


        }


    }
}
