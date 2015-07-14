using System.Collections.Generic;

namespace OrmTestwork.Entities
{
    public class User
    {
        public User()
        {
            //TestWorks = new HashSet<TestWork>();
        }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string University { get; set; }
        public Category UserCategory { get; set; }

        public virtual ICollection<TestWork> TestWorks { get; set; }
    }
}
