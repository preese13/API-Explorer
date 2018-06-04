using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

    public class OutgoingEmployee
    {
        [JsonProperty]
        public string Address1 { get; set; }
        [JsonProperty]
        public string Address2 { get; set; }
        public string AdjSeniorityDate { get; set; }
        [JsonProperty]
        public string BirthDate { get; set; }
        [JsonProperty]
        public string City { get; set; }
        [JsonProperty]
        public string CompanyNumber { get; set; }
        [JsonProperty]
        public string Country { get; set; }
        [JsonProperty]
        public string County { get; set; }
        public bool? Disability { get; set; }
        public bool? EligibleForRehire { get; set; }
        [Key]
        [JsonProperty]
        public string EmployeeId { get; set; }
        [JsonProperty]
        public string EmployeeStatus { get; set; }
        public string EmpStatusChangeReason { get; set; }
        public string EmpStatusEffectiveDate { get; set; }
        public string Ethnicity { get; set; }
        [JsonProperty]
        public string FirstName { get; set; }
        [JsonProperty]
        public string HomePhone { get; set; }
        [JsonProperty]
        public string LastName { get; set; }
        [JsonProperty]
        public string MaritalStatus { get; set; }
        [JsonProperty]
        public string MiddleName { get; set; }
        public string Nickname { get; set; }
        public string Pager { get; set; }
        [JsonProperty]
        public string PersonalEmailAddress { get; set; }
        public string PersonalMobilePhone { get; set; }
        public string PriorLastName { get; set; }
        public string Salutation { get; set; }
        [JsonProperty]
        public string Sex { get; set; }
        public bool? Smoker { get; set; }
        private string _ssn;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public virtual string ssn
        {
            get { return null; }
            set { _ssn = value; }
        }
        [JsonProperty]
        public string State { get; set; }
        [JsonProperty]
        public string Suffix { get; set; }
        public string TaxForm { get; set; }
        public bool? Veteran { get; set; }
        public string WorkAddress1 { get; set; }
        public string WorkAddress2 { get; set; }
        public string WorkCity { get; set; }
        public string WorkCountry { get; set; }
        public string WorkCounty { get; set; }
        public string WorkEmailAddress { get; set; }
        public string WorkPhone { get; set; }
        public string WorkPhoneExt { get; set; }
        public string WorkState { get; set; }
        public string WorkZip { get; set; }
        [JsonProperty]
        public string Zip { get; set; }
        [JsonProperty]
        public List<OutgoingBenefitSetup> benefitSetup { get; set; }
        [JsonProperty]
        public List<OutgoingDepartmentPosition> departmentPosition { get; set; }
        [JsonProperty]
        public List<OutgoingPrimaryPayRate> primaryPayRate { get; set; }
}

public class Partner1UpdateData
{
    public OutgoingEmployee UpdateEmployee { get; set; }
}
    