using CustomTemplateAPI.Models;
using CustomTemplateAPI.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomTemplateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        public ILogger<StudentsController> Logger { get; }
        public IEnumerable<IServiceUnitOfWork> ServiceUnitOfWork { get; }

        public StudentsController(ILogger<StudentsController> logger, IEnumerable<IServiceUnitOfWork> serviceUnitOfWork)
        {
            Logger = logger;
            ServiceUnitOfWork = serviceUnitOfWork;
        }

        [HttpPost,Route("save")]
        public async Task<IActionResult> Save([FromBody] Student student)
        {
            try
            {
                var stdrepo = ServiceUnitOfWork.SingleOrDefault(t => t.GetType() == typeof(ServiceUnitOfWork));
                //var repo1 = ServiceUnitOfWork.SingleOrDefault(t => t.GetType() == typeof(ServiceUnitofWork1));
                //var a = stdrepo.StudentService.GetAllStudents();
                //var b = repo1.StudentService.GetAllStudents();
                if (await stdrepo.StudentService.SaveStudent(student) == 1)
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
                var stdservice = ServiceUnitOfWork.SingleOrDefault(t => t.GetType() == typeof(ServiceUnitOfWork));
                return Ok(await stdservice.StudentService.GetAllStudents());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
