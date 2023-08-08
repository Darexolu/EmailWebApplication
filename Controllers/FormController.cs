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
            _db.EmailForms.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
           
        }

    }
}
