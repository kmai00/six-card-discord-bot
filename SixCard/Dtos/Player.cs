using Discord.WebSocket;
using System.Collections.Generic;

namespace SixCard.Dtos
{
    public class Player
    {

        public Player()
        {
            Cards = new List<Card>();
        }

        public Player(SocketUser user)
        {
            User = user;
            Cards = new List<Card>();
        }

        public SocketUser User { get; private set; }

        public bool IsLeading { get; set; }

        public List<Card> Cards { get; set; }

        public string Name { get { return User.Username; } }
    }
}
