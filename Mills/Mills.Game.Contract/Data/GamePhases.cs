namespace Mills.Game.Contract.Data {
    /// <summary>
    /// Used to determine and set the active gamephase
    /// </summary>
    public enum GamePhases {
        /// <summary>
        /// The first phase, where both players set their stones
        /// </summary>
        Set,
        /// <summary>
        /// The second phase, where both players move their stones
        /// </summary>
        Draw,
        /// <summary>
        /// The third phase, where one or both players can jump
        /// </summary>
        Jump,
    }
}