using System;
using System.Collections.Generic;
using Mills.Board.Logic.Contract;
using Mills.Game.Contract;
using Mills.Game.Data.Contract;
using Mills.Rules.Contract;

namespace Mills.Game.GameController {
    /// <summary>
    /// Implementation of <see cref="IGameController"/>
    /// Controls the game
    /// </summary>
    public class GameController : IGameController {
        /// <inheritdoc />
        public event Action<IPlayer> PlayerWon;

        /// <inheritdoc />
        public event Action MillCompleted;

        private IPlayer _player1;
        private IPlayer _player2;
        private readonly IBoard _board;
        private readonly IMillRuleEvaluator _ruleEvaluator;
        private readonly IHistory _history;
        private readonly IBoardController _boardController;
        private readonly IPatternRecognizer _recognizer;
        private readonly IRowController _rowController;

        /// <inheritdoc />
        public IPlayer ActivePlayer { get; private set; }

        public int Round { get; private set; }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="ruleEvaluator"></param>
        /// <param name="board"></param>
        /// <param name="history"></param>
        /// <param name="boardController"></param>
        /// <param name="recognizer"></param>
        /// <param name="rowController"></param>
        public GameController(IMillRuleEvaluator ruleEvaluator, IBoard board, IHistory history, IBoardController boardController, IPatternRecognizer recognizer, IRowController rowController) {
            this._ruleEvaluator = ruleEvaluator;
            this._board = board;
            this._history = history;
            this._boardController = boardController;
            this._recognizer = recognizer;
            this._rowController = rowController;
        }

        /// <inheritdoc />
        public void NewGame(IPlayer player1, IPlayer player2) {
            this._player1 = player1;
            this._player1.Color = Colors.White;
            this._player2 = player2;
            this._player2.Color = Colors.Black;
            this.ActivePlayer = this._player1;
            this.Round = 0;
        }

        /// <inheritdoc />
        public bool Set(Coordinate coordinate, IPlayer activePlayer) {
            bool result = this._boardController.Set(coordinate, activePlayer);
            if (!result) {
                return result;
            }
            CheckForMill(coordinate);

            this.Round++;
            SetActivePlayer();
            return result;
        }

        private void CheckForMill(Coordinate coordinate) {
            IEnumerable<Row> mills = this._recognizer.FindAllMillsFor(this.ActivePlayer);
            foreach (Row mill in mills) {
                if (this._rowController.Contains(mill, coordinate)) {
                    this.MillCompleted?.Invoke();
                }
            }
        }

        /// <inheritdoc />
        public bool DoTurn(Move move) {
            if (!this._ruleEvaluator.ValidateMovement(move)) {
                return false;
            }

            ApplyMove(move);
            this.Round++;
            if (IsGameOver()) {
                this.PlayerWon?.Invoke(this.ActivePlayer);
            }

            SetActivePlayer();
            return true;
        }

        /// <inheritdoc />
        public bool Unset(Coordinate coordinate, IPlayer activePlayer) {
            return this._boardController.Unset(coordinate, activePlayer);
        }

        private bool IsGameOver() {
            return this._ruleEvaluator.IsGameOver(this._board);
        }

        private bool ApplyMove(Move move) {
            bool result = this._boardController.Move(move);
            if (!result) {
                return result;
            }
            this._history.Add(move);
            return result;
        }

        private void SetActivePlayer() {
            if (this.Round % 2 == 1) {
                this.ActivePlayer = this._player2;
            } else {
                this.ActivePlayer = this._player1;
            }
        }
    }
}