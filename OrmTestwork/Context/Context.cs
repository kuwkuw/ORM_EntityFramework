using System.Data.Entity;
using EntityTestwork.Initialaze;
using OrmTestwork.Entities;

namespace OrmTestwork.Context
{
    public class AcabemyContext :DbContext
    {
        public AcabemyContext() : base("AcademyBase")
        {
            Database.SetInitializer<AcabemyContext>(new AcademyDbInitializer());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<TestWork> TestWorks { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Lecture> Lectures { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configure domain classes using modelBuilder here
           
            base.OnModelCreating(modelBuilder);
        }
    }
}
