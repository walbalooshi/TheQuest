using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TheQuest {
    public class Sword : Weapon {
        public Sword(Game game, Point location)
            : base(game, location) { }

        public override string Name { get { return "Sword"; } }
        public override void Attack(Direction direction, Random random) {
            if(!DamageEnemy(direction, 10, 3, random)) {
                if(!DamageEnemy(ClockwiseDirection(direction), 10, 3, random)) {
                    DamageEnemy(CounterClockWiseDirection(direction), 10, 3, random);
                }
            }            
        }
    }
}
