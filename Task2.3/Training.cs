
using task2._3;

namespace Task2._3
{
    public class Training : StudyCourse
    {
        public BaseCourse[] Courses { get; private set; }
        private int coursesCount;

        public Training(string description) : base(description)
        {
            Courses = new BaseCourse[1];
            coursesCount = 0;
        }

        public void Add(BaseCourse course)
        {
            if (Courses.Length == coursesCount)
            {
                ResizeArray();
            }
            Courses[coursesCount] = course;
            coursesCount++;
        }

        public bool IsPractical()
        {
            foreach (var item in Courses)
            {
                if (item is Lecture)
                {
                    return false;
                }
            }
            return true;
        }

        public Training Clone()
        {
            var cloned = new Training(Description);

            foreach (var course in Courses)
            {
                if (course != null)
                {
                    cloned.Add(course.Clone());
                }
            }

            return cloned;
        }

        private void ResizeArray()
        {
            var newArray = new BaseCourse[coursesCount + 1];
            Array.Copy(Courses, newArray, coursesCount);
            Courses = newArray;
        }
    }
}
