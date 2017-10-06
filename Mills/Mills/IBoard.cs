namespace Mills {
  public interface IBoard {
    void Initialize();
    void Move(Move mühv);
    Spot[][,] Spots { get; set; }
  }
}