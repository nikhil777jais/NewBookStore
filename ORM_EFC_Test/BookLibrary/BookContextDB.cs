using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary
{
  public class BookContextDB: DbContext
  {
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }

    private const string connectionstring = "Server=.;Database=ORMTESTDB;Trusted_Connection=True;";
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(connectionstring);
    }
    //public BookContextDB(DbContextOptions<BookContextDB> options) : base(options)
    //{

    //}
  }
}
