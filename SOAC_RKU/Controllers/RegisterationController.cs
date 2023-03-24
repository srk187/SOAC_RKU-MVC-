using Microsoft.AspNetCore.Mvc;
using SOAC_RKU.Data;

namespace SOAC_RKU.Controllers
{
    public class RegisterationController : Controller
    {
        private readonly SOAC_RKUContext context;
        public RegisterationController(SOAC_RKUContext context) {
            this. context = context;
        }

        [HttpGet]
        public ActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]  
        public ActionResult AddStudent(Student s)
        {
            if(ModelState.IsValid == true)
            {
                var sdata = new Student()
                {
                    Enrollment_Id = s.Enrollment_Id,
                    Name = s.Name,
                    Email = s.Email,
                    Contact = s.Contact,
                    City = s.City,
                    Age = s.Age,
                    Address = s.Address,
                    Password = s.Password,
                    Department = s.Department
                };
                context.Student.Add(sdata);
                context.SaveChanges();
                return RedirectToAction("Login", "Login");

            }
            else
            {
                return View();
            }
        }
        

        //[HttpGet]
        //public IActionResult AddStudent()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult AddStudent(Student s)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        var student = new Student()
        //        {
        //            Enrollment_Id= s.Enrollment_Id,
        //            Name= s.Name,
        //            Email = s.Email,
        //            Address= s.Address,
        //            City    = s.City,
        //            Department= s.Department,
        //            Age = s.Age,
        //            Contact = s.Contact,
        //            Password = s.Password,

        //        };
        //        context.Student.Add(student);
        //        context.SaveChanges();
        //        return RedirectToAction("Login", "Login");


        //    }
        //    else
        //    {
        //        TempData["error"] = "Please fill all Data";
        //        return RedirectToAction("");
        //    }
        //}
    }
}
