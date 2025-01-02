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
    public async Task<ActionResult<OwnerProfileResponse>> GetProfileByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var profile = await userProfileService.GetByIdAsync(id, cancellationToken);
        return profile is null ? NotFound(id) : Ok(profile.ToResponse());
    }

    [HttpGet("{username}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PublicProfileResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    public async Task<ActionResult<PublicProfileResponse>> GetProfileByUsernameAsync(string username, CancellationToken cancellationToken)
    {
        var profile = await userProfileService.GetByUsernameAsync(username, cancellationToken);
        return profile is null ? NotFound(username) : Ok(profile.ToPublicResponse());
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OwnerProfileResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    public async Task<ActionResult<OwnerProfileResponse>> UpdateAsync(Guid id, UpdateProfileRequest updateProfile, CancellationToken cancellationToken)
    {
        if (id != updateProfile.Id)
            return BadRequest("the id of the request and the id of the profile being updated do not match");
        var updatedProfile = await userProfileService.UpdateAsync(updateProfile.ToModel(), cancellationToken);
        return updatedProfile is null ? BadRequest("Profile can not be updated") : Ok(updatedProfile.ToResponse());
    }
}
