using ApplicationService.ServiceImplementation;
using AutoMapper;
using Domain.DTO;
using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly DepartmentService _departmentService;
        private readonly EmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeeController(DepartmentService departmentService, EmployeeService employeeService, IMapper mapper)
        {
            this._departmentService = departmentService;
            this._employeeService = employeeService;
            this._mapper = mapper;
        }
        public IActionResult Index()
        {
            var data = _employeeService.GetAll();
            return View(data);
        }

        public IActionResult Create(int Id = 0)
        {
            var viewModel = new EmployeeViewModel();
            viewModel.AllDepartments = _departmentService.GetAll();
            viewModel.AllEmployees = _employeeService.GetAll();
            if (Id > 0)
            {
                viewModel.Employee = _employeeService.GetById(Id);
            }
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult AddEmployee([FromBody] EmployeeDTO model)
        {
            try
            {
                var result = _employeeService.Create(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult UpdateEmployee([FromBody] EmployeeDTO model)
        {
            try
            {
                var result = _employeeService.Update(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            try
            {
                var result = _employeeService.Delete(Id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
