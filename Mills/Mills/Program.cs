using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mills {
  class Program {
    static void Main(string[] args) {
      IPlayer player1 = new Player("Olaf");
      IPlayer player2 = new Player("Karl");
      IGameController controller = new GameController();
      controller.NewGame(player1, player2);

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
      //int x = 0;
      //int y = 0;
      //Spot[,] level1 = board.Spots[0];
      //Spot[,] level2 = board.Spots[1];
      //Spot[,] level3 = board.Spots[2];

      //Console.WriteLine($@"{level1[0, 0]}-----{level1[1, 0]}-----{level1[2, 0]}");
      //Console.WriteLine($@"| {level2[0, 0]}---{level2[1, 0]}---{level2[2, 0]} |");
      //Console.WriteLine($@"| | {level3[0, 0]}-{level3[1, 0]}-{level3[2, 0]} | |");
      //Console.WriteLine($@"{level1[0, 1]} {level2[0, 1]} {level3[0, 1]}   {level3[2, 1]} {level2[2, 1]} {level1[2, 1]}");
      //Console.WriteLine($@"| | {level3[0, 2]}-{level3[1, 2]}-{level3[2, 2]} | |");
      //Console.WriteLine($@"| {level2[0, 2]}---{level2[1, 2]}---{level2[2, 2]} |");
      //Console.WriteLine($@"{level1[0, 2]}-----{level1[1, 2]}-----{level1[2, 2]}");
    }
  }

  internal class Player : IPlayer {
    public string Name { get; }
    public Colors Color { get; set; }

    public Player(string name) {
      this.Name = name;
    }
  }

  internal class GameController : IGameController {
    private IPlayer _player1;
    private IPlayer _player2;

    public IPlayer ActivePlayer { get; private set; }

    public int Round { get; private set; }

    public void NewGame(IPlayer player1, IPlayer player2) {
      this._player1 = player1;
      this._player1.Color = Colors.White;
      this._player2 = player2;
      this._player2.Color = Colors.Black;
      this.ActivePlayer = this._player1;
      this.Round = 0;
    }

    public bool DoTurn(Move mühv) {
      if (!ValidateMove(mühv)) {
        return false;
      }
      ApplyMove(mühv);
      this.Round++;
      SetActivePlayer();
      return true;
    }

    private void ApplyMove(Move mühv) {
      throw new NotImplementedException();
    }

    private bool ValidateMove(Move mühv) {
      throw new NotImplementedException();
    }

    private void SetActivePlayer() {
      if (this.Round % 2 == 1) {
        this.ActivePlayer = this._player2;
      }
      else {
        this.ActivePlayer = this._player1;
      }
    }
  }
}

