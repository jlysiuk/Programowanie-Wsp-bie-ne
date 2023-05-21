namespace Data {
    public class Ball {                                                 //Klasa reprezentujaca kule (jej pozycje oraz kierunek ruchu)
        private int _x;                                                 //Pozycja kuli w osi x na planszy (wartosc pomiedzy 299 a 750)
        private int _y;                                                 //Pozycja kuli w osi y na planszy (wartosc pomiedzy 41 a 409)
        private int _xDirection;                                        //Kierunek, w ktorym porusza sie kula w osi x (wartosc pomiedzy -1 a 1)
        private int _yDirection;                                        //Kierunek, w ktorym porusza sie kula w osi y (wartosc pomiedzy -1 a 1)
        private int _mass;

        public Ball (int x, int y, int xDirection, int yDirection, int mass) {    //Konsturktor parametrowy, tworzy kule w podanym miejsu poruszajaca sie w podanym kierunku
            _x = x;
            _y = y;
            _xDirection = xDirection;
            _yDirection = yDirection;
            _mass = mass;
        }

        public Ball() {

        }

        public int x() {                                                //Getter pozycji na osi x
            return _x;
        }
        public int y() {                                                //Getter pozycji na osi y
            return _y;
        }

        public int xDirection() {                                       //Getter kierunku ruchu w osi x
            return _xDirection;
        }

        public int yDirection() {                                       //Getter kierunku ruchu w osi y
            return _yDirection;
        }

        public void move() {                                            //Metoda przmieszczajaca kule poprzez dodanie do jej pozycji kierunku ruchu
            _x += _xDirection;                                          //Jezeli kierunek ruchu w osi x to -1, kula porusza sie w lewo, jezeli 0 to nie porusza sie w osji x, a 1 to w prawo
            _y += _yDirection;                                          //Os y tak samo tylko ruch w osi pionowej
        }

        public void changeXDirection(int newXDirection) {               //Metoda potrzebna do zmiany ruchu w osi x, jezli kula natrafi na sciane
            _xDirection = newXDirection;
        }

        public void changeYDirection(int newYDirection) {               //Metoda potrzebna do zmiany ruchu w osi y, jezeli kula natrafi na sciane
            _yDirection = newYDirection;
        }

        public void setPos(int x, int y) {
            _x = x;
            _y = y;
        }

        public int mass() {
            return _mass;
        }

    }
}
