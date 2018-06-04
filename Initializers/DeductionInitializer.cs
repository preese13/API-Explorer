using mockAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mockAPI
{
    public class DeductionInitializer
    {
        private DeductionContext _context;

        public DeductionInitializer(DeductionContext context)
        {
            _context = context;
        }

        public async Task Seed()
        {

            if (!_context.Deductions.Any())
            {
                _context.AddRange(Deductions);
                await _context.SaveChangesAsync();
            }
        }

        List<Deduction> Deductions = new List<Deduction>
        {
            new Deduction()
            {
                CompanyId = "companyid1",
                EmployeeId = 1,
                PayrollId = "payrollid1",
                Benefit = "benefit1",
                DeductionCode = "9",
                IsPostTax = true,
                DeductionFrequency = 12,
                TypeOfDeduction = "deductiontype1",
                EmployeePerPayAmount = 100,
                EmployerPerPayAmount = 200,
                EmployeeMonthlyAmount = 300,
                EmployerMonthlyAmount = 400,
                DeductionPercentage = 24,
                EnrollmentStartDate = DateTime.UtcNow,
                EnrollmentEndDate = DateTime.UtcNow,
                DeductionStartDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow,
                PlanYearBegin = DateTime.UtcNow,
                PlanYearEnd = DateTime.UtcNow,
            },
                    new Deduction()
            {
                CompanyId = "companyid12",
                EmployeeId = 2,
                PayrollId = "payrollid2",
                Benefit = "benefit2",
                DeductionCode = "8",
                IsPostTax = true,
                DeductionFrequency = 12,
                TypeOfDeduction = "deductiontype2",
                EmployeePerPayAmount = 100,
                EmployerPerPayAmount = 200,
                EmployeeMonthlyAmount = 300,
                EmployerMonthlyAmount = 400,
                DeductionPercentage = 24,
                EnrollmentStartDate = DateTime.UtcNow,
                EnrollmentEndDate = DateTime.UtcNow,
                DeductionStartDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow,
                PlanYearBegin = DateTime.UtcNow,
                PlanYearEnd = DateTime.UtcNow,
            },
                    new Deduction()
            {
                CompanyId = "companyid3",
                EmployeeId = 3,
                PayrollId = "payrollid3",
                Benefit = "benefit3",
                DeductionCode = "7",
                IsPostTax = true,
                DeductionFrequency = 12,
                TypeOfDeduction = "deductiontype3",
                EmployeePerPayAmount = 100,
                EmployerPerPayAmount = 200,
                EmployeeMonthlyAmount = 300,
                EmployerMonthlyAmount = 400,
                DeductionPercentage = 24,
                EnrollmentStartDate = DateTime.UtcNow,
                EnrollmentEndDate = DateTime.UtcNow,
                DeductionStartDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow,
                PlanYearBegin = DateTime.UtcNow,
                PlanYearEnd = DateTime.UtcNow,
            },
            new Deduction()
            {
                CompanyId = "companyid4",
                EmployeeId = 4,
                PayrollId = "payrollid4",
                Benefit = "benefit4",
                DeductionCode = "6",
                IsPostTax = true,
                DeductionFrequency = 12,
                TypeOfDeduction = "deductiontype4",
                EmployeePerPayAmount = 100,
                EmployerPerPayAmount = 200,
                EmployeeMonthlyAmount = 300,
                EmployerMonthlyAmount = 400,
                DeductionPercentage = 24,
                EnrollmentStartDate = DateTime.UtcNow,
                EnrollmentEndDate = DateTime.UtcNow,
                DeductionStartDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow,
                PlanYearBegin = DateTime.UtcNow,
                PlanYearEnd = DateTime.UtcNow,
            },
        };
    }
}