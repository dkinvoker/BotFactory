using Assets.Scripts.Commands;
using Assets.Scripts.Parts.Memory;
using Assets.Scripts.Parts.Weapons;
using Assets.Scripts.Parts.Wheels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    public ProgramController ProgramController { get; set; }
    public Memory Memory { get; set; }
    public Weapon Weapon { get; set; }
    public Wheels Wheels { get; set; }

    // Use this for initialization
    void Start()
    {
        ProgramController = new ProgramController();
        Memory = new BasicMemory();
        Weapon = new BasicWeapon();
        Wheels = new BasicWheels();

        ProgramController.Commands.Add(new AccelerateForward());
    }

    // Ta funkcja jest wywoływana co klatkę przy stałej szybkości klatek, jeśli klasa MonoBehaviour jest włączona
    private void FixedUpdate()
    {
        ProgramController.RunCurrentCommand(this);
    }

    // Update is called once per frame
    void Update()
    {

    }


}
