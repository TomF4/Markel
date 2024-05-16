
using Markel.Models;
using Markel.Services;
using Microsoft.AspNetCore.Mvc;

namespace Markel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController(CompanyService companyService)
    {
        private readonly CompanyService _companyService = companyService ?? throw new NullReferenceException($"Company Service is null: {typeof(CompanyService)}");

        // single company
        [HttpGet("{id}")]
        public ActionResult<GetCompanyResponse> GetCompany(int id)
        {
            

            throw new NotImplementedException();
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