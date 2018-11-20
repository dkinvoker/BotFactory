using UnityEngine;

namespace Assets.Scripts.Parts.Weapons
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Tank Parts/Weapon")]
    public class Weapon : ScriptableObject
    {
        public int Damage;
        public float ReloadTime;
        public float BulletSpeed;
        public float Range;
        public GameObject Bullet;

        public GameObject CreateBulletAtLocation(Vector3 position, Quaternion rotation)
        {
            return Instantiate(Bullet, position, rotation);
        }
    }
}

