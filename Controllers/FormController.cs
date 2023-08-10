using EmailWebApplication.Data;
using EmailWebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmailWebApplication.Controllers
{
    public class FormController : Controller
    {
        private readonly FormDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public FormController(FormDbContext db, IWebHostEnvironment webHostEnvironment )
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<EmailForm> EmailformList = _db.EmailForms.ToList();
            return View(EmailformList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmailForm obj, IFormFile? file)
        {
            if(obj.FirstName == obj.Email.ToString())
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
                _db.EmailForms.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Congratulations!, your registration is successful!";
                return RedirectToAction("Index");
            }
            return View();
              
        }

        public IActionResult Edit(int? id)
        {
            if(id== null || id== 0)
            {
                return NotFound();
            }
            EmailForm emailFormDB = _db.EmailForms.Find(id);
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
                //_db.EmailForms.Update(obj);
                var objFromDb = _db.EmailForms.FirstOrDefault(u => u.ID == obj.ID);
                if(objFromDb != null)
                {
                    objFromDb.FirstName = obj.FirstName;
                    objFromDb.LastName = obj.LastName;
                    objFromDb.Gender = obj.Gender;
                    objFromDb.Email = obj.Email;
                    if(obj.ImageUrl != null)
                    {
                        objFromDb.ImageUrl = obj.ImageUrl;
                    }
                }
                _db.SaveChanges();
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
            EmailForm? emailFormDB = _db.EmailForms.Find(id);

            if (emailFormDB == null)
            {
                return NotFound();
            }
            return View(emailFormDB);
        }


        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            EmailForm? emailFormDB2 = _db.EmailForms.Find(id);
            if (emailFormDB2 == null)
            {
                return NotFound();
            }
            _db.EmailForms.Remove(emailFormDB2);
            _db.SaveChanges();
            TempData["success"] = "Registration is deleted successfully!";
            return RedirectToAction("Index");

           
        }


    }
}
