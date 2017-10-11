using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;

using Mills.ConsoleClient.Ai;
using Mills.ConsoleClient.Board;
using Mills.ConsoleClient.Board.Analyzer;
using Mills.ConsoleClient.GameController;

using Newtonsoft.Json;

namespace Mills.Ai.Simple {
  public class SimpleAi : AiPlayer {
    private ProtoBoard _protoBoard;
    private MoveEvaluator _moveEvaluator;
    private IRandomProvider _random;

    public SimpleAi(IGameController controller, IBoardAnalyzer analyzer, IRandomProvider random) : base(controller, analyzer) {
      using (Stream resourceStream = GetType().Assembly.GetManifestResourceStream(GetType().Namespace + ".Board.json")) {
        using (StreamReader sr = new StreamReader(resourceStream)) {
          this._protoBoard = JsonConvert.DeserializeObject<ProtoBoard>(sr.ReadToEnd());
        }
      }

      this._moveEvaluator = new MoveEvaluator(this.BoardAnalyzer, this._protoBoard);
      this._random = random;
    }

    protected override Move AnalyseInternal() {
      this._moveEvaluator.EvaluateBoard();
      throw new System.NotImplementedException();
    }
  }

  class RandomProvider : IRandomProvider {
    private readonly Random _random;

    public RandomProvider() {
      this._random = new Random();
    }

    public int Next(int maxValue) {
      return this._random.Next(maxValue);
    }

    public int Next(int minValue, int maxValue) {
      return this._random.Next(minValue, maxValue);
    }
  }

  public interface IRandomProvider {
    //int Next(int maxValue);
    int Next(int minValue, int maxValue);
  }

  internal class MoveEvaluator {
    private readonly List<SpotEvaluator> _evaluators;
    private readonly IBoardAnalyzer _boardAnalyzer;
    private readonly ProtoBoard _protoBoard;

    public MoveEvaluator(IBoardAnalyzer boardAnalyzer, ProtoBoard protoBoard) {
      this._boardAnalyzer = boardAnalyzer;
      this._protoBoard = protoBoard;
      this._evaluators = new List<SpotEvaluator>();
    }

    public void Initialize() {
      this._evaluators.Add(new FreeSpotEvaluator(this._boardAnalyzer));
    }

    public void EvaluateBoard() {
      ICollection<Coordinate> spots = this._protoBoard.GetAllCoordinates();

      foreach (SpotEvaluator spotEvaluator in this._evaluators) {
        spotEvaluator.Evaluate(spots);
      }
    }
  }

  internal class ProtoBoard {
    [JsonProperty()]
    private readonly ProtoSpot[,,] _spots;

    public ProtoBoard() {
      this._spots = new ProtoSpot[3, 3, 3];
    }

    public ProtoSpot GetCoordinate(int level, int x, int y) {
      return this._spots[level, x, y];
    }

    public ICollection<Coordinate> GetAllCoordinates() {
      IList<Coordinate> coordinates = new List<Coordinate>();
      foreach (ProtoSpot protoSpot in this._spots) {
        if (protoSpot == null) {
          continue;
        }

        coordinates.Add(protoSpot.Coordinate);
      }
      return coordinates;
    }
  }

  public class ProtoSpot {
    public Coordinate Coordinate { get; }
    public int BaseScore { get; }
    public int BaseMovabilityIndex { get; }
  }

  internal sealed class FreeSpotEvaluator : SpotEvaluator {
    private readonly IBoardAnalyzer _boardAnalyzer;

    public FreeSpotEvaluator(IBoardAnalyzer boardAnalyzer) {
      this._boardAnalyzer = boardAnalyzer;
    }

    public override void Evaluate(ICollection<Coordinate> coordinates) {
      ICollection<Coordinate> coordinateToBeRemoved = new List<Coordinate>();
      foreach (Coordinate coordinate in coordinates) {
        if (!this._boardAnalyzer.IsFreeSpot(coordinate)) {
          continue;
        }
        coordinateToBeRemoved.Add(coordinate);
      }

      foreach (Coordinate coordinate in coordinateToBeRemoved) {
        coordinates.Remove(coordinate);
      }
    }
  }

  internal abstract class SpotEvaluator {
    public abstract void Evaluate(ICollection<Coordinate> coordinates);
  }
}
