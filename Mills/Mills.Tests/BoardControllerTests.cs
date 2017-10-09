using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mills.ConsoleClient.Board;
using Mills.ConsoleClient.GameController;
using Mills.ConsoleClient.Player;

namespace Mills.Tests {
  [TestClass]
  public class BoardControllerTests : BaseTests {

    [TestMethod]
    public void Set_SetNew_PlayerWhite() {
      //Arrange
      Coordinate coordinate = new Coordinate(0, 0, 0);
      //Act
      bool result = this.Controller.Set(coordinate, this.Player);
      //Assert
      Spot spot = this.Board.Spots[0][0, 0];
      Assert.IsNotNull(spot.Player);
      Assert.AreEqual(spot.Player, this.Player);
      Assert.IsTrue(result);
    }

    [TestMethod]
    public void Set_SetNew_PlayerBlack() {
      //Arrange
      Coordinate coordinate = new Coordinate(0, 0, 0);
      //Act
      bool result = this.Controller.Set(coordinate, this.Player2);
      //Assert
      Spot spot = this.Board.Spots[0][0, 0];
      Assert.IsNotNull(spot.Player);
      Assert.AreEqual(spot.Player, this.Player2);
      Assert.IsTrue(result);
    }

    [TestMethod]
    public void Set_IsFalse_InvalidCoordinate() {
      //Arrange
      Coordinate coordinate = new Coordinate(3, 3, 3);
      //Act
      bool result = this.Controller.Set(coordinate, this.Player2);
      //Assert
      Assert.IsFalse(result);
    }

    [TestMethod]
    public void Set_IsFalse_InvalidCoordinateMiddleOfField() {
      //Arrange
      Coordinate coordinate = new Coordinate(2, 1, 1);
      //Act
      bool result = this.Controller.Set(coordinate, this.Player2);
      //Assert
      Assert.IsFalse(result);
    }

    [TestMethod]
    public void Unset_IsTrue_OccupiedByEnemy() {
      //Arrange
      Coordinate coordinate = new Coordinate(2, 1, 2);
      //Act
      this.Controller.Set(coordinate, this.Player);
      bool result = this.Controller.Unset(coordinate, this.Player2);
      //Assert
      Assert.IsTrue(result);
    }

    [TestMethod]
    public void Unset_IsFalse_OccupiedBySelf() {
      //Arrange
      Coordinate coordinate = new Coordinate(2, 1, 1);
      //Act
      this.Controller.Set(coordinate, this.Player);
      bool result = this.Controller.Unset(coordinate, this.Player);
      //Assert
      Assert.IsFalse(result);
    }

    [TestMethod]
    public void Unset_IsFalse_OccupiedByNone() {
      //Arrange
      Coordinate coordinate = new Coordinate(2, 1, 1);
      //Act
      bool result = this.Controller.Unset(coordinate, this.Player);
      //Assert
      Assert.IsFalse(result);
    }

    [TestMethod]
    public void Move_IsTrue_ValidMoveFor1Field() {
      //Arrange
      Coordinate source = new Coordinate(0, 0, 0);
      Coordinate destination = new Coordinate(0, 1, 0);
      this.Controller.Set(source, this.Player);
      Move move = new Move(source, destination, this.Player);
      //Act
      bool result = this.Controller.Move(move);
      //Assert
      Assert.IsTrue(result);
      IPlayer sourceOccupier = this.Analyzer.GetOccupier(source);
      IPlayer destinationOccupier = this.Analyzer.GetOccupier(destination);
      Assert.IsNull(sourceOccupier);
      Assert.AreEqual(this.Player, destinationOccupier);
    }

    [TestMethod]
    public void Move_IsTrue_InvalidMoveFor2Fields() {
      //Arrange
      Coordinate source = new Coordinate(0, 0, 0);
      Coordinate destination = new Coordinate(0, 2, 0);
      this.Controller.Set(source, this.Player);
      Move move = new Move(source, destination, this.Player);
      //Act
      bool result = this.Controller.Move(move);
      //Assert
      Assert.IsFalse(result);
      IPlayer sourceOccupier = this.Analyzer.GetOccupier(source);
      Assert.AreEqual(this.Player, sourceOccupier);
    }

    [TestMethod]
    public void Move_IsTrue_InvalidMoveForNotConnectedFields120To020() {
      //Arrange
      Coordinate source = new Coordinate(1, 2, 0);
      Coordinate destination = new Coordinate(0, 2, 0);
      this.Controller.Set(source, this.Player);
      Move move = new Move(source, destination, this.Player);
      //Act
      bool result = this.Controller.Move(move);
      //Assert
      Assert.IsFalse(result);
      IPlayer sourceOccupier = this.Analyzer.GetOccupier(source);
      Assert.AreEqual(this.Player, sourceOccupier);
    }

    [TestMethod]
    public void Jump_IsTrue_120To020() {
      //Arrange
      Coordinate source = new Coordinate(1, 2, 0);
      Coordinate destination = new Coordinate(0, 2, 0);
      this.Controller.Set(source, this.Player);
      Move move = new Move(source, destination, this.Player);
      //Act
      bool result = this.Controller.Jump(move);
      //Assert
      Assert.IsTrue(result);
      IPlayer sourceOccupier = this.Analyzer.GetOccupier(source);
      Assert.IsNull(sourceOccupier);
      IPlayer destinationOccupier = this.Analyzer.GetOccupier(destination);
      Assert.AreEqual(this.Player, destinationOccupier);
    }

    [TestMethod]
    public void Jump_IsFalse_120To020AllreadyOccupied() {
      //Arrange
      Coordinate source = new Coordinate(1, 2, 0);
      Coordinate destination = new Coordinate(0, 2, 0);
      this.Controller.Set(source, this.Player);
      this.Controller.Set(destination, this.Player2);
      Move move = new Move(source, destination, this.Player);
      //Act
      bool result = this.Controller.Jump(move);
      //Assert
      Assert.IsFalse(result);
      IPlayer sourceOccupier = this.Analyzer.GetOccupier(source);
      Assert.AreEqual(this.Player, sourceOccupier);
      IPlayer destinationOccupier = this.Analyzer.GetOccupier(destination);
      Assert.AreEqual(this.Player2, destinationOccupier);
    }
  }
}