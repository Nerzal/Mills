using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mills.ConsoleClient.Board;
using Mills.ConsoleClient.Board.Analyzer;

namespace Mills.Tests {
  [TestClass]
  public class PatternRecognizerTests : BaseTests {
    [TestMethod]
    public void FindAllRowsFor_2_PlayerOne2Rows() {
      //Arrange
      IRowController rowController = new RowController();
      IPatternRecognizer recognizer = new PatternRecognizer(this.Board, rowController);
      //Create row 1
      Coordinate row1Coordinate1 = new Coordinate(0, 0, 0);
      this.Controller.Set(row1Coordinate1, this.Player);
      Coordinate row1Coordinate2 = new Coordinate(0, 1, 0);
      this.Controller.Set(row1Coordinate2, this.Player);
      //Create row 2
      Coordinate row2Coordinate1 = new Coordinate(2, 2, 0);
      this.Controller.Set(row2Coordinate1, this.Player);
      Coordinate row2Coordinate2 = new Coordinate(2, 2, 1);
      this.Controller.Set(row2Coordinate2, this.Player);
      Coordinate row2Coordinate3 = new Coordinate(2, 2, 2);
      this.Controller.Set(row2Coordinate3, this.Player);
      //Act
      IEnumerable<Row> player1Rows = recognizer.FindAllRowsFor(this.Player);
      //Assert
      Assert.AreEqual(2, player1Rows.Count());

      List<Row> player1RowsList = player1Rows.ToList();
      Row firstRow = player1RowsList[0];
      Assert.AreEqual(row1Coordinate1, firstRow.First);
      Assert.AreEqual(row1Coordinate2, firstRow.Second);
      Row secondRow = player1RowsList[1];
      Assert.AreEqual(row2Coordinate1, secondRow.First);
      Assert.AreEqual(row2Coordinate2, secondRow.Second);
      Assert.AreEqual(row2Coordinate3, secondRow.Third);
    }

    [TestMethod]
    public void FindAllMillsFor_000To001To002_PlayerOne() {
      //Arrange
      IRowController rowController = new RowController();
      IPatternRecognizer recognizer = new PatternRecognizer(this.Board, rowController);
      Coordinate row2Coordinate1 = new Coordinate(0, 0, 0);
      this.Controller.Set(row2Coordinate1, this.Player);
      Coordinate row2Coordinate2 = new Coordinate(0, 0, 1);
      this.Controller.Set(row2Coordinate2, this.Player);
      Coordinate row2Coordinate3 = new Coordinate(0, 0, 2);
      this.Controller.Set(row2Coordinate3, this.Player);
      //Act
      IEnumerable<Row> player1Rows = recognizer.FindAllRowsFor(this.Player);
      //Assert
      Assert.AreEqual(1, player1Rows.Count());

      Row row = player1Rows.FirstOrDefault();
      Assert.AreEqual(row2Coordinate1, row.First);
      Assert.AreEqual(row2Coordinate2, row.Second);
      Assert.AreEqual(row2Coordinate3, row.Third);
    }

    
    [TestMethod]
    public void FindAllMillsFor_010To110To210_PlayerOne() {
      //Arrange
      IRowController rowController = new RowController();
      IPatternRecognizer recognizer = new PatternRecognizer(this.Board, rowController);
      Coordinate row2Coordinate1 = new Coordinate(0, 1, 0);
      this.Controller.Set(row2Coordinate1, this.Player);
      Coordinate row2Coordinate2 = new Coordinate(1, 1, 0);
      this.Controller.Set(row2Coordinate2, this.Player);
      Coordinate row2Coordinate3 = new Coordinate(2, 1, 0);
      this.Controller.Set(row2Coordinate3, this.Player);
      //Act
      IEnumerable<Row> player1Rows = recognizer.FindAllRowsFor(this.Player);
      //Assert
      Assert.AreEqual(1, player1Rows.Count());

      Row row = player1Rows.FirstOrDefault();
      Assert.AreEqual(row2Coordinate1, row.First);
      Assert.AreEqual(row2Coordinate2, row.Second);
      Assert.AreEqual(row2Coordinate3, row.Third);
    }

