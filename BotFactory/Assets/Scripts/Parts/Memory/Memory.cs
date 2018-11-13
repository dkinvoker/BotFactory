using Assets.Scripts.Variables;
using System.Collections.Generic;
namespace Assets.Scripts.Parts.Memory
{
    public abstract class Memory
    {
        private Variable[] _variables;

        protected Memory(int capacity)
        {
            _variables = new Variable[capacity];
        }

        public int Count
        {
            get
            {
                return _variables.Length;
            }
        }

        public Variable this[int index]
        {
            get
            {
                return _variables[index];
            }
            private set
            {
                _variables[index] = value;
            }
        }

        public bool StoreValue(Variable variable, int index)
        {
            if (this[index] == null)
            {
                this[index] = variable;
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
