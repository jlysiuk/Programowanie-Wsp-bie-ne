using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ViewModel {
    //Obiekt kuli reagujacy na zmiany jej pozycji
    public class BallPositionAndMovementChange : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        private int _x;
        private int _y;

        //Metoda przekazujaca informacje do EventHandlera o zmianie pozycji kuli
        private void onPropertyChanged([CallerMemberName] string propertyName = null) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        //Wspolrzedna x
        public int x {
            get {
                return _x;
            } set {
                _x = value;
                onPropertyChanged();
            }
        }

        //Wspolrzedna y
        public int y {
            get {
                return _y;
            } set {
                _y = value;
                onPropertyChanged();
            }
        }

        //Konstruktor
        public BallPositionAndMovementChange() {
            _x = 0;
            _y = 0;
        }

        //Zmiana pozycji kuli
        public void changePosition(int x, int y) {
            this.x = x;
            this.y = y;
        }
    }
}