    [TestMethod]
    public void FindAllMillsFor_020To021To022_PlayerOne() {
      //Arrange
      IRowController rowController = new RowController();
      IPatternRecognizer recognizer = new PatternRecognizer(this.Board, rowController);
      Coordinate row2Coordinate1 = new Coordinate(0, 2, 0);
      this.Controller.Set(row2Coordinate1, this.Player);
      Coordinate row2Coordinate2 = new Coordinate(0, 2, 1);
      this.Controller.Set(row2Coordinate2, this.Player);
      Coordinate row2Coordinate3 = new Coordinate(0, 2, 2);
      this.Controller.Set(row2Coordinate3, this.Player);
      //Act
      IEnumerable<Row> player1Rows = recognizer.FindAllRowsFor(this.Player);
      //Assert
      Assert.AreEqual(1, player1Rows.Count());

      Row row = player1Rows.FirstOrDefault();
      Assert.AreEqual(row2Coordinate1, row.First);
      Assert.AreEqual(row2Coordinate2, row.Second);
      Assert.AreEqual(row2Coordinate3, row.Third);
    }

    
    [TestMethod]
    public void FindAllMillsFor_100To101To102_PlayerOne() {
      //Arrange
      IRowController rowController = new RowController();
      IPatternRecognizer recognizer = new PatternRecognizer(this.Board, rowController);
      Coordinate row2Coordinate1 = new Coordinate(1, 0, 0);
      this.Controller.Set(row2Coordinate1, this.Player);
      Coordinate row2Coordinate2 = new Coordinate(1, 0, 1);
      this.Controller.Set(row2Coordinate2, this.Player);
      Coordinate row2Coordinate3 = new Coordinate(1, 0, 2);
      this.Controller.Set(row2Coordinate3, this.Player);
      //Act
      IEnumerable<Row> player1Rows = recognizer.FindAllRowsFor(this.Player);
      //Assert
      Assert.AreEqual(1, player1Rows.Count());

      Row row = player1Rows.FirstOrDefault();
      Assert.AreEqual(row2Coordinate1, row.First);
      Assert.AreEqual(row2Coordinate2, row.Second);
      Assert.AreEqual(row2Coordinate3, row.Third);
    }

    [TestMethod]
    public void FindAllMillsFor_200To201To202_PlayerOne() {
      //Arrange
      IRowController rowController = new RowController();
      IPatternRecognizer recognizer = new PatternRecognizer(this.Board, rowController);
      Coordinate row2Coordinate1 = new Coordinate(2, 0, 0);
      this.Controller.Set(row2Coordinate1, this.Player);
      Coordinate row2Coordinate2 = new Coordinate(2, 0, 1);
      this.Controller.Set(row2Coordinate2, this.Player);
      Coordinate row2Coordinate3 = new Coordinate(2, 0, 2);
      this.Controller.Set(row2Coordinate3, this.Player);
      //Act
      IEnumerable<Row> player1Rows = recognizer.FindAllRowsFor(this.Player);
      //Assert
      Assert.AreEqual(1, player1Rows.Count());

      Row row = player1Rows.FirstOrDefault();
      Assert.AreEqual(row2Coordinate1, row.First);
      Assert.AreEqual(row2Coordinate2, row.Second);
      Assert.AreEqual(row2Coordinate3, row.Third);
    }

    [TestMethod]
    public void FindAllMillsFor_220To221To222_PlayerOne() {
      //Arrange
      IRowController rowController = new RowController();
      IPatternRecognizer recognizer = new PatternRecognizer(this.Board, rowController);
      Coordinate row2Coordinate1 = new Coordinate(2, 2, 0);
      this.Controller.Set(row2Coordinate1, this.Player);
      Coordinate row2Coordinate2 = new Coordinate(2, 2, 1);
      this.Controller.Set(row2Coordinate2, this.Player);
      Coordinate row2Coordinate3 = new Coordinate(2, 2, 2);
      this.Controller.Set(row2Coordinate3, this.Player);
      //Act
      IEnumerable<Row> player1Rows = recognizer.FindAllRowsFor(this.Player);
      //Assert
      Assert.AreEqual(1, player1Rows.Count());

      Row row = player1Rows.FirstOrDefault();
      Assert.AreEqual(row2Coordinate1, row.First);
      Assert.AreEqual(row2Coordinate2, row.Second);
      Assert.AreEqual(row2Coordinate3, row.Third);
    }

