using System.Collections.Generic;
using Mills.ConsoleClient.Board;
using Newtonsoft.Json;

namespace Mills.Ai.Simple.CoordinateEvaluators {
  internal class ProtoBoard {
    [JsonProperty]
    public ProtoSpot[,,] Spots { get; private set; }

    public ProtoBoard() {
      this.Spots = new ProtoSpot[3, 3, 3];
    }

    public ProtoSpot GetCoordinate(int level, int x, int y) {
      return this.Spots[level, x, y];
    }

    public ICollection<Coordinate> GetAllCoordinates() {
      IList<Coordinate> coordinates = new List<Coordinate>();
      foreach (ProtoSpot protoSpot in this.Spots) {
        if (protoSpot == null) {
          continue;
        }

        coordinates.Add(protoSpot.Coordinate);
      }
      return coordinates;
    }
  }
}