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

        public override string ToString()
        {
            var value = "";
            if (Value == 11)
            {
                value = "Jack";
            }
            else if (Value == 12)
            {
                value = "Queen";
            }
            else if (Value == 13)
            {
                value = "King";
            }
            else if (Value == 14)
            {
                value = "Ace";
            }
            else
            {
                value = Value.ToString();
            }

            return $"{value}-{Suit.ToString()}";
        }
    }
}
