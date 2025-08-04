using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio.APP.DTOs.ProfileDtos;
using Portfolio.APP.ServiceInterface;

namespace Portfolio.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProfileDto dto)
        {
            var result = await _profileService.CreateProfileAsync(dto);
            return result.success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _profileService.DeleteProfileAsync(id);
            return result.success ? Ok(result) : NotFound(result);
        }

        [HttpGet("allProfiles")]
        public async Task<IActionResult> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _profileService.GetAllProfilesAsync(pageNumber, pageSize);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ProfileUpdateDto dto)
        {
            var result = await _profileService.UpdateProfileAsync(id, dto);
            return result.success ? Ok(result) : NotFound(result);
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfile(Guid id)
        {
            var result = await _profileService.GetProfileById(id);
            return result.success ? Ok(result) : NotFound(result);
        }

        [HttpGet("Complete_Profile_By/{profileId}")]
        public async Task<IActionResult> GetFullProfileById(Guid profileId)
        {
            var response = await _profileService.GetFullProfileByIdAsync(profileId);

            if (!response.success)
                return NotFound(response);

            return Ok(response);
        }

        [HttpGet("by/{userId}")]
        public async Task<IActionResult> GetProfileByUserId(Guid userId)
        {
            var response = await _profileService.GetProfileByUserId(userId);

            if (!response.success)
                return NotFound(response);

            return Ok(response);
        }
    }
}
