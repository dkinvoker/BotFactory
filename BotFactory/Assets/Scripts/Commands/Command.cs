using UnityEngine;

namespace Assets.Scripts.Commands
{
    public abstract class Command : ScriptableObject
    {
        public abstract CommandType Type { get; }
        /// <summary>
        /// Executes the command
        /// </summary>
        /// <param name="tank"> Tank that will execute the command </param>
        /// <returns> True if success, false otherwise </returns>
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