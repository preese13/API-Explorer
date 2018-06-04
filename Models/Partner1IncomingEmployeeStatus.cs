using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

[JsonObject(MemberSerialization.OptIn)]
    public class Partner1IncomingEmployeeStatus
    {
        [Key]
        [JsonProperty]
        public string EmployeeStatusCode { get; set; }
    }