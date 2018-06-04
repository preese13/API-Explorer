using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

[JsonObject(MemberSerialization.OptIn)]
    public class IncomingPrimaryPayRate
    {
        [Key]
        [JsonProperty]
        public decimal? AnnualSalary { get; set; }
        [JsonProperty]
        public decimal? BaseRate { get; set; }
        [JsonProperty]
        public decimal? DefaultHours { get; set; }
        [JsonProperty]
        public string PayFrequency { get; set; }
        [JsonProperty]
        public string PrimaryPayRateEffectiveDate { get; set; }
        [JsonProperty]
        public decimal? Salary { get; set; }
        [JsonProperty]
        public string PayType { get; set; }
    }