using Volo.Abp.Domain.Entities;

namespace Washyn.TechTest.Entities;

public class Usuario : Entity<Guid>
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string? PhoneNumber { get; set; }
}