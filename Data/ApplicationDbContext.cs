using Microsoft.EntityFrameworkCore;
using WebApp1_6.Models;

namespace WebApp1_6.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) 
        {
           
        }

        public DbSet<CategoryModel> Category { get; set; }
    }
}
