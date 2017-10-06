using System.Collections.Generic;

namespace Mills {
  class Board : IBoard {
    public Spot[][,] Spots { get; }
    private const int LevelCount = 3;
    private const int Dimensions = 3;


    //public Move CurrentMove { get; private set; }

    public Board() {
      this.Spots = new Spot[LevelCount][,];
    }

    public void Initialize() {
      for (int levelIndex = 0; levelIndex < LevelCount; levelIndex++) {
        Spot[,] level = this.Spots[levelIndex] = new Spot[Dimensions, Dimensions];
        for (int xIndex = 0; xIndex < Dimensions; xIndex++) {
          for (int yIndex = 0; yIndex < Dimensions; yIndex++) {
            level[xIndex, yIndex] = new Spot();
          }
        }
      }
    }

    //public void MakeMove(Move move) {
    //  this.CurrentMove = move;
    //}

    //public void RollbackMove() {
    //  this.CurrentMove = null;
    //}

    //public void CommitMove() {
    //  _moveHistory.Push(this.CurrentMove);
    //}
  }

  public interface IHistory {
    void Add(Move move);
  }
}