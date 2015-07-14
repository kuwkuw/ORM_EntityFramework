using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrmTestwork.Context;
using OrmTestwork.Entities;

namespace OrmTestwork
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var cntx=new AcabemyContext())
            {
                Console.WriteLine("List of persons, who passed tests.");
                cntx.TestWorks.Select(tw=>tw.User).Distinct().ToList().ForEach(u=>Console.WriteLine(u.Name));

                Console.WriteLine("\nList of persons, who passed tests successfully.");
                cntx.TestWorks
                    .Where(tw => tw.Mark >= tw.Test.PassMark)
                    .Select(tw => tw.User).Distinct().ToList()
                    .ForEach(u => Console.WriteLine(u.Name));
                
                Console.WriteLine("\nList of persons, who passed tests successfully and in time.");
                cntx.TestWorks
                    .Where(tw => tw.Mark >= tw.Test.PassMark && tw.Time<=tw.Test.MaxTime)
                    .Select(tw => tw.User).Distinct().ToList()
                    .ForEach(u => Console.WriteLine(u.Name));

                Console.WriteLine("\nList of persons, who passed tests successfully and not in time.");
                cntx.TestWorks
                    .Where(tw => tw.Mark >= tw.Test.PassMark && tw.Time > tw.Test.MaxTime)
                    .Select(tw => tw.User).ToList()
                    .ForEach(u => Console.WriteLine(u.Name));
                
                Console.WriteLine("\nList of persons by city.");
                cntx.Users.GroupBy(u => u.City,(key, g)=>new {City=key, Users=g.ToList()}).ToList().ForEach(
                    g => { Console.WriteLine(g.City+": "); g.Users.ForEach(u=>Console.WriteLine(u.Name+" ")); });

                Console.WriteLine("\nList of successful  persons by city.");
                cntx.TestWorks
                    .Where(tw => tw.Mark >= tw.Test.PassMark && tw.Time<=tw.Test.MaxTime)
                    .Select(tw => tw.User)
                    .Distinct()
                    .GroupBy(u => u.City, (k, g) => new { City = k, Users = g.ToList() })
                    .ToList()
                    .ForEach(g => { Console.WriteLine(g.City+": "); g.Users.ForEach(u=>Console.WriteLine(u.Name+" ")); });

                Console.WriteLine("\nThe result of everyone  student.");
                cntx.TestWorks.GroupBy(tw=>tw.User.Name,(k,g)=>new{Name=k, mark=g.ToList()}).ToList().ForEach(
                    u =>
                    {
                        Console.WriteLine(u.Name);
                        u.mark.ForEach(m => Console.WriteLine("Category:{0} mark:{1} mark:{2}% time:{3}", m.Test.TestCategory, m.Mark, m.Mark/0.05, m.Time));
                    });

                Console.WriteLine("\nQuestions rating");
                var lst = new List<Question>();
                cntx.Tests.ToList().ForEach(t => t.Questions.ToList().ForEach(q => lst.Add(q)));
                lst.GroupBy(q => q.QuestionText, (k, g) => new { QuestionText=k, count=g.Count() })
                    .ToList().ForEach(q => Console.WriteLine(" rating:{1}  {0}", q.QuestionText, q.count));

                Console.WriteLine("\nTeacher rating");
                cntx.Teachers
                    .Select(t=>new {Teacher=t.TeacherName, LectureCount=t.Lectures.Count})
                    .ToList().ForEach(t=>Console.WriteLine("rating:{0} {1}",t.LectureCount, t.Teacher));

                Console.WriteLine("\nAverage mark by category");
                cntx.TestWorks
                    .GroupBy(tw=>tw.Test.TestCategory, (k, g)=>new { Category=k, AvgMark=g.Average(m=>m.Mark)})
                    .ToList().ForEach(gr=>Console.WriteLine("Group:{0} avg mark:{1}", gr.Category, gr.AvgMark));
            }

            Console.ReadLine();
        }
    }
}
