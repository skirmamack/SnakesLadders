using System.Collections.Generic;

namespace SnakesLadders
{
    public class Game
    {
        private const int MaxSquareNumber = 100;

        private int _tokenSquareNumber;
        private Token _token;

        public void AddToken(Token token)
        {
            _token = token;
        }

        public void Start()
        {
            _tokenSquareNumber = 1;
        }

        public void MoveToken(Token token, int diceNumber)
        {
            var newSquareNumber = _tokenSquareNumber + diceNumber;

            if (newSquareNumber > MaxSquareNumber) return;

            _tokenSquareNumber = newSquareNumber;
        }

        public int GetTokenSquareNumber()
        {
            return _tokenSquareNumber;
        }

        public List<Token> GetWinnerTokens()
        {
            var tokens = new List<Token>();

            if (_tokenSquareNumber == MaxSquareNumber)
            {
                tokens.Add(_token);
            }

            return tokens;
        }
    }
}