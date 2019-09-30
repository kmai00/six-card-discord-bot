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
            var value = "";
            if (Value == DefaultValues.Jack)
            {
                value = "J";
            }
            else if (Value == DefaultValues.Queen)
            {
                value = "Q";
            }
            else if (Value == DefaultValues.King)
            {
                value = "K";
            }
            else if (Value == DefaultValues.Ace)
            {
                value = "A";
            }
            else
            {
                value = Value.ToString();
            }

            var suit = "";
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
