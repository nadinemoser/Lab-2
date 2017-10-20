using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TheQuest
{
    internal class RedPotion : Weapon, IPotion
    {
        public override string Name { get { return "Red Potion"; } }

        public RedPotion(Game game, Point location) : base(game, location){ }

        public bool Used { get; private set; }

        public override void Attack(Direction direction, Random random)
        {
            if (!Used)
            {
                _game.IncreasePlayerHealth(10, random);
                Used = true;
            }    
        }
    }
}
