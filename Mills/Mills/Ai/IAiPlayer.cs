using Mills.ConsoleClient.Board;
using Mills.ConsoleClient.Board.Analyzer;
using Mills.ConsoleClient.GameController;

namespace Mills.ConsoleClient.Ai {
    public interface IAiPlayer {
        IGameController GameController { get; }

        IBoardAnalyzer BoardAnalyzer { get; }

        GamePhases CurrentPhase { get; }

        Move Analyse();

        void Act(Move move);
    }
}