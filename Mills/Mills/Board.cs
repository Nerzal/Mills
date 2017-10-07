﻿namespace Mills.ConsoleClient {
  class Board : IBoard {
    public Spot[][,] Spots { get; set; }
    private const int LevelCount = 3;
    private const int Dimensions = 3;


    //public Move CurrentMove { get; private set; }

    public Board() {
      this.Spots = new Spot[LevelCount][,];
    }

    public void Move(Move move) {
      if (!move.Source.HasValue) {
        this.Spots[move.Destination.Level][move.Destination.X, move.Destination.Y] = new Spot(move.Player);
      }
    }

    public void Initialize() {
      for (int levelIndex = 0; levelIndex < LevelCount; levelIndex++) {
        Spot[,] level = this.Spots[levelIndex] = new Spot[Dimensions, Dimensions];
        for (int xIndex = 0; xIndex < Dimensions; xIndex++) {
          for (int yIndex = 0; yIndex < Dimensions; yIndex++) {
            level[xIndex, yIndex] = new Spot(null);
          }
        }
      }
    }

  }
}