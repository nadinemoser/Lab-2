using System;
using System.Drawing;

namespace TheQuest
{
    internal class BluePotion : Weapon, IPotion
    {
        public override string Name { get { return "Blue Potion"; } }

        public BluePotion(Game game, Point location) : base(game, location){}

        public bool Used { get; private set; }

        public override void Attack(Direction direction, Random random)
        {
            if (!Used)
            {
                _game.IncreasePlayerHealth(5, random);
                Used = true;
            }            
        }
    }
}
