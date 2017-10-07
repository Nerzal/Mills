﻿using System;
using Mills.ConsoleClient.Rules;

namespace Mills.ConsoleClient {
    /// <summary>
    /// Implementation of <see cref="IGameController"/>
    /// Controls the game
    /// </summary>
    internal class GameController : IGameController {
        public event Action<IPlayer> PlayerWon;

        private GamePhases _activePhase;
        private IPlayer _player1;
        private IPlayer _player2;
        private readonly IBoard _board;
        private readonly IMillRuleValidator _ruleValidator;
        private readonly IHistory _history;

        public IPlayer ActivePlayer { get; private set; }

        public int Round { get; private set; }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="ruleValidator"></param>
        /// <param name="board"></param>
        /// <param name="history"></param>
        public GameController(IMillRuleValidator ruleValidator, IBoard board, IHistory history) {
            this._activePhase = GamePhases.Set;
            this._ruleValidator = ruleValidator;
            this._board = board;
            this._history = history;
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
        public bool DoTurn(Move move) {
            if (!this._ruleValidator.ValidateMovement(move)) {
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

        private bool IsGameOver() {
            return this._ruleValidator.IsGameOver(this._board);
        }

        private void ApplyMove(Move mühv) {
            this._board.Move(mühv);
            this._history.Add(mühv);
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