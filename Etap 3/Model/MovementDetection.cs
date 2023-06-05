using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model {
    //Event odpowiedzialny za dostarczanie informacji do EventHandlera o zmianie pozycji
    public class MovementDetection : EventArgs {
        private int _x;
        private int _y;
        public int _index;

        public MovementDetection(int x, int y, int index) {
            _x = x;
            _y = y;
            _index = index;
        }

        public int x() {
            return _x;
        }

        public int y() {
            return _y;
        }

        public int index() {
            return _index;
        }
    }
}
