using Assets.Scripts;
using Assets.Scripts.Bases;
using Assets.Scripts.Commands;
using Assets.Scripts.Parts.Memory;
using Assets.Scripts.Parts.Weapons;
using Assets.Scripts.Parts.Wheels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Tank : Unit
    {
        #region Props and publics
        public ProgramController ProgramController { get; private set; }
        public Memory Memory;
        public Weapon Weapon;
        public Transform FirePoint { get; private set; }
        public Wheels Wheels;
        public bool IsLocked { get; set; } = false;
        public int ProgramIndex = 0;
        public float RemainingReloadTime { get; set; } = -1.0f;
        public AudioSource AudioSource;
        public Rigidbody Rigidbody;
        #endregion

        #region Private Variables  
        #endregion

        #region Others
        public bool IsReadyToFire { get { return RemainingReloadTime <= 0; } }

        private void AdjustVolume()
        {
            this.AudioSource.volume = Rigidbody.velocity.magnitude / Wheels.MaxSpeed;
        }

        public void LoadWeapon()
        {
            var currentWeapon = this.gameObject.FindComponentInChildWithTag<Transform>("Tank Top");
            if (currentWeapon != null)
            {
                Destroy(currentWeapon.gameObject);
            }

            var newWeapon = GameObject.Instantiate(this.Weapon.Model, this.transform);
            newWeapon.transform.Translate(Weapon.ModelAnchor, Space.Self);
            newWeapon.transform.SetSiblingIndex(1);
        }

        private void RegisterReference()
        {
            PlayersManager.GetPlayerByName(this.Player).RegisterTank(this);
        }

        public float CalculateSpawningTime()
        {
            var weaponTime = this.Weapon.ConstructionTime;
            var wheelsTime = this.Wheels.ConstructionTime;

            return weaponTime + wheelsTime;
        }

        public int CalculateCost()
        {
            var weaponCost = this.Weapon.Cost;
            var wheelsCost = this.Wheels.Cost;

            return weaponCost + wheelsCost;
        }

        #endregion

        #region Tank Reboot
        private void Reboot()
        {
            IsLocked = true;
            ProgramController.ProgramCounter = 0;
            StartCoroutine(RebootCoorutine());
        }

        private IEnumerator RebootCoorutine()
        {
            yield return new WaitForSeconds(4);
            IsLocked = false;
        }
        #endregion

        #region Errorraport
        private void RaportError(CommandError error)
        {
            string finalMessage = $"Error occurred at {ProgramController.ProgramCounter} : {error.Message}. Rebooting tank";
            GameManager.Notify(finalMessage);
            Debug.LogError(finalMessage);
        }
        #endregion

        #region Monos
        // Use this for initialization
        void Start()
        {
            RegisterReference();          
            ProgramController = new ProgramController(this.Player, 0);
            this.AudioSource.clip = Wheels.Audio;
            this.AudioSource.Play();
            HP = Wheels.HP;
            FirePoint = this.GetComponentsInChildren<Transform>()[2].GetComponentsInChildren<Transform>()[1];

            //-----TESTS-----
            List<Command> testProgram = new List<Command>();
            testProgram.Add(new ClearMemory());
            testProgram.Add(new FindNearestEnemyTank() { MemoryIndex = 0 });
            testProgram.Add(new TurnWeaponToPosition() { MemoryIndex = 0 });
            testProgram.Add(new JumpIfAimingEnemyTank() { Negate = true, JumpPosition = 0 });
            testProgram.Add(new JumpIfWeaponReady() { Negate = true, JumpPosition = 0 });
            testProgram.Add(new Fire());
            PlayersManager.GetPlayerByName("Player2").RegisterProgram(testProgram);
            //this.ProgramIndex = 1;
            //-----TESTS-----
        }

        // Ta funkcja jest wywoływana co klatkę przy stałej szybkości klatek, jeśli klasa MonoBehaviour jest włączona
        private void FixedUpdate()
        {
            if (!IsLocked)
            {
                var packetError = ProgramController.ExecuteCommandPacket(this);
                if (packetError != null)
                {
                    RaportError(packetError);
                    Reboot();
                }
            }

        }

        // Update is called once per frame
        void Update()
        {
            if (RemainingReloadTime > 0)
            {
                RemainingReloadTime -= Time.deltaTime;
            }

            CheckHP();

            AdjustVolume();
        }

        private void OnDestroy()
        {
            PlayersManager.GetPlayerByName(this.Player).UnregisterTank(this);
        }

        #endregion

    }
}