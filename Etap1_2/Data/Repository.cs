using System;
using System.Collections.Generic;

namespace Data {
    public class Repository : DataAPI {                                     //Repozytorium przechowujace instancje kul oraz zarzadzajace nimi
        private List<Ball> _balls;                                           //Lista przechowujaca kule

        public Repository() {                                               //Konstruktor bezparametrowy, tworzy pusta liste
            _balls = new List<Ball>();
        }

        public Repository(List<Ball> balls) {
            _balls = balls;
        }

        public void add(Ball newBall) {                            //Dodanie kuli do repozytorium
            _balls.Add(newBall);
        }

        public void clear() {                                      //Usuniecie wszystkich instancji kul z repozytorium
            _balls.Clear();
        }

        public Ball get(int index) {                               //Getter zwracajace kule o danym indeksie
            try {                                                           //Jezeli taka kula nie istnieje, zwraca null
                return _balls[index];
            } catch (ArgumentOutOfRangeException) {
                return null;
            }
        }

        public void remove(int index) {                            //Usuniecie kuli o podanym indeksie z repozytorium
            _balls.Remove(get(index));
        }

        public int size() {                                        //Zwrocenie ilosci kul w repozytorium
            return _balls.Count;
        }
    }
}
