using Microsoft.AspNetCore.Mvc;
using WebApplication6.Models;
using WebApplication6.Service;

namespace WebApplication6.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeControler : ControllerBase
    {
        private readonly ServiceEmployer _Empservice;

        public EmployeeControler(ServiceEmployer service)
        {
            _Empservice = service;
        }
        [HttpGet]
        public async Task <ActionResult<List<Employe>>> GetAll()
        {
            return Ok(await _Empservice.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employe?>> Get(int id)
        {
            var employee = await _Empservice.GetAsync(id);
            return employee == null ? NotFound() : Ok(employee);
        }
        [HttpPost]
        public async Task<IActionResult> Add(Employe employe)
        {
            await _Empservice.AddAsync(employe);
            return employe == null ? NotFound() : Ok(employe);
        }
        
        [HttpPut("{id}")]
        public async Task <IActionResult> Update(int id ,Employe updated)
        {
           var success = await _Empservice.UpdateAsync(id, updated);
            return success ? NoContent() : NotFound();
        }
        [HttpDelete("{id}")]
        public async Task <IActionResult> Delete(int id)
        { 
           var success = await _Empservice.DeleteAsync(id);
            return success ? NoContent() : NotFound();
        }
    }
}
