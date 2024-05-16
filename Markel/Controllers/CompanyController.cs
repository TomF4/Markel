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
            var company = await _companyService.GetCompanyAsync(id);
            if (company == null)
            {
                return NotFound();
            }

            return Ok(company);
        }

        // claims for company
        [HttpGet("{id}/claims")]
        public ActionResult GetCompanyClaims(int id)
        {

            throw new NotImplementedException();
        }


        // claim details

    }
}