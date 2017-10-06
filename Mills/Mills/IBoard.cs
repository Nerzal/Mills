namespace Mills {
  internal interface IBoard {
    void Initialize();
    void Move(Move mühv);
    Spot[][,] Spots { get; set; }
  }
}