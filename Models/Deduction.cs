using System;
using System.ComponentModel.DataAnnotations;

namespace mockAPI.Models
{
public class Deduction
    {
        public string CompanyId { get; set; }
        public int EmployeeId { get; set; }
        public string PayrollId { get; set; }
        public string Benefit { get; set; }
        [Key]
        public string DeductionCode { get; set; }
        public bool IsPostTax { get; set; }
        public int? DeductionFrequency { get; set; }
        public string TypeOfDeduction { get; set; }
        public decimal? EmployeePerPayAmount { get; set; }
        public decimal? EmployerPerPayAmount { get; set; }
        public decimal? EmployeeMonthlyAmount { get; set; }
        public decimal? EmployerMonthlyAmount { get; set; }
        public decimal? DeductionPercentage { get; set; }
        public DateTime? EnrollmentStartDate { get; set; }
        public DateTime? DeductionStartDate { get; set; }
        public DateTime? EnrollmentEndDate { get; set; }
        public DateTime? PlanYearBegin { get; set; }
        public DateTime? PlanYearEnd { get; set; }
        public DateTime? ModifiedDate { get; set; }
 
        public bool IsCancellation()
        {
            var startDate = EnrollmentStartDate ?? DateTime.Today;
            return (EnrollmentEndDate.HasValue
                    && EnrollmentEndDate < startDate);
        }
    }
}