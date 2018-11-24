using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Parts
{
    public abstract class TankPart : ScriptableObject
    {
        public int Cost;
        public float ConstructionTime;
    }
}
