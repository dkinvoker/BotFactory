using Assets.Scripts.Variables;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Parts.Memory
{
    [CreateAssetMenu(fileName = "Memory", menuName = "Tank Parts/Memory")]
    public class Memory :ScriptableObject
    {
        private Variable[] _variables;
        public int Size;

        public void Initialize()
        {
            _variables = new Variable[Size];
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
