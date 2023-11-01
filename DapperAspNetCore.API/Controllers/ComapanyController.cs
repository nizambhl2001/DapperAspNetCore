using DapperAspNetCore.API.Models;
using DapperAspNetCore.API.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperAspNetCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComapanyController : ControllerBase
    {
        private readonly ICompanyReposity _reposity;

        public ComapanyController(ICompanyReposity reposity) => _reposity = reposity;

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            return Ok(await _reposity.GetEmployees());
        } 
        [HttpGet("{id}")]
        public async Task<IActionResult> FindEmployee(int id)
        {
            var company = await _reposity.FindEmployee(id);
            if(company is null)
            {
                return NotFound();
            }
            return Ok(company);
            
        }
        [HttpGet("findEmp/{id}")]
        public async Task<IActionResult> findEmp(int id)
        {
            var company = await _reposity.FindEmp(id);
            if(company is null)
            {
                return NotFound();
            }
            return Ok(company);
            
        }
        [HttpPost("CreateEmployee")]
        public async Task<IActionResult> CreateEmployee(Employees employees)
        {
            var company = await _reposity.CreateEmployee(employees);
            return Ok(company);

        }
        [HttpPost("CreateEmp")]
        public async Task<IActionResult> CreateEmp(Employees employees)
        {
            var company = await _reposity.CreateEmp(employees);
            return Ok(company);
        } 
        [HttpPost("CreateEmpl")]
        public async Task<IActionResult> CreateEmpl(Employees employees)
        {
            var company = await _reposity.CreateEmpl(employees);
            return Ok(company);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteEmp(int id)
        {
            var company = await _reposity.DeleteEmp(id);
            return Ok(company);
            
        }
        [HttpPut]
        public async Task<IActionResult> UpdateEmp(Employees employees)
        {
            var company = await _reposity.UpdateEmployee(employees);
            return Ok(company);

        }


    }
}
