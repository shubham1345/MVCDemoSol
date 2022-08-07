using MvcDemoAPI.Model;

namespace MvcDemoAPI.Repository
{
    public class EmployeeRepository : EmployeeAbs
    {
        private readonly EmpContext dbcontext = null;
        public EmployeeRepository(EmpContext _dbContxet)
        {
            dbcontext = _dbContxet;
        }

        public override bool Create(EmpModelAPI emp)
        {
            if(emp == null)
            {
                return false;
            }
            else
            {
                if(emp.Id == 0)
                {
                    dbcontext.Add(emp);
                    dbcontext.SaveChanges();
                    return true;
                }
                else
                {
                    dbcontext.Entry(emp).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    dbcontext.SaveChanges();
                    return true;
                }
            }
        }

        public override List<EmpModelAPI> Index()
        {
            return dbcontext.tblEmployee.ToList();
        }
        public override EmpModelAPI Edit(int id)
        {
            var a = dbcontext.tblEmployee.Find(id);
            return a;
        }
        public override bool Delete(int id)
        {
            var a = dbcontext.tblEmployee.Find(id);
            if(a == null)
            {
                return false;
            }
            else
            {
                dbcontext.Remove(a);
                dbcontext.SaveChanges();
                return true;
            }
        }
    }
}
