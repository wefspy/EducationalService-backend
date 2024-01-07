using EducationalWebService.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EducationalWebService.Data.Context;

public class EducationalWebServiceContext : IdentityDbContext<User, Role, Guid>
{
    
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

