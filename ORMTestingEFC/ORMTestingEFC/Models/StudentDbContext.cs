using System;
using Microsoft.EntityFrameworkCore;

namespace ORMTestingEFC.Models
{
  internal class StudentDbContext:DbContext
  {
    private const string connectionstring = "Server=.;Database=TestDB1;Trusted_Connection=True;";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
      optionsBuilder.UseSqlServer(connectionstring);
    }

    public DbSet<Student> Students { get; set; }
  }
}
