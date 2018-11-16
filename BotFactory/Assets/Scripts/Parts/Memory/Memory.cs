using Assets.Scripts.Variables;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Parts.Memory
{
    [CreateAssetMenu(fileName = "Memory", menuName = "Tank Parts/Memory")]
    public class Memory : ScriptableObject
    {
        public Variable[] Variables;

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
            private set
            {
                Variables[index] = value;
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
