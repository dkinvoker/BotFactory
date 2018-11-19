using System.ComponentModel;
using UnityEngine;

namespace Assets.Scripts.Commands
{
    public abstract class Command
    {
        public abstract CommandType Type { get; }

        public abstract CommandError Execute(Tank tank);

        public string Description
        {
            get
            {
                var type = this.GetType();
                var atributes = type.GetCustomAttributes(typeof(DescriptionAttribute), false);
                return (atributes[0] as DescriptionAttribute).Description;
            }
        }

        public Command Copy()
        {
            return this.MemberwiseClone() as Command;
        }
    }

    public enum CommandType
    {
        Move,
        Rotation,
        PureMemory,
        Shoot,
        Detect,
        WeaponRotation,
        Jump
    }
}