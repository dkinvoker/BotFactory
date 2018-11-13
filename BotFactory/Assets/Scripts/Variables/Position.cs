using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Variables
{
    class Position : Variable
    {
        public Vector3 Value { get; set; }

        public Position(Vector3 vector)
        {
            Value = vector;
        }
    }
}
