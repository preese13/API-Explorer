using mockAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mockAPI
{
    public class IncomingEmployeeInitializer
    {
        private IncomingEmployeeContext _context;

        public IncomingEmployeeInitializer(IncomingEmployeeContext context)
        {
            _context = context;
        }

        public async Task Seed()
        {

            if (!_context.IncomingEmployees.Any())
            {
                _context.AddRange(IncomingEmployees);
                await _context.SaveChangesAsync();
            }
        }

        List<IncomingEmployee> IncomingEmployees = new List<IncomingEmployee>
        {
            new IncomingEmployee()
            {
                EmployeeId = "payrollid1",
                SSN = "000000000",
                FirstName = "Randy",
                MiddleName = "R",
                LastName = "Randleman",
                Gender = "male",
                MaritalStatus = "divorced",
                TerminationDate = null,
                TerminationReason = null,
                Address1 = "street adress",
                Address2 = "apt number",
                City = "City Wok",
                State = "MD",
                BirthDate = "01/01/1970",
                CompanyNumber = "companyid1",
                Ethnicity = "1/16th cherokee",
                HighlyCompensatedEmployee = false,
                HireDate = "01/02/2010",
                HomePhone = "301-310-3103",
                OwnerPercent = 0,
                PersonalEmailAddress = "randyrandleman@myemailaddress.com",
                PersonalMobilePhone = "555-555-5554",
                PostalCode = "2202022",
                ReHireDate = "01/03/2015",
                TaxForm = "Yo no hablo español",
                Statutory = true,
                WorkEmailAddress = "rrrandleman@randysrandleables.hotmail.us.com",
                WorkPhone = "",
                WorkPhoneExt = " ",
                PrimaryPayRate = new IncomingPrimaryPayRate()
                {
                    AnnualSalary = 50000,
                    BaseRate = 25,
                    DefaultHours = 40,
                    PayFrequency = "Bi-Weekly",
                    PrimaryPayRateEffectiveDate = "01/01/2018",
                    Salary = null,
                    PayType = "Salary"
                },
                DepartmentPosition = new IncomingDepartmentPosition()
                {
                    JobTitle = "TestJobTitle"
                }

            },
                    new IncomingEmployee()
            {
                EmployeeId = "2",
                SSN = "ssn2",
                FirstName = "Chet",
                MiddleName = "",
                LastName = "Manly",
                Gender = "male",
                MaritalStatus = "divorced",
                TerminationDate = "string",
                TerminationReason = "drinking on the job'",
                Address1 = "34623 Street Rd",
                Address2 = "",
                City = "Buford",
                State = "Wyoming",
                BirthDate = "the correct date of my birth",
                CompanyNumber = "companynumber1",
                Ethnicity = "1/16th cherokee",
                HighlyCompensatedEmployee = false,
                HireDate = "an appropriate string representing the hire date of rady r randleman",
                HomePhone = "301-310-3103",
                OwnerPercent = 0,
                PersonalEmailAddress = "randyrandleman@myemailaddress.com",
                PersonalMobilePhone = "555-555-5554",
                PostalCode = "2202022",
                ReHireDate = "not applicable",
                TaxForm = "Yo no hablo español",
                Statutory = true,
                WorkEmailAddress = "rrrandleman@randysrandleables.hotmail.us.com",
                WorkPhone = "see personal phone",
                WorkPhoneExt = " ",
            },
                    new IncomingEmployee()
            {
                EmployeeId = "3",
                SSN = "ssn3",
                FirstName = "Topper",
                MiddleName = "P",
                LastName = "Bottoms",
                Gender = "male",
                MaritalStatus = "partnered",
                TerminationDate = "string",
                TerminationReason = " bathing in chocolate fountain",
                Address1 = "U.S.S. Rough Service",
                Address2 = "",
                City = "the ocean",
                State = "literally none",
                BirthDate = "the correct date of my birth",
                CompanyNumber = "companynumber1",
                Ethnicity = "1/16th cherokee",
                HighlyCompensatedEmployee = false,
                HireDate = "an appropriate string representing the hire date of rady r randleman",
                HomePhone = "301-310-3103",
                OwnerPercent = 0,
                PersonalEmailAddress = "randyrandleman@myemailaddress.com",
                PersonalMobilePhone = "555-555-5554",
                PostalCode = "2202022",
                ReHireDate = "not applicable",
                TaxForm = "Yo no hablo español",
                Statutory = true,
                WorkEmailAddress = "rrrandleman@randysrandleables.hotmail.us.com",
                WorkPhone = "see personal phone",
                WorkPhoneExt = " ",
            },
            new IncomingEmployee()
            {
                EmployeeId = "4",
                SSN = "ssn4",
                FirstName = "Randy",
                MiddleName = "Rando",
                LastName = "Magnum",
                Gender = "male",
                MaritalStatus = "married",
                TerminationDate = "string",
                TerminationReason = "secretly setting up cameras around the office ",
                Address1 = "12345 my street ave",
                Address2 = "",
                City = "the city I live in",
                State = "the state in which the county in which the city I live in is located",
                BirthDate = "the correct date of my birth",
                CompanyNumber = "companynumber1",
                Ethnicity = "1/16th cherokee",
                HighlyCompensatedEmployee = false,
                HireDate = "an appropriate string representing the hire date of rady r randleman",
                HomePhone = "301-310-3103",
                OwnerPercent = 0,
                PersonalEmailAddress = "randyrandleman@myemailaddress.com",
                PersonalMobilePhone = "555-555-5554",
                PostalCode = "2202022",
                ReHireDate = "not applicable",
                TaxForm = "Yo no hablo español",
                Statutory = true,
                WorkEmailAddress = "rrrandleman@randysrandleables.hotmail.us.com",
                WorkPhone = "see personal phone",
                WorkPhoneExt = " ",

            },
        };
    }
}