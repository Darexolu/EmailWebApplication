using EmailWebApplication.Data;
using EmailWebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmailWebApplication.Controllers
{
    public class FormController : Controller
    {
        private FormDbContext _db;
        public FormController(FormDbContext db)
        {
            _db = db;
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
        public IActionResult Create(EmailForm obj)
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
                _db.EmailForms.Add(obj);
                _db.SaveChanges();
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
        public IActionResult Edit(EmailForm obj)
        {
           
            if (ModelState.IsValid)
            {
                _db.EmailForms.Update(obj);
                _db.SaveChanges();
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
            return RedirectToAction("Index");

           
        }


    }
}
