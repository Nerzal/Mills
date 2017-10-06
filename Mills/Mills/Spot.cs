using System;

namespace Mills {
  class Spot {
    public IPlayer Player { get; set; }
    /// <summary>
    /// TODO kill me
    /// </summary>
    /// <returns></returns>
    public override string ToString() {
      string result;
      switch (this.Player?.Color) {
        case Colors.Black: {
            result = "B";
            break;
          }
        case Colors.White: {
            result = "W";
            break;
          }
        default: {
            result = " ";
            break;
          }
      }
      return result;
    }
  }
}