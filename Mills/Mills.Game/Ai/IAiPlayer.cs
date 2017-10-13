using Mills.Board.Logic.Contract;
using Mills.Game.Contract;
using Mills.Game.Contract.Data;
using Mills.Game.Data.Contract;

namespace Mills.Game.Ai {
    public interface IAiPlayer {
        IGameController GameController { get; }

        IBoardAnalyzer BoardAnalyzer { get; }

        GamePhases CurrentPhase { get; }

        Move Analyse();

        void Act(Move move);
    }
}