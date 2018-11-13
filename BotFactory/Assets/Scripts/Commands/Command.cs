namespace Assets.Scripts.Commands
{
    public abstract class Command
    {
        /// <summary>
        /// Executes the command
        /// </summary>
        /// <param name="tank"> Tank that will execute the command </param>
        /// <returns> True if success, false otherwise </returns>
        public abstract bool Execute(Tank tank);
    }
}