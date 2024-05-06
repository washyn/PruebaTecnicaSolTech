using Volo.Abp.Application.Dtos;

namespace Washyn.TechTest.Services.Dto;

public class UsuarioDto : EntityDto<Guid>
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string? PhoneNumber { get; set; }
}