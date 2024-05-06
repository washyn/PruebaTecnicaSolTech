using Volo.Abp.Domain.Repositories;
using Washyn.TechTest.Entities;

namespace Washyn.TechTest.Repositories;

public interface IUsuarioRepository : IRepository<Usuario, Guid>
{
    
}