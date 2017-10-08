using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mills.ConsoleClient.Board;
using Mills.ConsoleClient.GameController;
using Mills.ConsoleClient.Player;

namespace Mills.Tests {
    [TestClass]
    public class BoardControllerTests : BaseAnalyzerControllerTests {

        [TestMethod]
        public void Set_SetNew_PlayerWhite() {
            //Arrange
            //This part is done by the TestInitialize in the BaseClass
            //Act
            bool result = this.Controller.Set(new Coordinate(0, 0, 0), this.Player);
            //Assert
            Spot spot = this.Board.Spots[0][0, 0];
            Assert.IsNotNull(spot.Player);
            Assert.AreEqual(spot.Player, this.Player);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Set_SetNew_PlayerBlack() {
            //Arrange
            //This part is done by the TestInitialize in the BaseClass
            //Act
            bool result = this.Controller.Set(new Coordinate(0, 0, 0), this.Player2);
            //Assert
            Spot spot = this.Board.Spots[0][0, 0];
            Assert.IsNotNull(spot.Player);
            Assert.AreEqual(spot.Player, this.Player2);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Set_IsFalse_InvalidCoordinate() {
            //Arrange
            //This part is done by the TestInitialize in the BaseClass
            //Act
            bool result = this.Controller.Set(new Coordinate(3, 3, 3), this.Player2);
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Set_IsFalse_InvalidCoordinateMiddleOfField() {
            //Arrange
            //This part is done by the TestInitialize in the BaseClass
            //Act
            bool result = this.Controller.Set(new Coordinate(2, 1, 1), this.Player2);
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