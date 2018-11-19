using Assets.Scripts;
using Assets.Scripts.Commands;
using Assets.Scripts.Parts.Memory;
using Assets.Scripts.Parts.Weapons;
using Assets.Scripts.Parts.Wheels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Tank : MonoBehaviour
    {
        #region Props and publics
        public ProgramController ProgramController { get; set; } = new ProgramController();
        public Memory Memory;
        public Weapon Weapon;
        public Wheels Wheels;
        public double HP { get; set; }
        public string Player;
        public string Side;
        public bool IsLocked { get; set; } = false;
        public int ProgramIndex = 0;
        #endregion

        #region Private Variables
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
            Debug.LogError(finalMessage);
        }
        #endregion

        #region Monos
        // Use this for initialization
        void Start()
        {
            //-----TESTS-----
            List<Command> testProgram = new List<Command>();
            testProgram.Add(new ClearMemory());
            testProgram.Add(new FindNearestEnemy() { MemoryIndex = 0 });
            testProgram.Add(new TurnWeaponToPosition() { MemoryIndex = 0 });
            testProgram.Add(new JumpIfFacingEnemy() { JumpPosition = 5 });
            testProgram.Add(new Jump() { JumpPosition = 0 });
            testProgram.Add(new AccelerateForward());
            ProgramController.RegisterProgram("Player1", testProgram);
            this.ProgramIndex = 1;
            //-----TESTS-----

            ProgramController.SetToTankProgram(this);
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

        }
        #endregion

    }
}