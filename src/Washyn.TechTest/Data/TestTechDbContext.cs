using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Washyn.TechTest.Entities;

namespace Washyn.TechTest.Data;

public class TestTechDbContext : AbpDbContext<TestTechDbContext>
{
    public virtual DbSet<Usuario> Usuarios { get; set; }
    
    public TestTechDbContext(DbContextOptions<TestTechDbContext> options)
        : base(options)
    {
    }
}
