using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

[JsonObject(MemberSerialization.OptIn)]
[ApiExplorerSettings(IgnoreApi = true)]

public class Partner2Deduction
{
    [Key]
    [JsonProperty("amount")]
    public decimal? Amount { get; set; }
    [JsonProperty("rate")]
    public decimal? Rate { get; set; }
    [JsonProperty("effectiveDate")]
    public string EffectiveDate { get; set; }
}