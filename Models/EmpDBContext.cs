using Microsoft.EntityFrameworkCore;

namespace CRUD.Models
{
    public class EmpDBContext : DbContext
    {
        public EmpDBContext(DbContextOptions options) : base(options)    
        {

        }
        
        public DbSet<EmployeeDB> Employess { get; set; }
    }
}

