using Microsoft.AspNetCore.Mvc;
using MvcDemoAPI.Model;
using MvcDemoAPI.Repository;

namespace MvcDemoAPI.Controllers
{
    [ApiController]
    [Route("Api/[Controller]/[action]")]
    public class EmployeeAPI : Controller
    {
        private readonly EmployeeRepository repo = null;
        public EmployeeAPI(EmployeeRepository _repo)
        {
            repo = _repo;
        }
        public IActionResult Index()
        {
            var a = repo.Index();
            return Ok(a);
        }
        [HttpPost]
        public IActionResult Create(EmpModelAPI emp)
        {
            var a = repo.Create(emp);
            return Ok(a);
        }
        [HttpGet("{id}")]
        public IActionResult Edit(int id)
        {
            return Ok(repo.Edit(id));
        }
        [HttpGet("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(repo.Delete(id));
        }

    }
}
