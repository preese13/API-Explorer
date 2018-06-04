using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

[JsonObject(MemberSerialization.OptIn)]
    public class OutgoingPrimaryPayRate
    {
        public string Atopay { get; set; } // not on Incoming
        [Key]
        [JsonProperty]
        public decimal? BaseRate { get; set; }
        [JsonProperty]
        public decimal? DefaultHours { get; set; }
        public string EffectiveDate { get; set; }    // not on Incoming
        public string PayFrequency { get; set; }
        public string PayGrade { get; set; }    // not on Incoming
        public string PayType { get; set; }
        public decimal? RatePer { get; set; }   // not on Incoming
        public string Reason { get; set; }  // not on Incoming
        [JsonProperty]
        public decimal? Salary { get; set; }
    }