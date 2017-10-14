using System;
using System.Collections.Generic;
using System.IO;

using Mills.Ai.Simple.CoordinateEvaluators;
using Mills.Board.Logic.Contract;
using Mills.Game.Ai;
using Mills.Game.Contract;
using Mills.Game.Contract.Data;
using Mills.Game.Data.Contract;
using Mills.Rules.Contract;
using Mills.Utils;
using Newtonsoft.Json;

namespace Mills.Ai.Simple {
  public class SimpleAi : AiPlayer {
    private readonly ProtoBoard _protoBoard;
    private readonly MoveEvaluator _setMoveEvaluator;
    private readonly IRandomProvider _random;

    public SimpleAi(IGameController controller, IBoardAnalyzer analyzer, IRandomProvider random, IMillRuleEvaluator millRuleEvaluator) : base(controller, analyzer,millRuleEvaluator) {
      using (Stream resourceStream = GetType().Assembly.GetManifestResourceStream(GetType().Namespace + ".Board.json")) {
        using (StreamReader sr = new StreamReader(resourceStream)) {
          string content = sr.ReadToEnd();
          this._protoBoard = JsonConvert.DeserializeObject<ProtoBoard>(content);
        }
      }

      this._random = random;
      this._setMoveEvaluator = new MoveEvaluator(this.BoardAnalyzer, random, this._protoBoard);
      this._setMoveEvaluator.Initialize();
    }

    protected override Move AnalyseInternal() {
      switch (this.CurrentPhase) {
        case GamePhases.Set:
          break;
        case GamePhases.Draw:
          break;
        case GamePhases.Jump:
          break;
        default:
          throw new ArgumentOutOfRangeException();
      }
      Move move = this._setMoveEvaluator.EvaluateBoard(this.CurrentPhase);
      move.Player = this;
      return move;
    }
  }
}
