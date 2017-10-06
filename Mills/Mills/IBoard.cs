namespace Mills {
  internal interface IBoard {
    Spot[][,] Spots { get; }
    void Initialize();
  }
}