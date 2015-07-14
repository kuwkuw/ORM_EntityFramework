using System.Collections.Generic;

namespace OrmTestwork.Entities
{
    public class Test
    {
        public Test()
        {
            Questions = new HashSet<Question>();
            //TestWorks = new HashSet<TestWork>();
        }

        public int TestId { get; set; }
        public string TestName { get; set; }
        public Category TestCategory { get; set; }
        
        public int MaxTime { get; set; }
        public double PassMark { get; set; }

        public virtual ICollection<TestWork> TestWorks { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}
