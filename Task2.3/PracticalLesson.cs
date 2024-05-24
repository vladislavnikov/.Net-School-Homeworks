

namespace task2._3
{
    public class PracticalLesson : BaseCourse
    {
        public string TaskLink { get; set; }
        public string SolutionLink { get; set; }
        public PracticalLesson(string description, string taskLink, string solLink) : base(description)
        {
            this.TaskLink = taskLink;
            this.SolutionLink = solLink;
        }

        public override PracticalLesson Clone()
        {
            return new PracticalLesson(Description, TaskLink, SolutionLink);
        }
    }
}
