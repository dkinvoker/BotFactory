using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Commands
{
    [Description("Breaks the tank!")]
    class Break : SimpleCommand
    {
        public override CommandType Type
        {
            get
            {
                return CommandType.Move;
            }
        }

        public override CommandError Execute(Tank tank)
        {
            var body = tank.GetComponent<Rigidbody>();

            body.velocity = body.velocity / 1.5f;

            return null;
        }
    }
}
