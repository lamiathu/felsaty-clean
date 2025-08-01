using System;

namespace Sarfati.Core.Dto
{
    public class ProductDto
    {
        public long ProductId { get; set; }
        
        public long CategoryId { get; set; }
        
        public string ProductNameAr { get; set; }
        
        public string ProductNameEn { get; set; }
        
        public decimal ProductPrice { get; set; }
        
        public decimal SellPrice { get; set; }
        
        public bool Available { get; set; }
        
        public DateTime LastUpdated { get; set; }
        
        public string ImageUrl { get; set; }
        
        public MetaDataDto MetaData { get; set; }
    }
    public class MetaDataDto
    { 
        public string DescriptionAr { get; set; }
        
        public string DescriptionEn { get; set; }
        
        public string RedeemStepsAr { get; set; }
        
        public string RedeemStepsEn { get; set; }
        
        public string TermsAndConditionsAr { get; set; }
        
        public string TermsAndConditionsEn { get; set; }
    }
}