using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Parts.Weapons
{
    class BasicWeapon : Weapon
    {
        public BasicWeapon()
        {
            Damage = 10;
            BulletSpeed = 4;
            ReloadTime = 4;
        }
    }
}
