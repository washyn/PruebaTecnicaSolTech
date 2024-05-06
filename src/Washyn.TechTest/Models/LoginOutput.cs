using System.ComponentModel.DataAnnotations;

namespace Washyn.TechTest.Models;

public class LoginOutput
{
    [Required] public string AccessToken { get; set; }
}