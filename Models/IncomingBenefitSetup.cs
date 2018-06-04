using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

[JsonObject(MemberSerialization.OptIn)]
    public class IncomingBenefitSetup
    {
        [Key]
        public string BenefitClass { get; set; }
        public string BenefitClassEffectiveDate { get; set; }
        [JsonProperty]
        public decimal? BenefitSalary { get; set; }
        [JsonProperty]
        public string BenefitSalaryEffectiveDate { get; set; }
    }