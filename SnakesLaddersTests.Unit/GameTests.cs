using NUnit.Framework;
using SnakesLadders;

namespace SnakesLaddersTests.Unit
{
    [TestFixture]
    public class GameTests
    {
        private Game _game;

        [SetUp]
        public void SetUp()
        {
            _game = new Game();
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
    }
}
