using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Portfolio.APP.DTOs.AppUser;
using Portfolio.APP.ServiceImplementations;
using Portfolio.APP.ServiceInterface;

namespace Portfolio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StackController : ControllerBase
    {
        private readonly IProfessionalStackService _pSS;
        public StackController(IProfessionalStackService pSS)
        {
            _pSS = pSS;
        }


        [HttpPost]

        public async Task<IActionResult> CreateStack([FromBody] CreateProfessionalStackDto Dto)
        {
            var result = await _pSS.AddProfessionalStackAsync(Dto);
            return result.success ? Ok(result) : BadRequest(result);
        }


        [HttpGet("stack_By{id}")]
        public async Task<IActionResult> GetStackById(Guid id)
        {
            var result = await _pSS.GetProfessionalStackById(id);
            return result.success ? Ok(result) : NotFound();
        }

        [HttpPut("update_By{id}")]

        public async Task<IActionResult> UpdateStack(Guid id, [FromBody] UpdateProfessionalStackDto dto)

        {
            var result = await _pSS.UpdateProfessionalStackAsync(id, dto);
            return result.success ? Ok(result) : NotFound(result);
        }

        [HttpDelete("{id}")]

        public async Task <IActionResult>DeleteStack(Guid id)
        {
            var result = await _pSS.DeleteProfessionalStackAsync(id);
            return result.success? Ok(result) : NotFound(result) ;
        }

        [HttpGet("allStack")]
        public async Task<IActionResult> GetAllStack([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
           var result = await _pSS.GetAllProfessionalStackAsync(pageNumber, pageSize);
            return Ok(result);
        }


    }
}