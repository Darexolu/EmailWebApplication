using EmailWebApplication.Data;
using EmailWebApplication.Models;
using EmailWebApplication.Repositories.IRepository;
using System.Linq.Expressions;

namespace EmailWebApplication.Repositories
{
    public class EmailFormRepository : Repository<EmailForm>, IEmailFormRepository
    {
        public readonly FormDbContext _db;
        public EmailFormRepository(FormDbContext db): base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(EmailForm obj)
        {
            _db.EmailForms.Update(obj);
        }
    }
}
