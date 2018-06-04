
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

 [JsonObject(MemberSerialization.OptIn)]
    public class OutgoingBenefitSetup
    {
        [Key]
        public string BenefitClass { get; set; }
        // pmc - this will be sent as null/~ until PCTY can handle properly
        [JsonProperty]
        public string BenefitClassSetupEffectiveDate { get; set; }
        // pmc - removed from json output until PCTY can handle properly
        [JsonProperty]
        public decimal? BenefitSalary { get; set; }
        // pmc - removed from json output until PCTY can handle properly
        [JsonProperty]
        public string BenefitSalaryEffectiveDate { get; set; }
    }