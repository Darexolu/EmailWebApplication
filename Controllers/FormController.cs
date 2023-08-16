using EmailWebApplication.Data;
using EmailWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.AspNetCore.Http;
using EmailWebApplication.Repositories.IRepository;
using Microsoft.Extensions.Hosting.Internal;

namespace EmailWebApplication.Controllers
{
    public class FormController : Controller
    {
        private readonly IEmailFormRepository _emailRepo;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public FormController(IEmailFormRepository db, IWebHostEnvironment webHostEnvironment )
        {
            _emailRepo = db;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<EmailForm> EmailformList = _emailRepo.GetAll().ToList();
            return View(EmailformList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmailForm obj, IFormFile? file)
        {    //work in progress
            //BuildEmailTemplate(obj.ID);

                //work in progress

            if(obj.FullName == obj.Email.ToString())
            {
                ModelState.AddModelError("FirstName", "The First Name cannot exactly match the Email");
            }
            //if (obj.FirstName != null && obj.FirstName.ToLower() == "test"){
            //    ModelState.AddModelError("", "Test is an invalid value");

            //}

            if (ModelState.IsValid)
            { 
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if(file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"Images\UserImages");

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    obj.ImageUrl = @"\Images\UserImages\" + fileName;
                }
                _emailRepo.Add(obj);
                _emailRepo.Save();
                TempData["success"] = "Congratulations!, your registration is successful!";
                return RedirectToAction("Index");
            }
            return View();
              
        }

        //work in progress

       //public void BuildEmailTemplate(int id)
       // {
       //     string body = System.IO.File.ReadAllText(HostingEnvironment.MapPath("~/EmailTemplate/") + "Text" + ".cshtml");
       // }










        //work in progress
        public IActionResult Edit(int? id)
        {
            if(id== null || id== 0)
            {
                return NotFound();
            }
            EmailForm emailFormDB = _emailRepo.Get(u => u.ID == id);
            //EmailForm emailFormDB1 = _db.EmailForms.FirstOrDefault(u=>u.ID==id);

            //EmailForm emailFormDB2 = _db.EmailForms.Where(u => u.ID == id).FirstOrDefault();

            if (emailFormDB == null)
            {
                return NotFound();
            }
            return View(emailFormDB);
        }
        [HttpPost]
        public IActionResult Edit(EmailForm obj, IFormFile? file)
        {
           
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);  
                    string productPath = Path.Combine(wwwRootPath, @"Images\UserImages");

                    if (!string.IsNullOrEmpty(obj.ImageUrl))
                    {
                        //delete the old image
                        var oldImagePath = Path.Combine(wwwRootPath, obj.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath)){
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    obj.ImageUrl = @"\Images\UserImages\" + fileName;
                }
                //_emailRepo.Update(obj);
                var objFromDb = _emailRepo.Get(u => u.ID == obj.ID);
                if(objFromDb != null)
                {
                    objFromDb.FullName = obj.FullName;
                    //objFromDb.LastName = obj.LastName;
                    objFromDb.Gender = obj.Gender;
                    objFromDb.Email = obj.Email;
                    objFromDb.Password = obj.Password;
                    if(obj.ImageUrl != null)
                    {
                        objFromDb.ImageUrl = obj.ImageUrl;
                    }
                }
                 //_emailRepo.Update(obj);
                _emailRepo.Save();
                TempData["success"] = "Registration is updated successfully!";
                return RedirectToAction("Index");
            }
            return View();


        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            EmailForm? emailFormDB = _emailRepo.Get(u => u.ID == id);

            if (emailFormDB == null)
            {
                return NotFound();
            }
            return View(emailFormDB);
        }


        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            EmailForm? emailFormDB2 = _emailRepo.Get(u => u.ID == id);
            if (emailFormDB2 == null)
            {
                return NotFound();
            }
            _emailRepo.Remove(emailFormDB2);
            _emailRepo.Save();
            TempData["success"] = "Registration is deleted successfully!";
            return RedirectToAction("Index");

           
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(EmailForm obj)
        {
            if (ModelState.IsValid)
            {
                var user = _emailRepo.GetAll().Where(u => u.Email == obj.Email && u.Password == obj.Password).FirstOrDefault();
                if(user != null)
                {
                    HttpContext.Session.SetString("FullName", user.FullName);
                    HttpContext.Session.SetString("Email", user.Email);
                    HttpContext.Session.SetString("Password", user.Password);
                    HttpContext.Session.SetString("ImageUrl", user.ImageUrl);


                    return RedirectToAction("Dashboard");

                }
                else 
                {
                     
                    ModelState.AddModelError("", "Invalid email or password");                    
                }

            }
            return View();
          
        }

        public IActionResult Dashboard()
        {

            ViewBag.FullName = HttpContext.Session.GetString("FullName");
            ViewBag.ImageUrl = HttpContext.Session.GetString("ImageUrl");

            return View();

        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("FullName");
            return RedirectToAction("Index");
        }


    }
}
