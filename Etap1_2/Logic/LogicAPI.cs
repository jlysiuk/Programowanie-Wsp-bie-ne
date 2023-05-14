using Data;

namespace Logic {
    public interface LogicAPI {                        //API, ktore implementuje warstwa logiki aplikacji
        void createBalls(int amount);
        void removeBalls(int amount);
        int getAmountOfBalls();
        Ball getBall(int index);
        void start();
        void stop();
    }
}
