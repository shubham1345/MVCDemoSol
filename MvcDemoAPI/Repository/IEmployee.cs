using MvcDemoAPI.Model;

namespace MvcDemoAPI.Repository
{
    public interface IEmployee
    {
        List<EmpModelAPI> Index();
        bool Create(EmpModelAPI emp);
        EmpModelAPI Edit(int id);
        bool Delete(int id);

    }
    public abstract class EmployeeAbs : IEmployee
    {
        public abstract List<EmpModelAPI> Index();
        public abstract bool Create(EmpModelAPI emp);
        public abstract EmpModelAPI Edit(int id);
        public abstract bool Delete(int id);
    }
}
