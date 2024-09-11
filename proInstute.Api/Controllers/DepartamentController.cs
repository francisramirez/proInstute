using Microsoft.AspNetCore.Mvc;
using proInstute.Api.Models.Department;
using proInstute.Domian.Models;
using proInstute.Persistence.Interfaces;
using proInstute.Persistence.Models.Department;
using System.Collections.Generic;


namespace proInstute.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentController : ControllerBase
    {
        private readonly IDepartmentRepository departmentRepository;

        public DepartamentController(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }
        [HttpGet("GetDepartments")]
        public async Task<IActionResult> Get()
        {
            DataResult<List<DepartmentModel>> result = new DataResult<List<DepartmentModel>>();

            result = await this.departmentRepository.GetDepartments();

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }


        [HttpGet("GetDepartmentById")]
        public async Task<IActionResult> Get(string name)
        {
            DataResult<DepartmentModel> result = new DataResult<DepartmentModel>();

            result = await this.departmentRepository.GetDepartments(name);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // POST api/<DepartamentController>
        [HttpPost("CreateDepartment")]
        public async Task<IActionResult> Post([FromBody] DepartmentSaveDto departmentSave)
        {
            bool result = false;

            result = await this.departmentRepository.Save(new Domian.Entities.Department()
            {
                Budget = departmentSave.Budget,
                Administrator = departmentSave.Administrator,
                CreationDate = departmentSave.CreeateDate,
                CreationUser = departmentSave.CreationUser,
                Name = departmentSave.Name,
                StartDate = departmentSave.StartDate
            });

            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }

        // PUT api/<DepartamentController>/5
        [HttpPost("UpdateDepartment")]
        public async Task<IActionResult> Put([FromBody] DepartmentUpdateDto departmentUpdate)
        {
            bool result = false;

            result = await this.departmentRepository.Update(new Domian.Entities.Department()
            {
                Budget = departmentUpdate.Budget,
                Administrator = departmentUpdate.Administrator,
                ModifyDate = departmentUpdate.ModifyDate,
                CreationUser = departmentUpdate.ModifyUser,
                Name = departmentUpdate.Name,
                StartDate = departmentUpdate.StartDate,
                Id = departmentUpdate.DepartmentId
            });

            if (!result)
            {
                return BadRequest();
            }

            return Ok();

        }
    }
}
