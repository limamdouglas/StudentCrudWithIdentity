using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentCrudWithIdentity.Models;

namespace StudentCrudWithIdentity.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Student> Students { get; set; } = default;
    public DbSet<Premiun> Premiuns { get; set;} = default;
}
