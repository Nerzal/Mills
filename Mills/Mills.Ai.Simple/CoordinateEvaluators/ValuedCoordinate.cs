using Mills.ConsoleClient.Board;

namespace Mills.Ai.Simple.CoordinateEvaluators {
  internal class ValuedCoordinate {
    public Coordinate Coordinate { get; set; }
    public ProtoSpot ProtoSpot { get; set; }

    public decimal Score { get; set; }

    public ValuedCoordinate(Coordinate coordinate, ProtoSpot protoSpot) {
      this.Coordinate = coordinate;
      this.ProtoSpot = protoSpot;
    }
  }
}