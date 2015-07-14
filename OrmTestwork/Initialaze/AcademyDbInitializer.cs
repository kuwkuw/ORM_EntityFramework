using System.Data.Entity;
using System.Linq;
using OrmTestwork.Entities;
using OrmTestwork.Context;


namespace EntityTestwork.Initialaze
{
    public class AcademyDbInitializer: DropCreateDatabaseAlways<AcabemyContext>
    {
        protected override void Seed(AcabemyContext context)
        {

            context.Users.AddRange(new User[]{
                new User
                {
                    Name = "Kushch Oleg",
                    Age = 29,
                    City = "Kharkiv",
                    Email = "kuwkuw@mail.ru",
                    University = "NTU KhPI",
                    UserCategory = Category.Net 
                },
                new User
                {
                    Name = "Egor",
                    Age = 29,
                    City = "Lviv",
                    Email = "egor@mail.com",
                    University = "LNU",
                    UserCategory = Category.Net 
                },
                new User
                {
                    Name = "Petr",
                    Age = 21,
                    City = "Kharkiv",
                    Email = "petr@mail.com",
                    University = "NTU KhPI",
                    UserCategory = Category.JS
                },
                new User
                {
                    Name = "Olga",
                    Age = 20,
                    City = "Lviv",
                    Email = "olga@mail.com",
                    University = "LPI",
                    UserCategory = Category.JS
                },
                new User
                {
                    Name = "Vasia",
                    Age = 21,
                    City = "Kiyev",
                    Email = "vasia@mail.com",
                    University = "KPI",
                    UserCategory = Category.PHP
                }
                });
            context.SaveChanges();

            context.Questions.AddRange(new Question[]
                {
                    new Question { QuestionText = "Question 1 for .Net", QuectionCategory = Category.Net },
                    new Question { QuestionText = "Question 2 for .Net", QuectionCategory = Category.Net },
                    new Question { QuestionText = "Question 1 for JS", QuectionCategory = Category.JS },
                    new Question { QuestionText = "Question 2 for JS", QuectionCategory = Category.JS },
                    new Question { QuestionText = "Question 3 for JS", QuectionCategory = Category.JS },
                    new Question { QuestionText = "Question 1 for PHP", QuectionCategory = Category.PHP },
                    new Question { QuestionText = "Question 2 for PHP", QuectionCategory = Category.PHP },
                    new Question { QuestionText = "Question OOP", QuectionCategory = Category.OOP },
                    new Question { QuestionText = "Question BD", QuectionCategory = Category.DB },
                    new Question { QuestionText = "Question English", QuectionCategory = Category.English }
                }
                );
            context.SaveChanges();

            context.Tests.AddRange(new Test[]{
                   new Test
                   {
                       TestName = "Test for .Net",
                       TestCategory = Category.Net,
                       PassMark = 4.3,
                       MaxTime = 25,
                       Questions = context.Questions.Where(q=>q.QuectionCategory==Category.Net)
                       .Union(context.Questions
                            .Where(q=>q.QuectionCategory==Category.OOP ||
                                q.QuectionCategory==Category.DB ||
                                q.QuectionCategory==Category.English)).ToList()
                   },
                new Test
                {
                    TestName = "Test for JS",
                    TestCategory = Category.JS,
                    PassMark = 4.2,
                    MaxTime = 22,
                    Questions = context.Questions.Where(q=>q.QuectionCategory==Category.JS)
                    .Union(context.Questions
                            .Where(q=>q.QuectionCategory==Category.OOP ||
                                q.QuectionCategory==Category.DB ||
                                q.QuectionCategory==Category.English)).ToList()
                },
                new Test
                {
                    TestName = "Test for PHP",
                    TestCategory = Category.PHP,
                    PassMark = 4.2,
                    MaxTime = 22,
                    Questions = context.Questions.Where(q=>q.QuectionCategory==Category.PHP)
                    .Union(context.Questions
                            .Where(q=>q.QuectionCategory==Category.OOP ||
                                q.QuectionCategory==Category.DB ||
                                q.QuectionCategory==Category.English)).ToList()
                }
               });
            context.SaveChanges();

            context.TestWorks.AddRange(new TestWork[]{
                new TestWork
                {
                    Test = context.Tests.FirstOrDefault(tw => tw.TestCategory == Category.Net),
                    User = context.Users.FirstOrDefault(u => u.Name.Equals("Kushch Oleg")),
                    Mark = 4.4,
                    Time = 24,
                },
                new TestWork
                {
                    Test = context.Tests.FirstOrDefault(tw => tw.TestCategory == Category.JS),
                    User = context.Users.FirstOrDefault(u => u.Name.Equals("Kushch Oleg")),
                    Mark = 4.4,
                    Time = 22,
                },
                new TestWork
                {
                    Test = context.Tests.FirstOrDefault(tw => tw.TestCategory == Category.Net),
                    User = context.Users.FirstOrDefault(u => u.Name.Equals("Egor")),
                    Mark = 4.4,
                    Time = 26,
                },
                new TestWork
                {
                    Test = context.Tests.FirstOrDefault(tw => tw.TestCategory == Category.JS),
                    User = context.Users.FirstOrDefault(u => u.Name.Equals("Olga")),
                    Mark = 4.1,
                    Time = 22,
                },
                new TestWork()
                {
                    Test = context.Tests.FirstOrDefault(tw => tw.TestCategory == Category.JS),
                    User = context.Users.FirstOrDefault(u => u.Name.Equals("Petr")),
                    Mark = 4.4,
                    Time = 22,
                },
                new TestWork()
                {
                    Test = context.Tests.FirstOrDefault(tw => tw.TestCategory == Category.PHP),
                    User = context.Users.FirstOrDefault(u => u.Name.Equals("Vasia")),
                    Mark = 4.3,
                    Time = 24,
                }
                });
            context.SaveChanges();

            context.Teachers.AddRange(new Teacher[]{
                new Teacher
                {
                    TeacherName = "Beseda Dmitriy",
                    Lectures = new Lecture[]
                    {
                        new Lecture {
                            Description = "BSA 15 .NET ORM (Entity Framework)",
                            LectureCategory = Category.Net, 
                            LectureName = "BSA 15 .NET ORM (Entity Framework)",
 
                        },
                        new Lecture
                        {
                            Description = ".NET. Data Structures and LINQ",
                            LectureCategory = Category.Net,
                            LectureName = ".NET. Data Structures and LINQ"
                        } 
                    }
                }
                });
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
