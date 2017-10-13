using Mills.ConsoleClient.Board;
using Newtonsoft.Json;

namespace Mills.Ai.Simple.CoordinateEvaluators {
  public class ProtoSpot {
    [JsonProperty]
    public Coordinate Coordinate { get; private set; }
    [JsonProperty]
    public int BaseScore { get; private set; }
    [JsonProperty]
    public int BaseMovabilityIndex { get; private set; }
  }
}