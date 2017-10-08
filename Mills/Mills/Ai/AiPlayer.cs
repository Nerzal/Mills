using Mills.ConsoleClient.Ai;
using Mills.ConsoleClient.GameController;

namespace Mills.ConsoleClient.Player {
    public class AiPlayer : BasePlayer, IAiPlayer {
        private IGameController _gameController;

        public IGameController GameController => this._gameController;

                /// <inheritdoc />
        public AiPlayer(IGameController controller) : base("Computer") {
            this._gameController = controller;
        }


        public void Act() {
            throw new System.NotImplementedException();
        }

        public void Analyse() {
            throw new System.NotImplementedException();
        }
    }
}