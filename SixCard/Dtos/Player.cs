using System.Collections.Generic;
using System.Text;

namespace SixCard.Dtos
{
    public class Player
    {
        public string Name { get; private set; }

        public List<Card> Cards { get; set; }

        public Player(string name)
        {
            Name = name;
            Cards = new List<Card>();
        }
    }
}
