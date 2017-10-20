using System;
using System.Drawing;

namespace TheQuest
{
    internal class Mace : Weapon
    {
        public Mace(Game game, Point location) : base(game, location) { }

        public override string Name { get { return "Mace"; } }

        public override void Attack(Direction direction, Random random)
        {
            for(int i = 0; i<4; i++)
            {
                if (!DamageEnemy(direction, 10, 6, random))
                {
                    int d = (int)direction + 1;
                    if (d == 4)
                    {
                        d = 0;
                    }
                    direction = (Direction)d;
                }
            }
        }
    }
}
