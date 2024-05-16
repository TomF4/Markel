using Markel.Models.Domain;
using Markel.Models.Response;

namespace Markel.Services
{
    public interface IClaimService
    {
        Task<GetClaimDetails?> GetClaimAsync(string ucr);
        Task UpdateClaimAsync(string ucr, Claim updatedClaim);
    }
}