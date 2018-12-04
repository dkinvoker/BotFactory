using System.ComponentModel;
using UnityEngine;

namespace Assets.Scripts.Commands
{
    public abstract class Command
    {
        public abstract CommandType Type { get; }

        public abstract CommandError Execute(Tank tank);

        public abstract string Description
        {
            get;
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
        Fire,
        Detect,
        WeaponRotation,
        Jump
    }
}