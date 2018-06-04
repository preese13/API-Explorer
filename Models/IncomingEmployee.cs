
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

    public class IncomingEmployee
    {
        [JsonProperty]
        public string Address1 { get; set; }
        [JsonProperty]
        public string Address2 { get; set; }
        [JsonProperty]
        public string BirthDate { get; set; }
        [JsonProperty]
        public string City { get; set; }
        [JsonProperty]
        public string CompanyNumber { get; set; } 
        [Key]
        [JsonProperty]
        public string EmployeeId { get; set; }
        public string Ethnicity { get; set; }
        [JsonProperty]
        public string FirstName { get; set; }
        [JsonProperty]
        public string Gender { get; set; }
        public bool HighlyCompensatedEmployee { get; set; }
        [JsonProperty]
        public string HireDate { get; set; }
        [JsonProperty]
        public string HomePhone { get; set; }
        [JsonProperty]
        public string LastName { get; set; }
        [JsonProperty]
        public string MaritalStatus { get; set; }
        [JsonProperty]
        public string MiddleName { get; set; }
        public decimal OwnerPercent { get; set; }
        [JsonProperty]
        public string PersonalEmailAddress { get; set; }
        public string PersonalMobilePhone { get; set; }
        [JsonProperty]
        public string PostalCode { get; set; }
        [JsonProperty]
        public string ReHireDate { get; set; }
        [JsonProperty]
        public string SSN { get; set; }
        [JsonProperty]
        public string State { get; set; }
        public bool Statutory { get; set; }
        [JsonProperty]
        public string TaxForm { get; set; }
        [JsonProperty]
        public string TerminationDate { get; set; }
        [JsonProperty]
        public string TerminationReason { get; set; }
        public string WorkEmailAddress { get; set; }
        public string WorkPhone { get; set; }
        public string WorkPhoneExt { get; set; }
        [JsonProperty]
        public IncomingDepartmentPosition DepartmentPosition { get; set; }
        [JsonProperty]
        public IncomingEmployeeStatus EmployeeStatus { get; set; }
        [JsonProperty]
        public IncomingPrimaryPayRate PrimaryPayRate { get; set; }
        [JsonProperty]
        public IncomingBenefitSetup BenefitSetup { get; set; }
    }