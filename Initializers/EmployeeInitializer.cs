using mockAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mockAPI
{
    public class EmployeeInitializer
    {
        private EmployeeContext _context;

        public EmployeeInitializer(EmployeeContext context)
        {
            _context = context;
        }

        public async Task Seed()
        {

            if (!_context.Employees.Any())
            {
                _context.AddRange(employees);
                await _context.SaveChangesAsync();
            }
        }



        List<Employee> employees = new List<Employee>
        {
            new Employee()
            {
                CompanyId = "companyid1",
                EmployeeId = 1,
                PayrollId = "payrollid1",
                TimeClockId = "timeclockid1",
                SSN = "ssn1",
                FirstName = "Randy",
                MiddleName = "R",
                LastName = "Randleman",
                Email = "randyrandalman@hotmail.com",
                Suffix = "C.S.V.",
                DOB = DateTime.UtcNow,
                Gender = "m",
                MaritalStatus = "divorced",
                PayrollGroup = "payrollgroup1",
                PayFrequency = "bi-monthly",
                BusinessUnit = "businessunit1",
                Office = "",
                Department = "",
                Division = "",
                Union = false,
                JobTitle = "Sous Chef",
                FullTime = true,
                StatutoryClass = "",
                Seasonal = false,
                AcaClassification = "2",
                UsCitizen = true,
                OriginalHireDate = DateTime.UtcNow,
                EmploymentStatus = "employed",
                WorkerTaxStatus = "pass",
                TerminationDate = null,
                TerminationReason = "pick one",
                PayEffectiveDate = DateTime.UtcNow,
                CompensationBasis = "gauranteed pay",
                AnnualBaseSalary = 250000,
                BaseHourlyRate = null,
                HoursPerWeek = 8,
                AnnualBenefitSalary = null,
                AnnualBenefitSalaryEffectiveDate = DateTime.UtcNow,
                Address1 = "123 Parkway lane",
                Address2 = "",
                Address3 = "",
                City = "California City",
                County = "John county",
                State = "AK",
                ZIP = "22304",
                Country = "US&A",
                Phone = "1-800-CLEANERS"
            },
                    new Employee()
            {
                CompanyId = "companyid2",
                EmployeeId = 2,
                PayrollId = "payrollid2",
                TimeClockId = "",
                SSN = "000000000",
                FirstName = "Chet",
                MiddleName = "",
                LastName = "Manly",
                Email = "chetmanly@manlysmanlymen.com",
                Suffix = null,
                DOB = new DateTime(1970, 1, 1),
                Gender = "M",
                MaritalStatus = "divorced",
                PayrollGroup = "Bi-Weekly",
                PayFrequency = null,
                BusinessUnit = "businessunit2",
                Office = "space",
                Department = "",
                Division = "",
                Union = false,
                JobTitle = "All the above",
                FullTime = true,
                StatutoryClass = null,
                Seasonal = false,
                AcaClassification = "2",
                UsCitizen = true,
                HireDate = new DateTime(2016, 1, 1),
                OriginalHireDate = null,
                EmploymentStatus = "active",
                WorkerTaxStatus = "",
                TerminationDate = null,
                TerminationReason = null,
                PayEffectiveDate = new DateTime(2018, 1, 1),
                CompensationBasis = "Salary",
                AnnualBaseSalary = 50000,
                BaseHourlyRate = null,
                HoursPerWeek = 40,
                AnnualBenefitSalary = null,
                AnnualBenefitSalaryEffectiveDate = null,
                Address1 = "34623 Street Rd",
                Address2 = "",
                Address3 = "",
                City = "Buford",
                County = "Albany",
                State = "Wyoming",
                ZIP = "82052",
                Country = "U.S.",
                Phone = "555-555-5555"
            },
                    new Employee()
            {
               CompanyId = "companyid2",
                EmployeeId = 8,
                PayrollId = "payrollid4",
                TimeClockId = "",
                SSN = "000000000",
                FirstName = "Ron",
                MiddleName = "",
                LastName = "Johnson",
                Email = "RonJohnson@manlysmanlymen.com",
                Suffix = null,
                DOB = new DateTime(1970, 1, 1),
                Gender = "M",
                MaritalStatus = "Married",
                PayrollGroup = "Bi-Weekly",
                PayFrequency = null,
                BusinessUnit = "businessunit2",
                Office = "space",
                Department = "",
                Division = "",
                Union = false,
                JobTitle = "Important job title",
                FullTime = true,
                StatutoryClass = null,
                Seasonal = false,
                AcaClassification = "2",
                UsCitizen = true,
                HireDate = new DateTime(2016, 1, 1),
                OriginalHireDate = null,
                EmploymentStatus = "active",
                WorkerTaxStatus = "",
                TerminationDate = null,
                TerminationReason = null,
                PayEffectiveDate = new DateTime(2018, 1, 1),
                CompensationBasis = "Salary",
                AnnualBaseSalary = 50000,
                BaseHourlyRate = null,
                HoursPerWeek = 40,
                AnnualBenefitSalary = null,
                AnnualBenefitSalaryEffectiveDate = null,
                Address1 = "195 Boulevard way",
                Address2 = "",
                Address3 = "",
                City = "Buford",
                County = "Albany",
                State = "Wyoming",
                ZIP = "82052",
                Country = "U.S.",
                Phone = "555-555-5554"
            },
            new Employee()
            {
                CompanyId = "companyid5",
                EmployeeId = 5,
                PayrollId = "payrollid5",
                TimeClockId = "",
                SSN = "000000000",
                FirstName = "Topper",
                MiddleName = "",
                LastName = "Bottoms",
                Email = "topper_bottoms_124573@hotmail.com",
                Suffix = null,
                DOB = new DateTime(1970, 1, 1),
                Gender = "M",
                MaritalStatus = "divorced",
                PayrollGroup = "Bi-Weekly",
                PayFrequency = null,
                BusinessUnit = "businessunit2",
                Office = "",
                Department = "",
                Division = "",
                Union = false,
                JobTitle = "All the above",
                FullTime = true,
                StatutoryClass = null,
                Seasonal = false,
                AcaClassification = "2",
                UsCitizen = true,
                HireDate = new DateTime(2016, 1, 1),
                OriginalHireDate = null,
                EmploymentStatus = "active",
                WorkerTaxStatus = "",
                TerminationDate = null,
                TerminationReason = null,
                PayEffectiveDate = new DateTime(2018, 1, 1),
                CompensationBasis = "Salary",
                AnnualBaseSalary = 50000,
                BaseHourlyRate = null,
                HoursPerWeek = 40,
                AnnualBenefitSalary = null,
                AnnualBenefitSalaryEffectiveDate = null,
                Address1 = "34623 Lane way",
                Address2 = "",
                Address3 = "",
                City = "Buford",
                County = "Albany",
                State = "Wyoming",
                ZIP = "82052",
                Country = "U.S.",
                Phone = "555-555-5556"
            },
        };
    }
}