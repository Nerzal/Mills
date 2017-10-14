using System;
using System.Collections.Generic;
using System.Linq;
using Mills.Board.Logic.Contract;
using Mills.Game.Data.Contract;

namespace Mills.Board.Logic
{
  /// <inheritdoc />
  /// <summary>
  /// Implementation of <see cref="T:Mills.ConsoleClient.Board.Analyzer.IPatternRecognizer" />
  /// Finds all rows and mills
  /// </summary>
  public class PatternRecognizer : IPatternRecognizer
  {
    private readonly IRowController _rowController;
    private List<BoardRow> _boardRows;

    /// <inheritdoc />
    public IBoard Board { get; }

    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="board"></param>
    /// <param name="rowController"></param>
    public PatternRecognizer(IBoard board, IRowController rowController)
    {
      this.Board = board;
      this._rowController = rowController;
    }

    public void Initialize()
    {
      this._boardRows = new List<BoardRow>();
      GetSamelevelRows(_boardRows, this.CoordinateCreator);
      GetSamelevelRows(_boardRows, this.InvertedCoordinateCreator);
      GetInterlevelRows(_boardRows, this.CoordinateCreator);
      GetInterlevelRows(_boardRows, this.InvertedCoordinateCreator);
    }

    private Coordinate CoordinateCreator(int level, int xPos, int yPos)
    {
      return new Coordinate(level, xPos, yPos);
    }

    Coordinate InvertedCoordinateCreator(int level, int yPos, int xPos)
    {
      return new Coordinate(level, xPos, yPos);
    }

    internal void GetInterlevelRows(List<BoardRow> result, CreateCoordinateFromPosition magic)
    {
      for (int xBase = 0; xBase < 2; xBase++)
      {
        int x = xBase * 2;
        Coordinate[] spots = new Coordinate[this.Board.LevelCount];
        for (int level = 0; level < this.Board.LevelCount; level++)
        {
          spots[level] = magic(level, x, 1);
        }

        result.Add(new BoardRow(spots));
      }
    }

    internal void GetSamelevelRows(List<BoardRow> result, CreateCoordinateFromPosition magic)
    {
      for (int ybase = 0; ybase < 2; ybase++)
      {
        int y = ybase * 2;
        for (int level = 0; level < this.Board.LevelCount; level++)
        {
          Coordinate[] spots = new Coordinate[this.Board.DimensionCount];

          for (int x = 0; x < this.Board.DimensionCount; x++)
          {
            spots[x] = magic(level, x, y);
          }
          result.Add(new BoardRow(spots));
        }
      }
    }

    /// <inheritdoc />
    public IEnumerable<Row> FindAllMillsFor(IPlayer player)
    {
      return this.FindAllRowsFor(player).Where(row => this._rowController.IsMill(row));
    }

    public IEnumerable<Row> FindAllRowsFor(IPlayer player)
    {
      List<Row> result = new List<Row>();
      foreach (BoardRow boardRow in this._boardRows)
      {
        IPlayer dominatingPlayer = GetDomainatingPlayer(boardRow, out IList<Coordinate> coorinates);
        if (dominatingPlayer == player && coorinates.Count > 1)
        {
          Row row = new Row(player, coorinates);

          result.Add(row);
        }
      }

      return result;
    }

    private IPlayer GetDomainatingPlayer(BoardRow boardRow, out IList<Coordinate> playersCoordinates)
    {
      Dictionary<IPlayer, List<Coordinate>> scoreboard = new Dictionary<IPlayer, List<Coordinate>>();
      foreach (Coordinate boardRowSpot in boardRow.Spots)
      {
        IPlayer player = this.Board.Spots[boardRowSpot.Level][boardRowSpot.X, boardRowSpot.Y].Player;
        if (player == null)
        {
          continue;
        }
        List<Coordinate> playerCoordinates;
        if (scoreboard.ContainsKey(player))
        {
          playerCoordinates = scoreboard[player];
        } else
        {
          playerCoordinates = new List<Coordinate>();
          scoreboard.Add(player, playerCoordinates);
        }
        playerCoordinates.Add(boardRowSpot);
      }
      IPlayer dominator = null;
      playersCoordinates = null;
      int max = int.MinValue;
      foreach (KeyValuePair<IPlayer, List<Coordinate>> keyValuePair in scoreboard)
      {
        if (keyValuePair.Value.Count > max)
        {
          max = keyValuePair.Value.Count;
          playersCoordinates = keyValuePair.Value;
          dominator = keyValuePair.Key;
        }
      }

      return dominator;
    }

    /// <inheritdoc />
    public bool IsCoordinatePartOfMill(Coordinate coordinate, IPlayer player)
    {
      IEnumerable<Row> mills = this.FindAllRowsFor(player);
      foreach (Row mill in mills)
      {
        if (this._rowController.Contains(mill, coordinate))
        {
          return true;
        }
      }
      return false;
    }
  }
}
