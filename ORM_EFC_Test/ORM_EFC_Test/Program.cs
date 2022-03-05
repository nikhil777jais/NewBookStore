using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLibrary;
using Microsoft.EntityFrameworkCore;
namespace ORM_ERC_Test
{
  public class Program
  {
    static IList<Author> CreateFakeData()
    {
      var author = new List<Author>()
      {
        new Author
        {
          Name = "Nikhil", Books = new List<Book>()
          {
            new Book() { Title = "Money Hiest", PublishYear = 2006 },
            new Book() { Title = "Lord of Rings", PublishYear = 2001},
            new Book() { Title = "Harry Ptter", PublishYear = 2004}
          }
        },
        new Author
        {
          Name = "Rajat", Books = new List<Book>()
          {
            new Book() { Title = "Money Hiest 1", PublishYear = 2005 },
            new Book() { Title = "Lord of Rings 1", PublishYear = 2016},
            new Book() { Title = "Harry Ptter 1", PublishYear = 2008}
          }
        }
      };
      return author;
    }
    public static void Main(string [] args)
    {

      using var db = new BookContextDB();

      //var authors = CreateFakeData();
      //db.Authors.AddRange(authors);
      //db.SaveChanges();
      foreach (var book in db.Books.Include(b => b.Author))
      {
        Console.WriteLine($"{book} is written by {book.Author}");
      }
    }
  }
}
