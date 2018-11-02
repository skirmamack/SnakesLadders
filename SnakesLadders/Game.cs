namespace SnakesLadders
{
    public class Game
    {
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

        public int GetTokenSquareNumber()
        {
            return _tokenSquareNumber;
        }
    }
}