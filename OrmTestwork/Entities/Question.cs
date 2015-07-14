using System.Collections.Generic;

namespace OrmTestwork.Entities
{
    public class Question
    {
        public Question()
        {
            Tests = new HashSet<Test>();
        }

        public int QuestionId { get; set; }
        public Category QuectionCategory { get; set; }
        public string QuestionText { get; set; }

        public virtual ICollection<Test> Tests { get; set; }
    }
}
