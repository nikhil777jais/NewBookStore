using System;
using Microsoft.EntityFrameworkCore;
using ORMTestingEFC.Models;

namespace ORMTestingEFC {
  internal class Program {
    public static void Main(string[] args) {
      set_student("Shivam", "Ayodhya", "UttarPradesh");
      set_student("Aman", "Lucknow", "UttarPradesh");
      set_student("Rohan", "Ludhiyana", "Punjab");
      set_student("Rishabh", "Jaipur", "Rajasthan");

      update_student_by_id(7, City: "Alvar");

      get_student_by_id(1);

      delete_student_by_id(2);

      var stulst = get_all_student();

      //List<Student> stulst;
      //using (var db = new StudentDbContext()){
      //  //stulst = db.Students.ToList();
      //  stulst = db.Students.Where(stu => stu.State == "UttarPradesh").ToList();

      //}


      Console.WriteLine(String.Format("{0,-5} {1,-15} {2,-15} {3,-20}","Id","Name","City","State"));
      Console.WriteLine();
      foreach(var stu in stulst) {
        Console.WriteLine("{0,-5} {1,-15} {2,-15} {3,-20}", stu.Id, stu.Name, stu.City, stu.State);
      }
    }

    static void set_student(string Name, string City, string State){
      using (var db = new StudentDbContext()){
        Student stu = new Student();
 
        stu.Name = Name;
        stu.City = City;
        stu.State = State;

        db.Add(stu);
        db.SaveChanges();
      }
    }
    static List<Student> get_all_student(){
      List<Student> students = new List<Student>();
      using (var db = new StudentDbContext()){
        foreach (Student stu in db.Students){
          students.Add(stu);
        }
      }
      return students;
    }
    static void get_student_by_id(int id){
      using (var db = new StudentDbContext()) {
        Student stu = db.Students.Find(id);
        if (stu != null) {
          Console.WriteLine("{0} {1} {2} {3}", stu.Id, stu.Name, stu.City, stu.State);
        }
      }
    }
    static void update_student_by_id(int id, string Name = null, string City = null, string State = null)
    {
      using (var db = new StudentDbContext()) {
        Student stu = db.Students.Find(id);
        stu.Name = Name != null ? Name : stu.Name;
        stu.City = City != null ? City : stu.City;
        stu.State = State != null ? State : stu.State;
        db.SaveChanges();
      }
    }
    static void delete_student_by_id(int id){
      using (var db = new StudentDbContext()){
        Student stu = db.Students.Find(id);
        db.Students.Remove(stu);
        db.SaveChanges();
      }
    }
  }
}