    [TestMethod]
    public void FindAllMillsFor_120To121To122_PlayerOne() {
      //Arrange
      IRowController rowController = new RowController();
      IPatternRecognizer recognizer = new PatternRecognizer(this.Board, rowController);
      Coordinate row2Coordinate1 = new Coordinate(1, 2, 0);
      this.Controller.Set(row2Coordinate1, this.Player);
      Coordinate row2Coordinate2 = new Coordinate(1, 2, 1);
      this.Controller.Set(row2Coordinate2, this.Player);
      Coordinate row2Coordinate3 = new Coordinate(1, 2, 2);
      this.Controller.Set(row2Coordinate3, this.Player);
      //Act
      IEnumerable<Row> player1Rows = recognizer.FindAllRowsFor(this.Player);
      //Assert
      Assert.AreEqual(1, player1Rows.Count());

      Row row = player1Rows.FirstOrDefault();
      Assert.AreEqual(row2Coordinate1, row.First);
      Assert.AreEqual(row2Coordinate2, row.Second);
      Assert.AreEqual(row2Coordinate3, row.Third);
    }
    
    [TestMethod]
    public void FindAllMillsFor_000To010To020_PlayerOne() {
      //Arrange
      IRowController rowController = new RowController();
      IPatternRecognizer recognizer = new PatternRecognizer(this.Board, rowController);
      Coordinate row2Coordinate1 = new Coordinate(0, 0, 0);
      this.Controller.Set(row2Coordinate1, this.Player);
      Coordinate row2Coordinate2 = new Coordinate(0, 1, 0);
      this.Controller.Set(row2Coordinate2, this.Player);
      Coordinate row2Coordinate3 = new Coordinate(0, 2, 0);
      this.Controller.Set(row2Coordinate3, this.Player);
      //Act
      IEnumerable<Row> player1Rows = recognizer.FindAllRowsFor(this.Player);
      //Assert
      Assert.AreEqual(1, player1Rows.Count());

      Row row = player1Rows.FirstOrDefault();
      Assert.AreEqual(row2Coordinate1, row.First);
      Assert.AreEqual(row2Coordinate2, row.Second);
      Assert.AreEqual(row2Coordinate3, row.Third);
    }

    [TestMethod]
    public void FindAllMillsFor_001To101To102_PlayerOne() {
      //Arrange
      IRowController rowController = new RowController();
      IPatternRecognizer recognizer = new PatternRecognizer(this.Board, rowController);
      Coordinate row2Coordinate1 = new Coordinate(0, 0, 1);
      this.Controller.Set(row2Coordinate1, this.Player);
      Coordinate row2Coordinate2 = new Coordinate(1, 0, 1);
      this.Controller.Set(row2Coordinate2, this.Player);
      Coordinate row2Coordinate3 = new Coordinate(2, 0, 1);
      this.Controller.Set(row2Coordinate3, this.Player);
      //Act
      IEnumerable<Row> player1Rows = recognizer.FindAllRowsFor(this.Player);
      //Assert
      Assert.AreEqual(1, player1Rows.Count());

      Row row = player1Rows.FirstOrDefault();
      Assert.AreEqual(row2Coordinate1, row.First);
      Assert.AreEqual(row2Coordinate2, row.Second);
      Assert.AreEqual(row2Coordinate3, row.Third);
    }

    
    [TestMethod]
    public void FindAllMillsFor_002To012To022_PlayerOne() {
      //Arrange
      IRowController rowController = new RowController();
      IPatternRecognizer recognizer = new PatternRecognizer(this.Board, rowController);
      Coordinate row2Coordinate1 = new Coordinate(0, 0, 2);
      this.Controller.Set(row2Coordinate1, this.Player);
      Coordinate row2Coordinate2 = new Coordinate(0, 1, 2);
      this.Controller.Set(row2Coordinate2, this.Player);
      Coordinate row2Coordinate3 = new Coordinate(0, 2, 2);
      this.Controller.Set(row2Coordinate3, this.Player);
      //Act
      IEnumerable<Row> player1Rows = recognizer.FindAllRowsFor(this.Player);
      //Assert
      Assert.AreEqual(1, player1Rows.Count());

      Row row = player1Rows.FirstOrDefault();
      Assert.AreEqual(row2Coordinate1, row.First);
      Assert.AreEqual(row2Coordinate2, row.Second);
      Assert.AreEqual(row2Coordinate3, row.Third);
    }

