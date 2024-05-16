
using Markel.Models;
using Markel.Models.Domain;
using Markel.Services;
using Microsoft.AspNetCore.Mvc;

namespace Markel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimController(ClaimService ClaimService) : ControllerBase
    {
        private readonly ClaimService _claimService = ClaimService ?? throw new NullReferenceException($"Claim Service is null: {typeof(ClaimService)}");


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

        [HttpPut("{ucr}")]
        public async Task<IActionResult> UpdateClaim(string ucr, [FromBody] Claim updatedClaim)
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