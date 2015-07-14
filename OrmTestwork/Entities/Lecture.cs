using System.Collections.Generic;

namespace OrmTestwork.Entities
{
    public class Lecture
    {
        public Lecture()
        {
            Teachers = new HashSet<Teacher>();
        }

        public int LectureId { get; set; }
        public string LectureName { get; set; }
        public Category LectureCategory { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
