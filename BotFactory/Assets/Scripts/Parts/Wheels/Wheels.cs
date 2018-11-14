using UnityEngine;

namespace Assets.Scripts.Parts.Wheels
{
    [CreateAssetMenu(fileName = "Wheels", menuName = "Tank Parts/Wheels")]
    public class Wheels : ScriptableObject
    {
        public float Acceleration;
        public float MaxSpeed;
        public float TurningSpeed;
    }
}

