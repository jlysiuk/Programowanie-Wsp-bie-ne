using System;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;
using Data;

namespace Logic {

    //Ruch kuli jako zadanie
    public class BallMovementHandler {
        private Ball _ball;
        public event EventHandler<BallMovementHandler> _ballMovementDetection;
        private int _index;
        private Repository _repository { get; set; }

        //Konstruktor
        public BallMovementHandler(Ball ball, int index, Repository repository) {
            this._ball = ball;
            this._index = index;
            this._repository = repository;
        }

        //Przekazanie informacji o zmianie pozycji do EventHandlera
        private void onPositionChange(BallMovementHandler movement) {
            _ballMovementDetection(this, movement);
        }

        //Getter na obiekt kuli
        public Ball get() {
            return _ball;
        }

        //Metoda odpowiadajaca za ruch kuli, kazda kula ma jej oddzielna instancje
        public void moveBall() {
            try {
                while (true) {
                    //Wykrycie kolizji miedzy dwiema kulami
                    lock (_repository) {
                        for (int i = 0; i < _repository.size(); i++) {
                            Ball ball = _repository.get(i);
                            if (didBallsCollide(_ball, ball)) {
                                int oneXSpeed = (_ball.xDirection() * (_ball.mass() - ball.mass()) + (2 * ball.mass() * ball.xDirection())) / (_ball.mass() + ball.mass());
                                int oneYSpeed = (_ball.yDirection() * (_ball.mass() - ball.mass()) + (2 * ball.mass() * ball.yDirection())) / (_ball.mass() + ball.mass());
                                int twoXSpeed = (ball.xDirection() * (ball.mass() - _ball.mass()) + (2 * _ball.mass() * _ball.xDirection())) / (_ball.mass() + ball.mass());
                                int twoYSpeed = (ball.yDirection() * (ball.mass() - _ball.mass()) + (2 * _ball.mass() * _ball.yDirection())) / (_ball.mass() + ball.mass());
                                _ball.changeXDirection(oneXSpeed);
                                _ball.changeYDirection(oneYSpeed);
                                ball.changeXDirection(twoXSpeed);
                                ball.changeYDirection(twoYSpeed);
                            }
                        }
                        //Zamiana kierunku ruchu kul, jezeli trafia w sciane
                        if (_ball.x() >= Surface.LEFT_CORNER_X + Surface.WIDTH - 30 || _ball.x() <= Surface.LEFT_CORNER_X) {
                            if (_ball.xDirection() > 0) {
                                _ball.changeXDirection(_ball.xDirection() * -1);
                            }
                            else if (_ball.xDirection() < 0) {
                                _ball.changeXDirection(Math.Abs(_ball.xDirection()));
                            }
                        }
                        if (_ball.y() >= Surface.LEFT_CORNER_Y + Surface.HEIGHT - 50 || _ball.y() <= Surface.LEFT_CORNER_Y - 20) {
                            if (_ball.yDirection() > 0) {
                                _ball.changeYDirection(_ball.yDirection() * -1);
                            }
                            else if (_ball.yDirection() < 0) {
                                _ball.changeYDirection(Math.Abs(_ball.yDirection()));
                            }
                        }
                    }
                    //Zmiana pozycji kuli
                    _ball.move();

                    onPositionChange(this);
                    //Opoznienie pomiedzy kazda zamiana pozycji, bez niego ruch bedzie odbywal sie tak szybko
                    //jak procesor bedzie w stanie go obliczyc
                    Thread.Sleep(10);
                }
            } catch (Exception) { }
        }

        //Getter na id danego "ruchomego obiektu" kuli
        public int index() {
            return _index;
        }

        //Metoda obliczajaca dystans pomiedzy dwiema kulami i sprawdzajaca, czy sie zderzyly
        private bool didBallsCollide(Ball one, Ball two) {
            Vector2 onePos = new Vector2(one.x() + one.xDirection(), one.y() + one.yDirection());
            Vector2 twoPos = new Vector2(two.x() + two.xDirection(), two.y() + two.yDirection());
            if (Vector2.Distance(onePos, twoPos) < 30) {
                return true;
            }
            return false;
        }
    }
}
