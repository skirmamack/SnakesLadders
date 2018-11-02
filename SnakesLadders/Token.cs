namespace SnakesLadders
{
    public class Token
    {
        public string PlayerName { get; private set; }

        public Token(string playerName)
        {
            PlayerName = playerName;
        }
    }
}