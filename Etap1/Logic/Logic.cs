using Data;
using System;
using System.Threading;
using System.Collections.Generic;

namespace Logic {
    //Logika calej aplikacji
    public class Logic : LogicAPI {
        private Repository _repository;
        public event EventHandler<BallMovementHandler> _movementDetectionEvent;
        private List<Thread> _threads = new List<Thread>();
        private int _nextBallIndex = 0;
        private int _previousAmountOfCreatedBalls = 0;

        //Konstruktor
        public Logic() {  
            _repository = new Repository();
        }

        //Metoda tworzaca podana ilosc instancji kul
        public void createBalls(int amount) {
            for (int i = 0; i < amount; i++) {
                _repository.add(createBall());
            }
        }

        //Metoda tworzaca kule
        private Ball createBall() {
            Random randomizer = new Random(Guid.NewGuid().GetHashCode());
            int _x = randomizer.Next(Surface.LEFT_CORNER_X + 100, Surface.LEFT_CORNER_X + Surface.WIDTH - 100);
            int _y = randomizer.Next(Surface.LEFT_CORNER_Y + 100, Surface.LEFT_CORNER_Y + Surface.HEIGHT - 100);
            int _xDirection = randomizer.Next(-1, 2);
            int _yDirection = randomizer.Next(-1, 2);
            while (_xDirection == 0 && _yDirection == 0) {
                _xDirection = randomizer.Next(-1, 2);
                _yDirection = randomizer.Next(-1, 2);
            }
            return new Ball(_x, _y, _xDirection, _yDirection);
        }

        //Getter na kule o danym indeksie
        public Ball getBall(int index) {
            return _repository.get(index);
        }

        //Getter na ilosc kul w repozytorium
        public int getAmountOfBalls() {
            return _repository.size();
        }

        //Usuwa podana ilosc kul z repozytorium
        public void removeBalls(int amount) {
            for (int i = 0; i < amount; i++) {
                _repository.remove(_repository.size() - 1);
            }
        }

        //Przekazanie informacji o zmianie pozycji do EventHandlera
        private void onPositionChange(BallMovementHandler movement) {
            _movementDetectionEvent(this, movement);
        }

        //Metoda rozpoczynajaca ruch kazdej z kul, tworzac
        //instancje metody "moveBall()" 
        public void start() {
                //Petla tworzaca "ruchome" obiekty kul i dodajace do EventHandlera informacje
            for (int i = _previousAmountOfCreatedBalls; i < _repository.size(); i++) {
                BallMovementHandler movement = new BallMovementHandler(_repository.get(i), _nextBallIndex++);
                movement._ballMovementDetection += (_, args) => {
                    onPositionChange(movement);
                };
                //Utworzenie zadania dla kuli
                Thread thread = new Thread(movement.moveBall);
                thread.Start();
                _threads.Add(thread);
            }
            //Pole okreslajace identyfikator kazdej z kul
            _previousAmountOfCreatedBalls = _repository.size();
        }

        //Metoda konczaca ruch kul
        public void stop() {
            foreach (Thread thread in _threads) {
                thread.Abort();
            }
            _threads.Clear();
            _nextBallIndex = 0;
            _previousAmountOfCreatedBalls = 0;
        }

        public List<Thread> getThreads() {
            return _threads;
        }
    }
}