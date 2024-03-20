using Microsoft.EntityFrameworkCore;
using Programlama2_UygulamaProjesi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DbContextFolder;

public class OdevDbContext : DbContext
{
    public DbSet<KonuClass> Konular { get; set; }
    public DbSet<SoruClass> Sorular { get; set; }
    public DbSet<SoruCevap> SoruAndCevap { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.;Database=ProgramlamaOdevi;User Id=erennali;Password=123456;TrustServerCertificate=True");
        base.OnConfiguring(optionsBuilder);
    }

}
