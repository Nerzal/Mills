using System.Collections;
using System.Collections.Generic;
using Mills.ConsoleClient.Rules.Movement;

namespace Mills.ConsoleClient.Rules.GameOver {
    /// <summary>
    /// Holds all GameOver rules
    /// </summary>
    public class GameOverRules : BaseRules<IBoard>, IGameOverRules {

        public override void Initialize() {
            this.Rules.Add(new GameOverValidationRule(PlayerHasLessThan3Stones));
        }

        private bool PlayerHasLessThan3Stones(IBoard board) {
            int player1SpotCount = 0;
            int player2SpotCount = 0;

            foreach (Spot[,] level in board.Spots) {
                foreach (Spot spot in level) {
                    if (spot.Player.Color == Colors.White) {
                        player1SpotCount++;
                    } else if (spot.Player.Color == Colors.Black) {
                        player2SpotCount++;
                    }
                }
            }

            //In phase 1 the offBoardStones need to be added to the count
            player1SpotCount += board.Player1OffBoardStones;
            player2SpotCount += board.Player2OffBoardStones;

            bool playerHasLessThan3Stones = player2SpotCount < 3 || player1SpotCount < 3;
            return playerHasLessThan3Stones;
        }
    }
}