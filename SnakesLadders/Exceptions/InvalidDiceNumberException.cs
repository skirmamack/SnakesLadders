using System;

namespace SnakesLadders.Exceptions
{
    public class InvalidDiceNumberException : Exception
    {
        public InvalidDiceNumberException(int diceNumber) : base("Invalid dice number " + diceNumber)
        {
        }
    }
}