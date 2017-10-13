namespace Mills.Game.Data.Contract {
    /// <summary>
    /// Represents a spot on the board
    /// </summary>
    public class Spot {
        /// <summary>
        /// Player that occupies this spots
        /// </summary>
        public IPlayer Player { get; set; }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="player">the player to occupy this spot. can be null</param>
        public Spot(IPlayer player) {
            this.Player = player;
        }

        /// <summary>
        /// TODO kill me
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            string result;
            switch (this.Player?.Color) {
                case Colors.Black: {
                        result = "B";
                        break;
                    }
                case Colors.White: {
                        result = "W";
                        break;
                    }
                case null:
                    result = " ";
                    break;
                default: {
                        result = " ";
                        break;
                    }
            }
            return result;
        }
    }
}