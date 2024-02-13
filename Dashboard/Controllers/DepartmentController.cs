using ApplicationService.ServiceImplementation;
using AutoMapper;
using Domain.DTO;
using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly DepartmentService _departmentService;
        private readonly EmployeeService _employeeService;
        private readonly IMapper _mapper;
        
        public DepartmentController(DepartmentService departmentService , EmployeeService employeeService, IMapper mapper)
        {
            this._departmentService = departmentService;
            this._employeeService= employeeService;
            this._mapper = mapper;
        }
        public IActionResult Index()
        {
            var data =  _departmentService.GetAll();
            return View(data);
        }

        public IActionResult Create(int Id = 0)
        {
            var viewModel = new DepartmentViewModel();
            viewModel.AllEmployees =  _employeeService.GetManagers();
            if (Id>0)
            {
                viewModel.Department = _departmentService.GetById(Id);
            }
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult AddDepartment([FromBody] DepartmentDTO model)
        {
            try
            {
                var result = _departmentService.Create(model);
                return Ok(result);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult UpdateDepartment( [FromBody] DepartmentDTO model)
        {
            try
            {
                var result = _departmentService.Update(model);
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
                var EmployeesInDepartmentCount = _employeeService.GetWhereCount(x => x.DepartmentId == Id);
                if (EmployeesInDepartmentCount > 0)
                {
                    return BadRequest(new { messsage = "this Department has one employee or more" });
                }
                var result = _departmentService.Delete(Id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { messsage = ex.Message });
            }
        }
    }
}
