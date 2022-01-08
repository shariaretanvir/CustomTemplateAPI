using CustomTemplateAPI.Models;
using CustomTemplateAPI.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CustomTemplateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        public ILogger<StudentsController> Logger { get; }
        public IServiceUnitOfWork ServiceUnitOfWork { get; }

        public StudentsController(ILogger<StudentsController> logger,IServiceUnitOfWork serviceUnitOfWork)
        {
            Logger = logger;
            ServiceUnitOfWork = serviceUnitOfWork;
        }

        [HttpPost,Route("save")]
        public async Task<IActionResult> Save([FromBody] Student student)
        {
            try
            {
                if(await ServiceUnitOfWork.StudentService.SaveStudent(student) == 1)
                {
                    return Ok("Save Successfully");
                }
                else
                {
                    return Ok("SOmething went wrong");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }            
        }

        [HttpGet,Route("getall")]
        public async Task<IActionResult> getall()
        {
            try
            {
                return Ok(await ServiceUnitOfWork.StudentService.GetAllStudents());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
