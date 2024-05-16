using Markel.Models.Domain;
using Markel.Services;
using Microsoft.EntityFrameworkCore;

namespace MarkelTests;

public class CompanyServiceTests
{
    /// <summary>
    /// Test to add and return a company using company service.
    /// </summary>
    [Fact]
    public async Task GetCompanyAsync_ReturnsCompany()
    {
        var options = new DbContextOptionsBuilder<MarkelDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        using (var context = new MarkelDbContext(options))
        {
            await context.Companies.AddAsync(new Company
            {
                Id = 1,
                Name = "Test Company",
                Address1 = "123 Test St",
                Address2 = "Unit 101",
                Postcode = "12345",
                Country = "Testland",
                Active = true,
                InsuranceEndDate = DateTime.UtcNow.AddYears(1)
            });
            await context.SaveChangesAsync();
        }

        using (var context = new MarkelDbContext(options))
        {
            var companyService = new CompanyService(context);

            var company = await companyService.GetCompanyAsync(1);

            Assert.NotNull(company);
            Assert.Equal("Test Company", company.Name);
        }
    }
}