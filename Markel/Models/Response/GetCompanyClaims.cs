namespace Markel.Models
{
    public class GetCompanyClaims
    {
        public required string UCR {get;set;}
        public DateTime ClaimDate {get;set;}    
        public DateTime LossDate {get;set;}
        public required string AssuredName {get;set;}
        public decimal IncurredLoss {get;set;}
        public bool Closed {get;set;}
    }
}