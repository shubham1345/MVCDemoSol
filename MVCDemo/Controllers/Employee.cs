using Microsoft.AspNetCore.Mvc;
using MVCDemo.Models;
using Newtonsoft.Json;

namespace MVCDemo.Controllers
{
    public class Employee : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<EmpModel> emp = new List<EmpModel>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7093/");
            var res = await client.GetAsync("api/EmployeeApi/Index");
            if(res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                emp = JsonConvert.DeserializeObject<List<EmpModel>>(result);
            }
            return View(emp);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmpModel Emp)
        {
            if (!ModelState.IsValid)
            {
                return View(Emp);
            }
            else
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:7093/");
                var ressult = client.PostAsJsonAsync("api/employeeapi/create", Emp);
                ressult.Wait();
                var res = ressult.Result;
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
        }
        public async Task<IActionResult> Edit(int id)
        {
            EmpModel emp = new EmpModel();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7093/");
            var res = await client.GetAsync($"api/EmployeeApi/Edit/{id}");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                emp = JsonConvert.DeserializeObject<EmpModel>(result);
            }
            return View(emp);
        }
        public async Task<IActionResult> Delete(int id)
        {
           
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7093/");
            var res = await client.GetAsync($"api/EmployeeApi/Delete/{ id}");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                bool a  = JsonConvert.DeserializeObject<bool>(result);
            }
            return RedirectToAction("Index");
        }

    }
}
