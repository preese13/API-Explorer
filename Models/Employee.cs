using System;
using System.ComponentModel.DataAnnotations;

namespace mockAPI.Models
{
public class Employee
    {
        public string CompanyId { get; set; }
        [Key]
        public int? EmployeeId { get; set; }
        public string PayrollId { get; set; }
        public string TimeClockId { get; set; }
        public string SSN { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public DateTime? DOB { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string PayrollGroup { get; set; }
        public string PayFrequency { get; set; }
        public string BusinessUnit { get; set; }
        public string Office { get; set; }
        public string Department { get; set; }
        public string Division { get; set; }
        public bool? Union { get; set; }
        public string JobTitle { get; set; }
        public bool? FullTime { get; set; }
        public string StatutoryClass { get; set; }
        public bool? Seasonal { get; set; }
        public string AcaClassification { get; set; }
        public bool? UsCitizen { get; set; }
        public DateTime? HireDate { get; set; }
        // removed from api 2016-11-17
        public DateTime? OriginalHireDate { get; set; }
        public string EmploymentStatus { get; set; }
        public string WorkerTaxStatus { get; set; }
        public DateTime? TerminationDate { get; set; }
        public string TerminationReason { get; set; }
        public DateTime? PayEffectiveDate { get; set; }
        public string CompensationBasis { get; set; }
        public decimal? AnnualBaseSalary { get; set; }
        public decimal? BaseHourlyRate { get; set; }
        public decimal? HoursPerWeek { get; set; }
        public decimal? AnnualBenefitSalary { get; set; }
        public DateTime? AnnualBenefitSalaryEffectiveDate { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string State { get; set; }
        public string ZIP { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}