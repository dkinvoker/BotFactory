using UnityEngine;

namespace Assets.Scripts.Parts.Weapons
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Tank Parts/Weapon")]
    public class Weapon : ScriptableObject
    {
        public double Damage;
        public double ReloadTime;
        public double BulletSpeed;
    }
}

