using ASPNETMVC_Practica.Data;
using ASPNETMVC_Practica.Models;
using ASPNETMVC_Practica.Models.DomainModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPNETMVC_Practica.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly MVCDemoDbContext mvcDemoDbContext;

        //inyectamos el inyectet servier en corolador del constructor 
        //con esto se hace un campo de read only field para poder hanlar con LA BD 
        public EmployeesController(MVCDemoDbContext mvcDemoDbContext)
        {
            this.mvcDemoDbContext = mvcDemoDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index() // para agregar la los datos de los trabajadores de la bd 
        {
            var employees = await mvcDemoDbContext.Employees.ToListAsync();
            return View(employees);
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeeViewModel addEmployeeRequest)
        {
            var employee = new Employee()
            {
                Id = Guid.NewGuid(),
                Name = addEmployeeRequest.Name,
                Email = addEmployeeRequest.Email,
                Salary = addEmployeeRequest.Salary,
                Department = addEmployeeRequest.Department,
                DateofBirth = addEmployeeRequest.DateofBirth


            };
            await mvcDemoDbContext.Employees.AddAsync(employee); //agregar empleado 
            await mvcDemoDbContext.SaveChangesAsync();
            return RedirectToAction("Add");

        }
    }
}

