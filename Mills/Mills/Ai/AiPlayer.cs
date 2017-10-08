using System;
using Mills.ConsoleClient.Ai;
using Mills.ConsoleClient.Board;
using Mills.ConsoleClient.GameController;

namespace Mills.ConsoleClient.Player {
    /// <summary>
    /// This class represents a Player, that is controlled by the computer
    /// It Analyzes the board and acts afterwards
    /// </summary>
    public abstract class AiPlayer : BasePlayer, IAiPlayer {
        private IGameController _gameController;
        private IBoardAnalyzer _boardAnalyzer;
        private GamePhases _currentPhase;

        /// <inheritdoc />
        public IGameController GameController => this._gameController;
        /// <inheritdoc />
        public IBoardAnalyzer BoardAnalyzer => this._boardAnalyzer;

        /// <inheritdoc />
        public GamePhases CurrentPhase => this._currentPhase;

        /// <inheritdoc />
        protected AiPlayer(IGameController controller, IBoardAnalyzer analyzer) : base("Computer") {
            this._gameController = controller;
            this._boardAnalyzer = analyzer;
        }

        /// <inheritdoc />
        public Move Analyse() {
            this._currentPhase = GetCurrentPhase();
            return AnalyseInternal();
        }

        protected abstract Move AnalyseInternal();

        /// <inheritdoc />
        public void Act(Move move) {
            throw new System.NotImplementedException();
        }
        
        private GamePhases GetCurrentPhase() {
            throw new NotImplementedException();
        }
    }
}