using Markel.Models;
using Microsoft.EntityFrameworkCore;

namespace Markel.Services
{
    public class CompanyService(MarkelDbContext context)
    {
        private readonly MarkelDbContext _dbContext = context;

        public async Task<GetCompanyResponse?> GetCompanyAsync(int companyId)
        {
            var company = await _dbContext.Companies
                .Include(c => c.Claims)
                .FirstOrDefaultAsync(c => c.Id == companyId);

            if (company == null)
            {
                return null;
            }

            var hasActiveInsurance = company.Active && company.InsuranceEndDate >= DateTime.Now;

            return new GetCompanyResponse
            {
                Id = company.Id,
                Name = company.Name,
                Address1 = company.Address1,
                Address2 = company.Address2,
                Address3 = company.Address3,
                Postcode = company.Postcode,
                Country = company.Country,
                Active = company.Active,
                InsuranceEndDate = company.InsuranceEndDate,
                HasActiveInsurance = hasActiveInsurance
            };
        }

        public async Task<IEnumerable<GetCompanyClaims>> GetCompanyClaimsAsync(int companyId)
        {
            var claims = await _dbContext.Claims
                .Where(c => c.CompanyId == companyId)
                .ToListAsync();

            return claims.Select(x => new GetCompanyClaims()
            {
                UCR = x.UCR,
                AssuredName = x.AssuredName,
                ClaimDate = x.ClaimDate,
                Closed = x.Closed,
                IncurredLoss = x.IncurredLoss,
                LossDate = x.LossDate,
            });
        }
    }
}