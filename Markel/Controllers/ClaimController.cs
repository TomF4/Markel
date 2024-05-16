
using Markel.Models;
using Markel.Services;
using Microsoft.AspNetCore.Mvc;

namespace Markel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimController(ClaimService ClaimService)
    {
        private readonly ClaimService _claimService = ClaimService ?? throw new NullReferenceException($"Claim Service is null: {typeof(ClaimService)}");

        public ActionResult GetClaim()
        {
            throw new NotImplementedException();
        }
    }
}