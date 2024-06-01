

namespace task2._3
{
    public class Lecture : BaseCourse
    {
        public string Topic { get; set; }

        public Lecture(string description, string topic) : base(description)
        {
            Topic = topic;
        }

        public override Lecture Clone()
        {
            return new Lecture(Description, Topic);
        }
    }
}
