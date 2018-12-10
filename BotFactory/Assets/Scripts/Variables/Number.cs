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

        public static Number operator +(Number number1, Number number2)
        {
            return new Number(number1.Value + number2.Value);
        }

        public static Number operator +(Number number1, float number2)
        {
            return new Number(number1.Value + number2);
        }

        public static Number operator -(Number number1, Number number2)
        {
            return new Number(number1.Value - number2.Value);
        }

        public static Number operator -(Number number1, float number2)
        {
            return new Number(number1.Value - number2);
        }

    }
}
