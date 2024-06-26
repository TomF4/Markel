namespace Markel.Models.Domain
{
    public class Company
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Address1 { get; set; }
        public string Address2 { get; set; } = string.Empty;
        public string Address3 {get;set; } = string.Empty;
        public required string Postcode { get; set; }
        public required string Country { get; set; }
        public bool Active { get; set; }
        public DateTime InsuranceEndDate { get; set; }
        public ICollection<Claim>? Claims { get; set;}
    }
}