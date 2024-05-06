using System.ComponentModel.DataAnnotations;

namespace Washyn.TechTest.Services.Dto;

public class UsuarioUpdateDto
{
    [Required]
    public string UserName { get; set; }
    
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Surname { get; set; }
    public string? PhoneNumber { get; set; }
}