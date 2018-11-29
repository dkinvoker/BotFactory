using UnityEngine;

namespace Assets.Scripts.Parts.Weapons
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Tank Parts/Weapon")]
    public class Weapon : TankPart
    {
        public int Damage;
        public float ReloadTime;
        public float BulletSpeed;
        public float Range;
        public GameObject Bullet;
        public GameObject Model;
        public Vector3 ModelAnchor;

        public GameObject CreateBulletAtLocation(Vector3 position, Quaternion rotation)
        {
            return Instantiate(Bullet, position, rotation);
        }
    }
}

