using Microsoft.AspNetCore.Mvc;
using SOAC_RKU.Data;
using SOAC_RKU.Models;
using System.Composition;
using System.Drawing;
using System.Linq;

namespace SOAC_RKU.Controllers
{
    public class SportsController : Controller
    {
        private readonly SOAC_RKUContext _context;
        public SportsController(SOAC_RKUContext context)
        {
            this._context = context;
        }
        [HttpGet]

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Sports sport)
        {
            if (ModelState.IsValid)
            {
                var s = new Sports()
                {
                    Enrollment_id = HttpContext.Session.GetString("EnrollmentId"),
                    Sport_Name = sport.Sport_Name,
                    Mentor_name = sport.Mentor_name,
                    Fees = sport.Fees,
                };
                _context.Sports.Add(s);
                _context.SaveChanges();


                return RedirectToAction("EventsDetail","Sports");
            }
            else
            {
                return View();
            }
        }


        public IActionResult EventsDetail()
        {
            var result = _context.Sports.ToList();
            return View(result);
        }
        public IActionResult Delete(string enroll)
        {
            var deleterecord = _context.Sports.FirstOrDefault(items => items.Enrollment_id == enroll);
            _context.Sports.Remove(deleterecord);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Edit(string enroll)
        {
            var enrollment = _context.Sports.SingleOrDefault(item => item.Enrollment_id == enroll);
            var result = new Sports()
            {
                Enrollment_id = enrollment.Enrollment_id,
                Sport_Name = enrollment.Sport_Name,
                Mentor_name = enrollment.Mentor_name,
                Fees = enrollment.Fees,
            };
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Sports sport)
        {
            var update = new Sports()
            {
                Enrollment_id = sport.Enrollment_id,
                Sport_Name  =  sport.Sport_Name,
                Mentor_name = sport.Mentor_name,
                Fees = sport.Fees,
            };
            _context.Sports.Update(update);
            _context.SaveChanges();
            return RedirectToAction("EventsDetail", "Sports");
            

        }
       
    }
}
