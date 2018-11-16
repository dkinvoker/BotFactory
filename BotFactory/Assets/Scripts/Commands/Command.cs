using UnityEngine;

namespace Assets.Scripts.Commands
{
    public abstract class Command : ScriptableObject
    {
        public abstract CommandType Type { get; }

        public abstract CommandError Execute(Tank tank);
    }

    public enum CommandType
    {
        Move,
        Rotation,
        PureMemory,
        Shoot,
        Detect,
        WeaponRotation
    }
}