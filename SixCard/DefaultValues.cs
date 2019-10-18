namespace SixCard
{
    public static class DefaultValues
    {
        public const int NumberOfCardsPerSuit = 13;

        public const int LowestCardValue = 2;
        public const int HighestNumericalCardValue = 10;
        public const int Jack = 11;
        public const int Queen = 12;
        public const int King = 13;
        public const int Ace = 14;

        public const string JackDisplay = "J";
        public const string QueenDisplay = "Q";
        public const string KingDisplay = "K";
        public const string AceDisplay = "A";

        public static string[] NonNumericalValueDisplays = new string[] { JackDisplay, QueenDisplay, KingDisplay, AceDisplay };

        public const char Clubs = 'C';
        public const char Diamonds = 'D';
        public const char Hearts = 'H';
        public const char Spades = 'S';

        public static char[] SuitValues = new char[] { Clubs, Diamonds, Hearts, Spades };
    }
}
