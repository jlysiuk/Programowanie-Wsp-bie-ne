using Data;

namespace DataTest {
    public class Tests {
        [SetUp]
        public void Setup() {
        }

        [Test]
        public void BallConstructorsTest() {
            Ball ball = new Ball();
            Assert.IsNotNull(ball);
            Assert.IsTrue(ball.x() == 0 && ball.y() == 0 && ball.xDirection() == 0 && ball.yDirection() == 0 && ball.mass() == 0);
            ball = new Ball(5, 7, 1, -1, 3);
            Assert.IsTrue(ball.x() == 5 && ball.y() == 7 && ball.xDirection() == 1 && ball.yDirection() == -1 && ball.mass() == 3);
        }

        [Test]
        public void RepositoryTest() {
            Repository repository = new Repository();
            Assert.IsNotNull(repository);
            Ball ball = new Ball();
            Assert.IsTrue(repository.size() == 0);
            repository.add(ball);
            Assert.IsTrue(repository.size() == 1);
            Ball ball2 = new Ball();
            repository.add(ball2);
            Assert.IsTrue(repository.size() == 2);
            Assert.IsNull(repository.get(2));
            Assert.That(repository.get(0), Is.EqualTo(ball));
            Assert.That(repository.get(1), Is.EqualTo(ball2));
            Ball ball3 = new Ball();
            repository.add(ball3);
            Assert.IsTrue(repository.size() == 3);
            repository.remove(repository.size() - 1);
            Assert.IsTrue(repository.size() == 2);
            repository.remove(0);
            Assert.IsTrue(repository.size() == 1);
            repository.clear();
            Assert.IsTrue(repository.size() == 0);
            List<Ball> list = new List<Ball>();
            list.Add(ball);
            list.Add(ball2);
            list.Add(ball3);
            repository = new Repository(list);
            Assert.IsTrue(repository.size() == 3);
        }
    }
}