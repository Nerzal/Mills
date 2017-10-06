using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mills {
  class Program {
    static void Main(string[] args) {
      IBoard board = new Board();
      board.Initialize();
      Draw(board);
      Console.ReadLine();
    }

    /// <summary>
    /// TODO kill me
    /// </summary>
    /// <param name="board"></param>
    static void Draw(IBoard board) {
      int x = 0;
      int y = 0;
      Spot[,] level1 = board.Spots[0];
      Spot[,] level2 = board.Spots[1];
      Spot[,] level3 = board.Spots[2];

      Console.WriteLine($@"{level1[0, 0]}-----{level1[1, 0]}-----{level1[2, 0]}");
      Console.WriteLine($@"| {level2[0, 0]}---{level2[1, 0]}---{level2[2, 0]} |");
      Console.WriteLine($@"| | {level3[0, 0]}-{level3[1, 0]}-{level3[2, 0]} | |");
      Console.WriteLine($@"{level1[0, 1]} {level2[0, 1]} {level3[0, 1]}   {level3[2, 1]} {level2[2, 1]} {level1[2, 1]}");
      Console.WriteLine($@"| | {level3[0, 2]}-{level3[1, 2]}-{level3[2, 2]} | |");
      Console.WriteLine($@"| {level2[0, 2]}---{level2[1, 2]}---{level2[2, 2]} |");
      Console.WriteLine($@"{level1[0, 2]}-----{level1[1, 2]}-----{level1[2, 2]}");
    }
  }

  internal interface IBoard {
    Spot[][,] Spots { get; }
    void Initialize();
  }
}
