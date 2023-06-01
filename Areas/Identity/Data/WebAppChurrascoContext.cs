using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAppChurrasco.Areas.Identity.Data;
using WebAppChurrasco.Entities;

namespace WebAppChurrasco.Data;

public class WebAppChurrascoContext : IdentityDbContext<WebAppChurrascoUser>
{
    public WebAppChurrascoContext(DbContextOptions<WebAppChurrascoContext> options)
        : base(options)
    {
    }

    //Modelos
    public DbSet<Churrasco> Churrasco { get; set; }

    public DbSet<Participantes> Participantes { get; set; }

    public DbSet<AgendaChurras> AgendaChurras {  get; set; }
    

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
