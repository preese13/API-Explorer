using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

[JsonObject(MemberSerialization.OptIn)]
    public class Partner1IncomingDepartmentPosition
    {
        [JsonProperty]
        public string CostCenter1 { get; set; }
        public string CostCenter2 { get; set; }
        [JsonProperty]
        public string CostCenter3 { get; set; }
        [Key]
        [JsonProperty]
        public string EmployeeType { get; set; }
        public string EqualEmploymentOpportunityClass { get; set; }
        [JsonProperty]
        public string JobTitle { get; set; }
        [JsonProperty]
        public string PayGroup { get; set; }
    }