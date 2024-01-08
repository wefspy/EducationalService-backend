using EducationalWebService.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EducationalWebService.Data.Context;

public class EducationalWebServiceContext : IdentityDbContext<User, Role, Guid>
{
    public DbSet<User> User { get; set; } = null!;
    public DbSet<Jeopardy> Jeopardy { get; set; } = null!;
    public DbSet<JeopardyPlayer> JeopardyPlayer { get; set; } = null!;
    public DbSet<JeopardyQuestion> JeopardyQuestion { get; set; } = null!;
    public DbSet<JeopardySession> JeopardySession { get; set; } = null!;
    public DbSet<JeopardyTopic> JeopardyTopic { get; set; } = null!;

    public EducationalWebServiceContext(DbContextOptions<EducationalWebServiceContext> options): base(options) 
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}

