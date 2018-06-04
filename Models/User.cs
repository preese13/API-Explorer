using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace mockAPI.Models
{
    public class User
    {
        [Key]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

