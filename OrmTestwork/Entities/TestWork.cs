namespace OrmTestwork.Entities
{
    public class TestWork
    {

        public int TestWorkId { get; set; }
       
        public double Mark { get; set; }
        public int Time { get; set; }

        public virtual User User { get; set; }

        public virtual Test Test { get; set; }
    }
}
