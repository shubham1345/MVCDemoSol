using Microsoft.EntityFrameworkCore;

namespace MvcDemoAPI.Model
{
    public class EmpContext: DbContext
    {
        public EmpContext(DbContextOptions<EmpContext> options):base (options)
        {

        }
        public DbSet<EmpModelAPI> tblEmployee { get; set; }
    }
}
