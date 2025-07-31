using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Portfolio.APP.DTOs.AppUser;
using Portfolio.APP.ServiceInterface;

namespace Portfolio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceController : ControllerBase
    {
        private readonly IWorkExperienceService _wEP;
        public ExperienceController(IWorkExperienceService wEP)
        {
            _wEP = wEP;
        }
        [HttpPost]

        public async Task<IActionResult> CreateExperience([FromBody] CreateWorkExperienceDto dto)
        {
            var result = await _wEP.AddWorkExperienceAsync(dto);
            return result.success ? Ok(result) : BadRequest(result);
        }

        [HttpPut("{id}")]

        public async Task <IActionResult>UpdateWork(Guid id, [FromBody] UpdateWorkExperienceDto dto)
        {
            var result = await _wEP.UpdateWorkExperienceAsync(id, dto);
            return result.success ? Ok(result) : NotFound();
        }

        [HttpDelete("byId{id}")]

        public async Task<IActionResult>DeleteWorkExperience(Guid id)
        {
            var result = await _wEP.DeleteWorkExperienceAsync(id);
            return result.success ? Ok(result) : NotFound();
        }
    }
}
