using Capital.Placement.Program.Data.DTOs;
using Capital.Placement.Program.Service.BusinessLogic;

using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Capital.Placement.Program.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IPersonalInformationService _personalInformationService;
        private readonly IValidator<AddPersonalInformationRequestDTO> _addInfoRequestValidator;
        private readonly IValidator<UpdatePersonalInformationRequestDTO> _updateInfoRequestValidator; 

        public RegisterController( IPersonalInformationService personalInformationService, IValidator<AddPersonalInformationRequestDTO> requestValidator, IValidator<UpdatePersonalInformationRequestDTO> updateInfoRequestValidator )
        {
            _personalInformationService = personalInformationService;
            _addInfoRequestValidator = requestValidator;
            _updateInfoRequestValidator = updateInfoRequestValidator;
        }

        [Authorize]
        [HttpPost("Add-New-PersonalInformation")]
        public async Task<ActionResult<PersonalInformationDTO>> AddPersonalInformationAsync( [FromBody] AddPersonalInformationRequestDTO request )
        {
            var validationResult = await _addInfoRequestValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                var errorMessages = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
                return BadRequest($"Validation failed: {errorMessages}");
            }
            var detail = await _personalInformationService.AddPersonalInformationAsync(request);
            return Ok(detail);
        }

        [HttpGet("Get-Filtered-PersonalInformations")]
        public async Task<ActionResult<IEnumerable<PersonalInformationDTO>>> GetFilteredPersonalInformationsAsync( int pageNumber = 1, int pageSize = 10 )
        {
            var details = await _personalInformationService.GetPaginatedAsync(pageNumber, pageSize);
            return Ok(details);
        }

        [HttpGet("Get-PersonalInformation/{id:Guid}")]
        public async Task<ActionResult<PersonalInformationDTO>> GetPersonalInformationByIdAsync( Guid id )
        {
            var detail = await _personalInformationService.GetPersonalInformationByIdAsync(id);
            if (detail == null)
            {
                return NotFound();
            }
            return Ok(detail);
        }

        [Authorize]
        [HttpPut("Update-PersonalInformation/{id:Guid}")]
        public async Task<IActionResult> UpdatePersonalInformationAsync( Guid id, UpdatePersonalInformationRequestDTO request )
        {
            var validationResult = await _updateInfoRequestValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                var errorMessages = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
                return BadRequest($"Validation failed: {errorMessages}");
            }
            var updatedDetail = await _personalInformationService.UpdatePersonalInformationAsync(id, request);
            if (updatedDetail == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [Authorize]
        [HttpDelete("Delete-PersonalInformation/{id:Guid}")]
        public async Task<IActionResult> DeletePersonalInformationAsync( Guid id )
        {
            var result = await _personalInformationService.DeletePersonalInformationAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
