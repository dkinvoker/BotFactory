using Assets.Scripts;
using Assets.Scripts.Commands;
using System.Collections.Generic;

public class ProgramController
{
    public List<Command> Commands { get; private set; }
    public int ProgramCounter { get; set; }

    public ProgramController()
    {
        ProgramCounter = 0;
        Commands = new List<Command>();
    }

    public CommandError RunCurrentCommand(Tank tank)
    {
        var returner = Commands[ProgramCounter].Execute(tank);
        if (ProgramCounter == Commands.Count - 1)
        {
            ProgramCounter = 0;
        }
        else
        {
            ProgramCounter++;
        }
        return returner;
    }
}