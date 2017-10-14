using Mills.Game.Data.Contract;

namespace Mills.Board.Logic {
  delegate Coordinate CreateCoordinateFromPosition(int level, int xPos, int yPos);
}