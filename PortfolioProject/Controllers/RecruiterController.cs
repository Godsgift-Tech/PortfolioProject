using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Portfolio.APP.DTOs.Recruiter;
using Portfolio.APP.ServiceImplementations;
using Portfolio.APP.ServiceInterface;

namespace Portfolio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecruiterController : ControllerBase
    {
        private readonly IRecruiterService _rS;
        public RecruiterController(IRecruiterService rS)
        {
            _rS = rS;
        }

        [HttpPost]

        public async Task<IActionResult> CreateRecruiter([FromBody] CreateRecruiterProfileDto dto)
        {
            var result = await _rS.CreateRecruiterAsync(dto);
            return result.success ? Ok(result) : BadRequest(result);
        }

     

        [HttpGet("getBy_{id}")]
        public async Task<IActionResult>GetRecruiter(Guid id)
        {
            var result = await _rS.GetRecruiterById(id);
            return result.success ? Ok(result):NotFound(result);


        }
        [HttpGet("{userId}")]
        public async Task<IActionResult>GetRecruiterDetails(Guid userId)
        {
            var result = await _rS.GetRecruiterByUserId(userId);
            return result.success ? Ok(result) : NotFound(result);
        }

        [HttpGet("allRecruiters")]
        public async Task<IActionResult> GetAllRecruiters([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
          var result = await _rS.GetAllRecruitersAsync(pageNumber, pageSize);
            return Ok(result);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateRecruiterProfileDto dto)
        {
            var result = await _rS.UpdateRecruiterProfileAsync(id, dto);
            return result.success ? Ok(result) :NotFound(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecruiter(Guid id)
        {
            var result = await _rS.DeleteRecruiterAsync(id);
            return result.success ? Ok(result) : NotFound(result);
        }


    }
}
