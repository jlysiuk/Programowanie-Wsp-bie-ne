namespace Data {
    public interface DataAPI {                     //API, ktore implementuje warstwa danych
        void add(Ball newBall);
        void remove(int index);
        void clear();
        Ball get(int index);
        int size();
    }
}
