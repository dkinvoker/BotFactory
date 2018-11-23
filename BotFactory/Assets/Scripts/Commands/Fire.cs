﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Commands
{
    [Description("Fires! If weapon is not ready using this command will trigger an error")]
    class Fire : SimpleCommand
    {
        public override CommandType Type
        {
            get
            {
                return CommandType.Fire;
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