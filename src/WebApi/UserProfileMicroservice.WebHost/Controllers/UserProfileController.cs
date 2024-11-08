using Microsoft.AspNetCore.Mvc;
using UserProfileMicroservice.BusinessLogic.Services.Abstractions;
using UserProfileMicroservice.WebHost.Mapping;
using UserProfileMicroservice.WebHost.Requests;
using UserProfileMicroservice.WebHost.Responses;

namespace UserProfileMicroservice.WebHost.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class UserProfileController(IUserProfileService userProfileService)
    : ControllerBase
{
    [HttpGet("{id:Guid}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OwnerProfileResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Guid))]
    public async Task<IActionResult> GetProfileById(Guid id)
    {
        var profile = await userProfileService.GetByIdAsync(id);
        if (profile is null)
            return NotFound(id);
        return Ok(profile.ToResponse());
    }

    [HttpGet("{username}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PublicProfileResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    public async Task<IActionResult> GetProfileByUsername(string username)
    {
        var profile = await userProfileService.GetByUsernameAsync(username);
        if (profile is null)
            return NotFound(username);
        return Ok(profile.ToPublicResponse());
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(OwnerProfileResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    public async Task<IActionResult> CreateProfile(CreateProfileRequest request)
    {
        var createdProfile = await userProfileService.CreateAsync(request.ToModel());
        if (createdProfile is null)
            return BadRequest("Profile can not be created");
        return CreatedAtAction(nameof(GetProfileById), new { id = createdProfile.Id }, createdProfile.ToResponse());
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OwnerProfileResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    public async Task<ActionResult<OwnerProfileResponse>> UpdateAsync(Guid id, UpdateProfileRequest updateProfile)
    {
        if (id != updateProfile.Id)
            return BadRequest("the id of the request and the id of the profile being updated do not match");
        var updatedProfile = await userProfileService.UpdateAsync(updateProfile.ToModel());
        if (updatedProfile is null)
            return BadRequest("Profile can not be updated");

        return Ok(updatedProfile.ToResponse());
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    public async Task<ActionResult<bool>> DeleteAsync(Guid id)
        => await userProfileService.DeleteAsync(id) is true ? NoContent() : BadRequest("Profile can not be deleted");
}
