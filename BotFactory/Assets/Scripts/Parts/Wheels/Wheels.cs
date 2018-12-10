using UnityEngine;

namespace Assets.Scripts.Parts.Wheels
{
    [CreateAssetMenu(fileName = "Wheels", menuName = "Tank Parts/Wheels")]
    public class Wheels : TankPart
    {
        public float Acceleration;
        public float MaxSpeed;
        public float TurningSpeed;
        public int HP;
        public GameObject Model;

        public AudioClip Audio;
    }
}

