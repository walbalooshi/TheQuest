using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TheQuest {
    public abstract class Weapon : Mover {        
        private bool pickedUp;
        public bool PickedUp { get { return pickedUp; } }

        public Weapon(Game game, Point location) 
                : base(game, location) {
            pickedUp = false;
        }

        public void PickUpWeapon() {
            pickedUp = true;
        }

        public abstract string Name { get; }
        public abstract void Attack(Direction direction, Random random);

        private bool Nearby(Point initialLocation, Point targetLocation, int distance){
            if (Math.Abs(initialLocation.X - targetLocation.X) < distance &&
                Math.Abs(initialLocation.Y - targetLocation.Y) < distance) {
                return true;
            } else {
                return false;
            }
        }

        protected bool DamageEnemy(Direction direction, int radius, int damage,Random random) {
            Point target = game.PlayerLocation;
            for (int distance = 0; distance < radius; distance++) {
                foreach (Enemy enemy in game.Enemies) {
                    if(Nearby(enemy.Location, target, radius)){
                        enemy.Hit(damage, random);
                        return true;
                    }
                }
                target = Move(direction, game.Boundaries);
            }
            return false;
        }

        protected Direction ClockwiseDirection(Direction direction) {
            Direction clockWiseDirection;

            switch (direction) {
                case Direction.Up:
                    clockWiseDirection = Direction.Right;
                    break;
                case Direction.Right:
                    clockWiseDirection = Direction.Down;
                    break;
                case Direction.Down:
                    clockWiseDirection = Direction.Left;
                    break;
                case Direction.Left:
                    clockWiseDirection = Direction.Up;
                    break;
            }

            return clockWiseDirection;
        }

        protected Direction CounterClockWiseDirection(Direction direction) {
            Direction counterClockWiseDirection;

            switch (direction) {
                case Direction.Up:
                    counterClockWiseDirection = Direction.Left;
                    break;
                case Direction.Right:
                    counterClockWiseDirection = Direction.Up;
                    break;
                case Direction.Down:
                    counterClockWiseDirection = Direction.Right;
                    break;
                case Direction.Left:
                    counterClockWiseDirection = Direction.Down;
                    break;
            }

            return counterClockWiseDirection;
        }
    }
}
