using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions options)
        :base(options)
    {
    
    }

    public DbSet<Doctor>? Doctors { get; set; }

}