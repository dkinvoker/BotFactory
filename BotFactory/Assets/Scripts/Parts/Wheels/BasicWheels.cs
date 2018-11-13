using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Parts.Wheels
{
    class BasicWheels : Wheels
    {
        public BasicWheels()
        {
            MaxSpeed = 15;
            TurningSpeed = 0.2f;
            Acceleration = 10;
        }
    }
}
