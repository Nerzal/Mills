namespace Mills.ConsoleClient {
  /// <summary>
  /// The games board
  /// </summary>
  public interface IBoard {
    /// <summary>
    /// Initializes the board with the default state
    /// </summary>
    void Initialize();
    /// <summary>
    /// Applies a move onto the board
    /// </summary>
    /// <param name="move"></param>
    void Move(Move move);
    /// <summary>
    /// The board itself
    /// </summary>
    Spot[][,] Spots { get; set; }
  }
}