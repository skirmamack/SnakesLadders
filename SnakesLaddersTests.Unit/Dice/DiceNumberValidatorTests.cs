using NUnit.Framework;
using SnakesLadders.Dice;
using SnakesLadders.Exceptions;

namespace SnakesLaddersTests.Unit.Dice
{
    [TestFixture]
    public class DiceNumberValidatorTests
    {
        private DiceNumberValidator _diceNumberValidator;

        [SetUp]
        public void SetUp()
        {
            _diceNumberValidator = new DiceNumberValidator();
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        public void Validate_ShouldNotThrow_When_ValidDiceNumber(int diceNumber)
        {
            _diceNumberValidator.Validate(diceNumber);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(7)]
        [TestCase(100)]
        public void Validate_ShouldThrow_When_InvalidiceNumber(int diceNumber)
        {
            var exception = Assert.Throws<InvalidDiceNumberException>(() => _diceNumberValidator.Validate(diceNumber));

            Assert.That(exception, Is.Not.Null);
            Assert.That(exception.Message, Is.EqualTo("Invalid dice number " + diceNumber));
        }
    }
}
