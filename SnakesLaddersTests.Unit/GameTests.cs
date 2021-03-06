﻿using System;
using Moq;
using NUnit.Framework;
using SnakesLadders;
using SnakesLadders.Dice;

namespace SnakesLaddersTests.Unit
{
    [TestFixture]
    public class GameTests
    {
        private Mock<IDiceNumberValidator> _diceNumberValidator;
        private Game _game;

        [SetUp]
        public void SetUp()
        {
            _diceNumberValidator = new Mock<IDiceNumberValidator>();
            _game = new Game(_diceNumberValidator.Object);
        }

        [Test]
        public void PlayerToken_ShouldBeOnFirstSquare_When_Started()
        {
            //Given the game is started
            //When the token is placed on the board
            var token = new Token("Ski");
            _game.AddToken(token);
            _game.Start();

            //Then the token is on square 1
            var tokenSquareNumber = _game.GetTokenSquareNumber();
            Assert.That(tokenSquareNumber, Is.EqualTo(1));
        }

        [Test]
        public void PlayerToken_ShouldBeAtFourth_When_StatedAndThreeRolled()
        {
            //Given the token is on square 1 (game started)
            var token = new Token("Ski");
            _game.AddToken(token);
            _game.Start();

            //When the token is moved 3 spaces
            _game.MoveToken(token, 3);

            //Then the token is on square 4
            var tokenSquareNumber = _game.GetTokenSquareNumber();
            Assert.That(tokenSquareNumber, Is.EqualTo(4));
        }

        [Test]
        public void PlayerToken_ShouldBeAtEight_When_StatedAndThreeAndFourRolled()
        {
            //Given the token is on square 1 (game started)
            var token = new Token("Ski");
            _game.AddToken(token);
            _game.Start();

            //When the token is moved 3 spaces
            _game.MoveToken(token, 3);

            //(Then the token is on square 4)
            var tokenSquareNumber = _game.GetTokenSquareNumber();
            Assert.That(tokenSquareNumber, Is.EqualTo(4));

            //When the token is moved 4 spaces
            _game.MoveToken(token, 4);

            //Then the token is on square 8
            tokenSquareNumber = _game.GetTokenSquareNumber();
            Assert.That(tokenSquareNumber, Is.EqualTo(8));
        }

        [Test]
        public void Player_CanWin_When_SteppedOnTheLastSquare()
        {
            //starts at 1st
            var token = new Token("Ski");
            _game.AddToken(token);
            _game.Start();

            var winnerTokens = _game.GetWinnerTokens();
            CollectionAssert.IsEmpty(winnerTokens);

            //Given the token is on square 97
            MoveTokenToSquareNumber(token, 97);

            //When the token is moved 3 spaces
            _game.MoveToken(token, 3);

            //Then the token is on square 100
            var tokenSquareNumber = _game.GetTokenSquareNumber();
            Assert.That(tokenSquareNumber, Is.EqualTo(100));

            //And the player has won the game
            winnerTokens = _game.GetWinnerTokens();
            CollectionAssert.Contains(winnerTokens, token);
        }

        [Test]
        public void Player_DidNotWin_When_SteppedOverLastSquare()
        {
            var token = new Token("Ski");
            _game.AddToken(token);
            _game.Start();

            var winnerTokens = _game.GetWinnerTokens();
            CollectionAssert.IsEmpty(winnerTokens);

            //Given the token is on square 97
            MoveTokenToSquareNumber(token, 97);

            //When the token is moved 4 spaces
            _game.MoveToken(token, 4);

            //Then the token is on square 97
            var tokenSquareNumber = _game.GetTokenSquareNumber();
            Assert.That(tokenSquareNumber, Is.EqualTo(97));

            //And the player has not won the game
            winnerTokens = _game.GetWinnerTokens();
            CollectionAssert.IsEmpty(winnerTokens);
        }

        [Test]
        public void MoveToken_ShouldThrow_When_DiceValidatorThrows()
        {
            var diceValidationException = new Exception();

            var token = new Token("Ski");
            _game.AddToken(token);

            _diceNumberValidator
                .Setup(validator => validator.Validate(It.IsAny<int>()))
                .Throws(diceValidationException);

            //Given game is started
            _game.Start();

            //Player requests to move with throwing dice validation
            var exception = Assert.Throws<Exception>(() => _game.MoveToken(token, 3));

            Assert.That(exception, Is.Not.Null);
        }
        protected void MoveTokenToSquareNumber(Token token, int squareNumber)
        {
            while (_game.GetTokenSquareNumber() < squareNumber)
            {
                _game.MoveToken(token, 1);
            }
        }
    }
}
