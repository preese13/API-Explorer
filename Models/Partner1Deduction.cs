using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


[ApiExplorerSettings(IgnoreApi = true)]

public class Partner1Deduction
{
    public string Agency { get; set; }
    public decimal? AnnualMaximum { get; set; }
    [JsonProperty]
    public string CalcCode { get; set; }
    public string CaseNo { get; set; }
    [Required]
    [JsonProperty]
    public string CompanyNumber { get; set; }
    [Required]
    public string CostCenter1 { get; set; }
    public string CostCenter2 { get; set; }
    public string CostCenter3 { get; set; }
    [Required]
    [JsonProperty]
    [Key]
    public string Dcode { get; set; }
    [JsonProperty]
    public string EffectiveDate { get; set; }
    [Required]
    [JsonProperty]
    public string EmployeeId { get; set; }
    [JsonProperty]
    public string EndDate { get; set; }
    public string FipsCode { get; set; }
    public string Frequency { get; set; }
    public decimal? Goal { get; set; }
    public bool? IsSelfInsuredPlan { get; set; }
    public string LoanFirstPaymentDate401K { get; set; }
    public string LoanIssueDate401K { get; set; }
    public string LoadNumber { get; set; }
    public decimal? Maximum { get; set; }
    public bool? MedicalSupport { get; set; }
    public decimal? Minimum { get; set; }
    public string MiscInfo { get; set; }
    public decimal? PaidTowardsGoal { get; set; }
    public string Priority { get; set; }
    [JsonProperty]
    public decimal? Rate { get; set; }
    public bool? ReportTerminated { get; set; }
    [Required]
    public string SSN { get; set; }
    [JsonProperty]
    public string StartDate { get; set; }
    public string StateAbbrev { get; set; }
}