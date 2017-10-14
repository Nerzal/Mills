using System.Text;
using Mills.Game.Data.Contract;

namespace Mills.Board.Logic {
  public class BoardRow
  {
    public readonly Coordinate[] Spots;

    public BoardRow(Coordinate[] spots)
    {
      Spots = spots;
    }

    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      foreach (Coordinate coordinate in this.Spots)
      {
        sb.Append("{");
        sb.Append(coordinate);
        sb.Append("}");
      }

      return sb.ToString();
    }
  }
}