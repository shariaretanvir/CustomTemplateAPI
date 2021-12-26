using CustomTemplateAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CustomTemplateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        public ILogger<StudentsController> Logger { get; }
        public StudentsController(ILogger<StudentsController> logger)
        {
            Logger = logger;
        }

        [HttpPost,Route("save")]
        public async Task<IActionResult> Save([FromBody] Student student)
        {
            return Ok();
        }
    }
}
