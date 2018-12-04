using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Variables
{
    class Number : Variable
    {
        public float Value { get; set; }

        public Number(float value)
        {
            Value = value;
        }
    }
}
