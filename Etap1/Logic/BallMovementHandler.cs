using System;
using System.Threading;
using System.Threading.Tasks;
using Data;

namespace Logic {

    //Ruch kuli jako zadanie
    public class BallMovementHandler {
        private Ball _ball;
        public event EventHandler<BallMovementHandler> _ballMovementDetection;
        private int _index;

        //Konstruktor
        public BallMovementHandler(Ball ball, int index) {
            this._ball = ball;
            this._index = index;
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
                    //Zamiana kierunku ruchu kul, jezeli trafia w sciane
                    if (_ball.x() >= Surface.LEFT_CORNER_X + Surface.WIDTH - 30 || _ball.x() <= Surface.LEFT_CORNER_X) {
                        if (_ball.xDirection() == 1) {
                            _ball.changeXDirection(-1);
                        }
                        else if (_ball.xDirection() == -1) {
                            _ball.changeXDirection(1);
                        }
                    }
                    if (_ball.y() >= Surface.LEFT_CORNER_Y + Surface.HEIGHT - 50 || _ball.y() <= Surface.LEFT_CORNER_Y - 20) {
                        if (_ball.yDirection() == 1) {
                            _ball.changeYDirection(-1);
                        }
                        else if (_ball.yDirection() == -1) {
                            _ball.changeYDirection(1);
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
    }
}
