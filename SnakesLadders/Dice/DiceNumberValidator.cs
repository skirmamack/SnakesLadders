using SnakesLadders.Exceptions;

namespace SnakesLadders.Dice
{
    public class DiceNumberValidator : IDiceNumberValidator
    {
        public void Validate(int diceNumber)
        {
            if (diceNumber < 1 || diceNumber > 6)
            {
                throw new InvalidDiceNumberException(diceNumber);
            }
        }
    }
}