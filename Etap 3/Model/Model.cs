using System;

namespace Model {
    public class Model {
        //Warstwa wykorzystujaca logike aplikacji do interakcji z warstwa View
        private int _amountOfBalls;
        private Logic.Logic _logic;
        public event EventHandler<MovementDetection> _ballMovementDetection;

        //Konstruktor parametrowy
        public Model() { 
            _logic = new Logic.Logic();
            _amountOfBalls = 0;
            _logic._movementDetectionEvent += (sender, e) => {
                _ballMovementDetection(this, new MovementDetection(e.get().x(), e.get().y(), e.index()));
            };
        }

        //Setter do ilosci kul na planszy
        public void setAmountOfBalls(int amount) {
            _amountOfBalls = amount;
        }

        //Getter do ilosci kul na planszy
        public int getAmountOfBalls() {
            return _amountOfBalls;
        }

        //Rozpoczecie ruchu kul
        public void start() {
            _logic.createBalls(_amountOfBalls);
            _logic.start();
        }

        //Zakonczenie ruchu kul
        public void stop() {
            _logic.stop();
            _logic = new Logic.Logic();
            _logic._movementDetectionEvent += (sender, e) => {
                _ballMovementDetection(this, new MovementDetection(e.get().x(), e.get().y(), e.index()));
            };
        }
    }
}