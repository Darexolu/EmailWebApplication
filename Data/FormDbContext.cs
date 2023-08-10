using EmailWebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace EmailWebApplication.Data
{
    public class FormDbContext : DbContext
    {
        public FormDbContext(DbContextOptions<FormDbContext> options) : base(options)
        {

        }

        public DbSet<EmailForm> EmailForms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmailForm>().HasData(
                new EmailForm
                {ID = 1, FirstName = "Dare", LastName = "Seun",Gender = "Male",Email = "darexolu16@gmail.com",ImageUrl=""
                });
        }
    }
}
