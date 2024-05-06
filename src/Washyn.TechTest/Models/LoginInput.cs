using System.ComponentModel.DataAnnotations;

namespace Washyn.TechTest.Models;

public class LoginInput
{
    [Required] public string User { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}