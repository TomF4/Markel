using Markel.Models.Domain;
using Markel.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MarkelDbContext>(options => options.UseInMemoryDatabase("TestDatabase"));
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IClaimService, ClaimService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

InitDb(app);

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => 
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Markel API v1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

static void Data(MarkelDbContext dbContext)
{
    dbContext.Companies.AddRange(
        new Company
        {
            Id = 1,
            Name = "Test Company 1",
            Address1 = "123 Test St",
            Address2 = "Test1",
            Address3 = "",
            Postcode = "12345",
            Country = "TestPlace",
            Active = true,
            InsuranceEndDate = DateTime.UtcNow.AddYears(1)
        },
        new Company
        {
            Id = 2,
            Name = "Test Company 2",
            Address1 = "321 Test St",
            Address2 = "Test2",
            Address3 = "",
            Postcode = "54321",
            Country = "TestPlace",
            Active = true,
            InsuranceEndDate = DateTime.UtcNow.AddYears(-1)
        }
    );

    dbContext.Claims.AddRange(
        new Claim
        {
            UCR = "UCR1",
            CompanyId = 1,
            ClaimDate = DateTime.UtcNow.AddDays(-30),
            LossDate = DateTime.UtcNow.AddDays(-40),
            AssuredName = "NAME1",
            IncurredLoss = 1000,
            Closed = false
        },
        new Claim
        {
            UCR = "UCR2",
            CompanyId = 2,
            ClaimDate = DateTime.UtcNow.AddDays(-20),
            LossDate = DateTime.UtcNow.AddDays(-25),
            AssuredName = "NAME2",
            IncurredLoss = 2000,
            Closed = false
        }
    );

    dbContext.SaveChanges();
}

static void InitDb(IHost host)
{
    using var scope = host.Services.CreateScope();

    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<MarkelDbContext>();

    Data(dbContext);
}