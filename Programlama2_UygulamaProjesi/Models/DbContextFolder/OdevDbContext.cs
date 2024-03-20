using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DbContextFolder;

public class OdevDbContext : DbContext
{
    public DbSet<KonuClass> Subjects { get; set; }
    public DbSet<SoruClass> Questions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.;Database=ProgramlamaOdevi;User Id=erennali;Password=123456;TrustServerCertificate=True");
        base.OnConfiguring(optionsBuilder);
    }

}
