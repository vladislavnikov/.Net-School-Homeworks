using task2._3;
using Task2._3;

namespace TrainingTests
{
    [TestClass]
    public class TrainingAddingTests
    {
        [TestMethod]
        public void TrainingAdding()
        {
            Lecture lecture = new Lecture("Lecture 1", "Topic 1");

            PracticalLesson lesson = new PracticalLesson("Lesson 1", "Task 1", "Solution 1");

            Training training = new Training("Training Description");

            training.Add(lecture);
            Assert.AreEqual(1, training.Courses.Length);

            training.Add(lesson);
            Assert.AreEqual(2, training.Courses.Length);
        }
    }
}
