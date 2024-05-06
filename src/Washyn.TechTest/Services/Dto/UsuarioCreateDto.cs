using System.ComponentModel.DataAnnotations;

namespace Washyn.TechTest.Services.Dto;

public class UsuarioCreateDto
{
    [Required]
    public string UserName { get; set; }
    
    [Required]
    public string Password { get; set; }
    
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Surname { get; set; }
    
    public string? PhoneNumber { get; set; }
}