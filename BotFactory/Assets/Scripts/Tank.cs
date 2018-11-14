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
    public Memory Memory;
    public Weapon Weapon;
    public Wheels Wheels;
    public double HP { get; set; }
    public string Player;
    public string Side;

    // Use this for initialization
    void Start()
    {
        Memory.Initialize();

        ProgramController = new ProgramController();

        //ProgramController.Commands.Add(new AccelerateForward());
        //ProgramController.Commands.Add(new TurnRight());

        ProgramController.Commands.Add(new FindNearestEnemy(0));
        ProgramController.Commands.Add(new TurnToPosition(0));
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
