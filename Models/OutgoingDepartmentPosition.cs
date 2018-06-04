

using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

[JsonObject(MemberSerialization.OptIn)]
    public class OutgoingDepartmentPosition
    {
        [Key]
        public string ChangeReason { get; set; }    // not on Incoming
        public string ClockBadgeNumber { get; set; }    // not on Incoming
        [JsonProperty]
        public string CostCenter1 { get; set; }
        public string CostCenter2 { get; set; }
        [JsonProperty]
        public string CostCenter3 { get; set; }
        public string EffectiveDate { get; set; }    // not on Incoming
        public string EmployeeType { get; set; }
        public string EqualEmploymentOpportunityClass { get; set; }
        public bool? IsSupervisorReviewer { get; set; } // not on Incoming
        [JsonProperty]
        public string JobTitle { get; set; }
        public bool? MinimumWageExempt { get; set; }    // not on Incoming
        public bool? OvertimeExempt { get; set; }   // not on Incoming
        [JsonProperty]
        public string PayGroup { get; set; }
        public string PositionCode { get; set; }    // not on Incoming
        public string Shift { get; set; }   // not on Incoming
        public string SupervisorCompanyNumber { get; set; } // not on Incoming
        public string SupervisorEmployeeId { get; set; }    // not on Incoming
        public bool? Tipped { get; set; }   // not on Incoming
        public string UnionAffiliationDate { get; set; } // not on Incoming
        public string UnionCode { get; set; }   // not on Incoming
        public bool? UnionDuesCollected { get; set; }   // not on Incoming
        public bool? UnionInitiationsCollected { get; set; }    // not on Incoming
        public string UnionPosition { get; set; }   // not on Incoming
        public string WorkersComp { get; set; } // not on Incoming
    }