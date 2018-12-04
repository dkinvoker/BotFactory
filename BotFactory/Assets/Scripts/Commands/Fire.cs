using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Commands
{
    class Fire : SimpleCommand
    {
        public override CommandType Type
        {
            get
            {
                return CommandType.Fire;
            }
        }

        public override string Description
        {
            get
            {
                return "Fires! If weapon is not ready using this command will trigger an error";
            }
        }

        public override CommandError Execute(Tank tank)
        {
            if (tank.IsReadyToFire)
            {
                var position = tank.FirePoint.position;
                var rotation = tank.FirePoint.transform.rotation;
                var bulletObject = tank.Weapon.CreateBulletAtLocation(position, rotation);
                var bullet = bulletObject.GetComponent<Bullet>();
                bullet.Init(tank);

                tank.RemainingReloadTime = tank.Weapon.ReloadTime;

                return null;
            }
            else
            {
                return new CommandError("Weapon cannot fire! You have to wait till reload");
            }
        }
    }
}
