using Assets.Scripts.Parts.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class Bullet : MonoBehaviour
    {
        private float _rangeRemaining;
        private float _speed;
        public float Damage { get; private set; }

        public Bullet(Weapon weapon)
        {
            _rangeRemaining = weapon.Range;
            _speed = weapon.BulletSpeed;
            Damage = weapon.Damage;
        }

        private void Update()
        {
            var distance = _speed * Time.deltaTime;
            this.transform.Translate(Vector3.forward * distance);

            _rangeRemaining -= distance;

            if (_rangeRemaining <= 0)
            {
                Destroy(this.gameObject);
            }
        }


    }
}
