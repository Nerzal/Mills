using Mills.ConsoleClient.GameController;

namespace Mills.ConsoleClient.Ai {
    public interface IAiPlayer {
        IGameController GameController { get; }

        void Analyse();

        void Act();
    }
}