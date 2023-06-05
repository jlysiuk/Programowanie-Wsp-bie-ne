using Logic;

namespace LogicTest {
    public class Tests {
        [SetUp]
        public void Setup() {
        }

        [Test]
        public void LogicTest() {
            Logic.Logic logic = new Logic.Logic();
            logic.createBalls(5);
            Assert.True(logic.getAmountOfBalls() == 5);
            logic.start();
            Assert.True(logic.getThreads().Count == 5);
        }
    }
}