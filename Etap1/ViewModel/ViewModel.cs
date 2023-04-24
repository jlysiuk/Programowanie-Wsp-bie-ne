using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ViewModel {
    //Warstwa sluzaca do komunikacji pomiedzy warstwa Model i View
    public class ViewModel : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        private Model.Model _model;
        public ObservableBallCollection<BallPositionAndMovementChange> _balls { get; set; }
        //Obiekty ICommand bedace poleceniami wywolywanymi poprzez korzystanie z kontrolek
        public ICommand AddBallButton { get; set; }
        public ICommand ClearBoardButton { get; set; }
        //Ilosc kul, przy zmianie tej wartosci do EventHandlera od razu przekazywana jest informacja
        public int amountOfBalls { 
            get {
                return _model.getAmountOfBalls();
            } set {
                _model.setAmountOfBalls(value);
                onPropertyChanged();
            }
        }

        //Konstruktor
        public ViewModel() { 
            _model = new Model.Model();
            _balls = new ObservableBallCollection<BallPositionAndMovementChange>();
            amountOfBalls = 5;
            AddBallButton = new Relay(_addBallButton);
            ClearBoardButton = new Relay(_clearBoardButton);
        }

        //Metoda przekazujaca informacje do EventHandlera
        public void onPropertyChanged([CallerMemberName] string propertyName = null) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        //Metody, ktore sa wywolane poprzez wcisnienie przycisku w warstwie View,
        //sa przekazywane do klasy Relay, ktora odpowiada za ich wywolanie
        private void _addBallButton(object obj) {
            _model.setAmountOfBalls(amountOfBalls);
            for (int i = 0; i < _model.getAmountOfBalls(); i++) {
                BallPositionAndMovementChange change = new BallPositionAndMovementChange();
                _balls.Add(change);
            }
            _model._ballMovementDetection += (sender, e) => {
                try {
                    _balls[e.index()].changePosition(e.x(), e.y());
                } catch (ArgumentOutOfRangeException) {

                }
            };
            _model.start();
        }

        private void _clearBoardButton(object obj) {
            _model.stop();
            _balls.Clear();
            _model.setAmountOfBalls(amountOfBalls);
        }
    }
}