using System;
using System.Collections.Generic;
using System.Drawing;

namespace TheQuest
{
    internal class Player : Mover
    {
        private Weapon _equippedWeapon;
        public int HitPoints { get; private set; }
        private List<Weapon> _inventory = new List<Weapon>();
        public IEnumerable<string> Weapons
        {
            get
            {
                List<string> names = new List<string>();
                foreach (Weapon weapon in _inventory)
                    names.Add(weapon.Name);
                return names;
            }
        }

        public Player(Game game, Point location) : base(game, location)
        {
            HitPoints = 10;
        }

        public void RemoveWeapon(bool hasBlueToRemove)
        {
            List<Weapon> tmp = new List<Weapon>();
            tmp.AddRange(_inventory);

            foreach(Weapon weapon in _inventory)
            {
                if (hasBlueToRemove)
                {
                    if(weapon is BluePotion)
                    {
                        tmp.Remove(weapon);
                    }
                }
                else
                {
                    if(weapon is RedPotion)
                    {
                        tmp.Remove(weapon);
                    }
                }
            }
            _inventory = tmp;
        }

        public void Hit(int maxDamage, Random random)
        {
            HitPoints -= random.Next(1, maxDamage);
        }

        public void IncreaseHealth(int health, Random random)
        {
            HitPoints += random.Next(1, health);
        }

        public void Equip(string weaponName)
        {
            foreach (Weapon weapon in _inventory)
            {
                if (weapon.Name == weaponName)
                    _equippedWeapon = weapon;
            }
        }

        public void Move(Direction direction)
        {
            base._location = Move(direction, _game.Boundaries);
            if (!_game.WeaponInRoom.PickedUp)
            {
                if(Math.Abs(_location.X - _game.WeaponInRoom.Location.X) < 10 && Math.Abs(_location.Y - _game.WeaponInRoom.Location.Y) < 10)
                {
                    _inventory.Add(_game.WeaponInRoom);
                    _game.WeaponInRoom.PickUpWeaopon();
                    if (_inventory.Count == 1)
                        _equippedWeapon = _game.WeaponInRoom;
                }
            }
        }

        public void Attack(Direction direction, Random random)
        {
            if (_equippedWeapon != null)
            {
                _equippedWeapon.Attack(direction, random);
                if (_equippedWeapon is IPotion)
                    _equippedWeapon = null;
            }
        }
    }
}
