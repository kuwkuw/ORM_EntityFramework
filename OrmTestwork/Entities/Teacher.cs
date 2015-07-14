using System.Collections.Generic;

namespace OrmTestwork.Entities
{
    public class Teacher
    {
        public Teacher()
        {
            Lectures = new HashSet<Lecture>();
        }
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }

        public virtual ICollection<Lecture> Lectures { get; set; }
    }
}
