using SixCard.Enums;

namespace SixCard.Dtos
{
    public class Card
    {
        // We'll start at 2 as a base
        public Card(int value, Suits suit)
        {
            Value = value;
            Suit = suit;
        }

        public Card(Card card)
        {
            Value = card.Value;
            Suit = card.Suit;
        }

        public int Value;
        public Suits Suit;

        public override bool Equals(object obj)
        {
            if (obj == null || !GetType().Equals(obj.GetType()))
            {
                return false;
            }
        
            var card = (Card)obj;
            return Value == card.Value && Suit == card.Suit;
        }

        public override string ToString()
        {
            var value = string.Empty;
            if (Value == DefaultValues.Jack)
            {
                value = DefaultValues.JackDisplay;
            }
            else if (Value == DefaultValues.Queen)
            {
                value = DefaultValues.QueenDisplay;
            }
            else if (Value == DefaultValues.King)
            {
                value = DefaultValues.KingDisplay;
            }
            else if (Value == DefaultValues.Ace)
            {
                value = DefaultValues.AceDisplay;
            }
            else
            {
                value = Value.ToString();
            }

            var suit = string.Empty;
            switch (Suit)
            {
                case Suits.CLUBS:
                    suit = ":clubs:";
                    break;
                case Suits.DIAMONDS:
                    suit = ":diamonds:";
                    break;
                case Suits.HEARTS:
                    suit = ":hearts:";
                    break;
                case Suits.SPADES:
                    suit = ":spades:";
                    break;
            }

            return $"{value}{suit}";
        }
    }
}
