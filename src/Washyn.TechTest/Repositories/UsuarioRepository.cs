using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Washyn.TechTest.Data;
using Washyn.TechTest.Entities;

namespace Washyn.TechTest.Repositories;

public class UsuarioRepository : EfCoreRepository<TestTechDbContext,Usuario, Guid>,IUsuarioRepository
{
    public UsuarioRepository(IDbContextProvider<TestTechDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
}