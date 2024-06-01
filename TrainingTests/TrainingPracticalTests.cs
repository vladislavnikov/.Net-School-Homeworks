using task2._3;
using Task2._3;

namespace TrainingTests
{
    [TestClass]
    public class TrainingPracticalTests
    {
        [TestMethod]
        public void TrainingIsPracticalPositive()
        {
            Lecture[] lectures = { new Lecture("description", "topic") };
            PracticalLesson[] lessons = { new PracticalLesson("description", "task", "solution") };

            Training training = new Training("description");

            foreach (var lecture in lectures)
            {
                training.Add(lecture);
            }

            foreach (var lesson in lessons)
            {
                training.Add(lesson);
            }

            Assert.IsFalse(training.IsPractical());
        }

        [TestMethod]
        public void TrainingIsPracticalNegative()
        {
            Lecture[] lectures = { };
            PracticalLesson[] lessons = { new PracticalLesson("description", "task", "solution") };

            Training training = new Training("description");

            foreach (var lecture in lectures)
            {
                training.Add(lecture);
            }

            foreach (var lesson in lessons)
            {
                training.Add(lesson);
            }

            Assert.IsTrue(training.IsPractical());
        }
    }
}