    [TestMethod]
    public void FindAllMillsFor_100To110To120_PlayerOne() {
      //Arrange
      IRowController rowController = new RowController();
      IPatternRecognizer recognizer = new PatternRecognizer(this.Board, rowController);
      Coordinate row2Coordinate1 = new Coordinate(1, 0, 0);
      this.Controller.Set(row2Coordinate1, this.Player);
      Coordinate row2Coordinate2 = new Coordinate(1, 1, 0);
      this.Controller.Set(row2Coordinate2, this.Player);
      Coordinate row2Coordinate3 = new Coordinate(1, 2, 0);
      this.Controller.Set(row2Coordinate3, this.Player);

      //Act
      IEnumerable<Row> player1Rows = recognizer.FindAllRowsFor(this.Player);

      //Assert
      Assert.AreEqual(1, player1Rows.Count());

      Row row = player1Rows.FirstOrDefault();
      Assert.AreEqual(row2Coordinate1, row.First);
      Assert.AreEqual(row2Coordinate2, row.Second);
      Assert.AreEqual(row2Coordinate3, row.Third);
    }

    [TestMethod]
    public void FindAllMillsFor_200To210To220_PlayerOne() {
      //Arrange
      IRowController rowController = new RowController();
      IPatternRecognizer recognizer = new PatternRecognizer(this.Board, rowController);
      Coordinate row2Coordinate1 = new Coordinate(2, 0, 0);
      this.Controller.Set(row2Coordinate1, this.Player);
      Coordinate row2Coordinate2 = new Coordinate(2, 1, 0);
      this.Controller.Set(row2Coordinate2, this.Player);
      Coordinate row2Coordinate3 = new Coordinate(2, 2, 0);
      this.Controller.Set(row2Coordinate3, this.Player);

      //Act
      IEnumerable<Row> player1Rows = recognizer.FindAllRowsFor(this.Player);

      //Assert
      Assert.AreEqual(1, player1Rows.Count());

      Row row = player1Rows.FirstOrDefault();
      Assert.AreEqual(row2Coordinate1, row.First);
      Assert.AreEqual(row2Coordinate2, row.Second);
      Assert.AreEqual(row2Coordinate3, row.Third);
    }
    
    [TestMethod]
    public void FindAllMillsFor_221To121To021_PlayerOne() {
      //Arrange
      IRowController rowController = new RowController();
      IPatternRecognizer recognizer = new PatternRecognizer(this.Board, rowController);
      Coordinate row2Coordinate1 = new Coordinate(2, 2, 1);
      this.Controller.Set(row2Coordinate1, this.Player);
      Coordinate row2Coordinate2 = new Coordinate(1, 2, 1);
      this.Controller.Set(row2Coordinate2, this.Player);
      Coordinate row2Coordinate3 = new Coordinate(0, 2, 1);
      this.Controller.Set(row2Coordinate3, this.Player);

      //Act
      IEnumerable<Row> player1Rows = recognizer.FindAllRowsFor(this.Player);

      //Assert
      Assert.AreEqual(1, player1Rows.Count());

      Row row = player1Rows.FirstOrDefault();
      Assert.AreEqual(row2Coordinate1, row.First);
      Assert.AreEqual(row2Coordinate2, row.Second);
      Assert.AreEqual(row2Coordinate3, row.Third);
    }

    
    [TestMethod]
    public void FindAllMillsFor_202To212To222_PlayerOne() {
      //Arrange
      IRowController rowController = new RowController();
      IPatternRecognizer recognizer = new PatternRecognizer(this.Board, rowController);
      Coordinate row2Coordinate1 = new Coordinate(2, 0, 2);
      this.Controller.Set(row2Coordinate1, this.Player);
      Coordinate row2Coordinate2 = new Coordinate(2, 1, 2);
      this.Controller.Set(row2Coordinate2, this.Player);
      Coordinate row2Coordinate3 = new Coordinate(2, 2, 2);
      this.Controller.Set(row2Coordinate3, this.Player);

      //Act
      IEnumerable<Row> player1Rows = recognizer.FindAllRowsFor(this.Player);

      //Assert
      Assert.AreEqual(1, player1Rows.Count());

      Row row = player1Rows.FirstOrDefault();
      Assert.AreEqual(row2Coordinate1, row.First);
      Assert.AreEqual(row2Coordinate2, row.Second);
      Assert.AreEqual(row2Coordinate3, row.Third);
    }
  }
}