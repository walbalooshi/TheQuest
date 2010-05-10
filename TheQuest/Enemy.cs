using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TheQuest {
    public abstract class Enemy : Mover, ISprite {
        private const int NearPlayerDistance = 25;
        private int hitPoints;

        public int HitPoints { get { return hitPoints; } }
        public Size SpriteSize { get; private set; }

        public bool Dead {
            get {
                if (hitPoints <= 0) return true;
                else return false;
            }
        }

        public Enemy(Game game, Point location, int hitPoints, Size spriteSize)
                : base(game, location) {
            this.hitPoints = hitPoints;
            SpriteSize = spriteSize;
        }

        public abstract void Move(Random random);

        public void Hit(int maxDamage, Random random) {
            hitPoints -= random.Next(1, maxDamage);
        }

        protected bool NearPlayer() {
            return Nearby(game.PlayerLocation, NearPlayerDistance);
        }

        protected Direction FindPlayerDirection(Point playerLocation) {
            Direction directionToMove;
            if (playerLocation.X > location.X + 10) directionToMove = Direction.Right;
            else if (playerLocation.X < location.X - 10) directionToMove = Direction.Left;
            else if (playerLocation.Y < location.Y - 10) directionToMove = Direction.Up;
            else directionToMove = Direction.Down;

            return directionToMove;
        }
    }
}
