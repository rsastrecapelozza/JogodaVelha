using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogodaVelha
{
    public enum Player { Noone = 0, Jogador2, Jogador1 }

    public struct Square
    {
        public Player Owner { get; }

        public Square(Player owner)
        {
            this.Owner = owner;
        }

        public override string ToString()
        {
            switch (Owner)
            {
                case Player.Jogador1:
                {
                    return "X";
                }
                case Player.Jogador2:
                {
                    return "O";
                }
                default:
                    throw new Exception("Invalid state");
            }
        }
    }
}
