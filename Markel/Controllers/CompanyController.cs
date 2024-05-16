using Markel.Models;
using Markel.Services;
using Microsoft.AspNetCore.Mvc;

namespace Markel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController(CompanyService companyService) : ControllerBase
    {
        private readonly CompanyService _companyService = companyService ?? throw new NullReferenceException($"Company Service is null: {typeof(CompanyService)}");

        // single company
        [HttpGet("{id}")]
        public async Task<ActionResult<GetCompanyResponse>> GetCompany(int id)
        {
            try
            {
                var company = await _companyService.GetCompanyAsync(id);

                if (company == null)
                {
                    return NotFound("Company not found");
                }

                return Ok(company);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // claims for company
        [HttpGet("{id}/claims")]
        public async Task<ActionResult> GetCompanyClaims(int id)
        {
            var claims = await _companyService.GetCompanyClaimsAsync(id);
            return Ok(claims);
        }

        // claim details

    }
}