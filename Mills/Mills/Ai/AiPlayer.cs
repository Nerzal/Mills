using Mills.ConsoleClient.Ai;
using Mills.ConsoleClient.Board;
using Mills.ConsoleClient.GameController;

namespace Mills.ConsoleClient.Player {
    /// <summary>
    /// This class represents a Player, that is controlled by the computer
    /// It Analyzes the board and acts afterwards
    /// </summary>
    public class AiPlayer : BasePlayer, IAiPlayer {
        private IGameController _gameController;
        private IBoardAnalyzer _boardAnalyzer;
        /// <inheritdoc />
        public IGameController GameController => this._gameController;
        /// <inheritdoc />
        public IBoardAnalyzer BoardAnalyzer => this._boardAnalyzer;

        /// <inheritdoc />
        public AiPlayer(IGameController controller, IBoardAnalyzer analyzer) : base("Computer") {
            this._gameController = controller;
            this._boardAnalyzer = analyzer;
        }

        /// <inheritdoc />
        public Move Analyse() {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public void Act(Move move) {
            throw new System.NotImplementedException();
        }
    }
}