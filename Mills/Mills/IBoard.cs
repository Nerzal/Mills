namespace Mills.ConsoleClient {
  public interface IBoard {
    void Initialize();
    void Move(Move move);
    Spot[][,] Spots { get; set; }
  }
}