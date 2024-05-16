using Markel.Models;
using Markel.Models.Response;

namespace Markel.Services
{
    public interface ICompanyService
    {
        Task<GetCompanyResponse?> GetCompanyAsync(int companyId);
        Task<IEnumerable<GetCompanyClaims>> GetCompanyClaimsAsync(int companyId);
    }
}