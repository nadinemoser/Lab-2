using System;
using System.Drawing;

namespace TheQuest
{
    internal class Sword : Weapon
    {
        public Sword(Game game, Point location) : base(game, location) { }

        public override string Name {  get { return "Sword"; } }

        public override void Attack(Direction direction, Random random)
        {
            if (!DamageEnemy(direction, 10, 3, random))
            {
                int d = (int)direction + 1;
                if (d == 4)
                {
                    d = 0;
                }
                direction = (Direction)d;

                if (!DamageEnemy(direction, 10, 3, random))
                {
                    int e = (int)direction - 2;
                    if (e <0)
                    {
                        if (e < -1)
                        {
                            e = 0;
                        }
                        e = 3;
                    }
                    direction = (Direction)e;
                    DamageEnemy(direction, 10, 3, random);
                }
            }
        }
    }
}
