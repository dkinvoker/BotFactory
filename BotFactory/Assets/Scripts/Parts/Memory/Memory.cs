using System.Collections.Generic;
namespace Assets.Scripts.Parts.Memory
{
    public abstract class Memory
    {
        public Variable[] Variables { get; private set; }

        protected Memory(int capacity)
        {
            Variables = new Variable[capacity];
        }

        public int Count
        {
            get
            {
                return Variables.Length;
            }
        }

        public Variable this[int index]
        {
            get
            {
                return Variables[index];
            }
            set
            {
                Variables[index] = value;
            }
        }

    }
}
