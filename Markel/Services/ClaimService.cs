using Markel.Models.Domain;
using Markel.Models.Response;
using Microsoft.EntityFrameworkCore;

namespace Markel.Services
{
    public class ClaimService(MarkelDbContext context) : IClaimService
    {
        private readonly MarkelDbContext _dbContext = context;

        public async Task<GetClaimDetails?> GetClaimAsync(string ucr)
        {
            var claim = await _dbContext.Claims.FirstOrDefaultAsync(c => c.UCR == ucr);

            if (claim == null)
            {
                return null;
            }

            var claimAgeInDays = (DateTime.Now - claim.ClaimDate).Days;

            return new GetClaimDetails
            {
                UCR = claim.UCR,
                CompanyId = claim.CompanyId,
                ClaimDate = claim.ClaimDate,
                LossDate = claim.LossDate,
                AssuredName = claim.AssuredName,
                IncurredLoss = claim.IncurredLoss,
                Closed = claim.Closed,
                ClaimAgeInDays = claimAgeInDays
            };
        }

        public async Task UpdateClaimAsync(string ucr, Claim updatedClaim)
        {
            var claim = await _dbContext.Claims.FirstOrDefaultAsync(c => c.UCR == ucr) ?? throw new ArgumentException("Claim not found");

            claim.ClaimDate = updatedClaim.ClaimDate;
            claim.LossDate = updatedClaim.LossDate;
            claim.AssuredName = updatedClaim.AssuredName;
            claim.IncurredLoss = updatedClaim.IncurredLoss;
            claim.Closed = updatedClaim.Closed;

            await _dbContext.SaveChangesAsync();
        }
    }
}