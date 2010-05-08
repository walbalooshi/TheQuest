using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TheQuest {
    public class Bat : Enemy {
        public Bat(Game game, Point location, Rectangle boundaries)
            : base(game, location, boundaries, 6) { }

        public override void Move(Random random) {
            //throw new NotImplementedException();
            if (random.Next(1, 2) == 1) {
                Move(FindPlayerDirection(game.PlayerLocation), game.Boundaries);
            } else {
                Move((Direction)random.Next(1, 4), game.Boundaries);
            }
            if (NearPlayer()) {
                
            }
        }
    }
}
