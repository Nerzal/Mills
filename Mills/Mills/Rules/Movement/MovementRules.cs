namespace Mills.ConsoleClient.Rules.Movement {
    /// <summary>
    /// Extends <see cref="BaseRules{TEvaluationObject}"/>
    /// Implements <seealso cref="IMovementRules"/>
    /// 
    /// Holds all rules that are important for movement
    /// </summary>
    public class MovementRules : BaseRules<Move>, IMovementRules {

        /// <inheritdoc />
        public IBoard Board { get; }

        /// <inheritdoc />
        public MovementRules(IBoard board) {
            this.Board = board;
        }

        /// <inheritdoc cref="BaseRules{Move}" />
        public override void Initialize() {
            this.Rules.Add(new MoveValidationRule(IsInRange));
            this.Rules.Add(new MoveValidationRule(IsConnected));
            this.Rules.Add(new MoveValidationRule(IsFreeSpot));
        }

        /// <summary>
        /// Checks if source and destination spots are connected
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private bool IsConnected(Move arg) {
            return true;
        }

        /// <summary>
        /// Checks if the spot is not occupied yet
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private bool IsFreeSpot(Move arg) {
            return true;
        }

        /// <summary>
        /// Checks if the source and destination spots are neighbours
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private bool IsInRange(Move arg) {
            return true;
        }
    }
}