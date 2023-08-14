using EmailWebApplication.Models;

namespace EmailWebApplication.Repositories.IRepository
{
    public interface IEmailFormRepository : IRepository<EmailForm>
    {
        void Update(EmailForm obj);
        void Save();
    }
}
