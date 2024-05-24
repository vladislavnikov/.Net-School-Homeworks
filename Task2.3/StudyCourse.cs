

namespace task2._3
{
    public abstract class StudyCourse
    {
        public string Description { get; set; }

        protected StudyCourse(string description)
        {
            this.Description = description;
        }
    }
}
