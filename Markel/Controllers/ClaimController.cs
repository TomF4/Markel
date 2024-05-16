
using Markel.Models.Requests;
using Markel.Services;
using Microsoft.AspNetCore.Mvc;

namespace Markel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimController(IClaimService ClaimService) : ControllerBase
    {
        private readonly IClaimService _claimService = ClaimService ?? throw new NullReferenceException($"Claim Service is null: {typeof(IClaimService)}");

        /// <summary>
        /// Get a claims details
        /// </summary>
        /// <param name="ucr"></param>
        [HttpGet("{ucr}")]
        public async Task<IActionResult> GetClaim(string ucr)
        {
            var claim = await _claimService.GetClaimAsync(ucr);
            if (claim == null)
            {
                return NotFound();
            }

            return Ok(claim);
        }

        /// <summary>
        /// Update a claim from body
        /// </summary>
        /// <param name="ucr"></param>
        /// <param name="updatedClaim"></param>
        [HttpPut("{ucr}")]
        public async Task<IActionResult> UpdateClaim(string ucr, [FromBody] UpdateClaimsRequest updatedClaim)
        {
            try
            {
                await _claimService.UpdateClaimAsync(ucr, updatedClaim);
                return Ok(new { message = "Claim updated successfully" });
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }
    }
}