
namespace task2._3
{
    public abstract class BaseCourse : StudyCourse, IBaseCourseCloanble
    {
        protected BaseCourse(string description) : base(description)
        {
        }

        public abstract BaseCourse Clone();
    }
}
