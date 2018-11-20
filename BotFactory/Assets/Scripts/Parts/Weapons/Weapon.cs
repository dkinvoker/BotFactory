using UnityEngine;

namespace Assets.Scripts.Parts.Weapons
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Tank Parts/Weapon")]
    public class Weapon : ScriptableObject
    {
        public float Damage;
        public float ReloadTime;
        public float BulletSpeed;
        public float Range;
    }
}

