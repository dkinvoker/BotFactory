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
        public string Side { get; private set; }
        public int Damage { get; private set; }
        private bool _emitionColistionOccured = false;

        public void Init(Tank tank)
        {
            _rangeRemaining = tank.Weapon.Range;
            _speed = tank.Weapon.BulletSpeed;
            Side = tank.Side;
            Damage = tank.Weapon.Damage;
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

        private void OnTriggerEnter(Collider other)
        {
            if (_emitionColistionOccured == false)
            {
                _emitionColistionOccured = true;
                return;
            }

            //-----
            var tank = other.GetComponent<Tank>();
            if (tank != null && tank.Side != this.Side)
            {
                tank.HP -= this.Damage;
            }
            Destroy(this.gameObject);
        }


    }
}
