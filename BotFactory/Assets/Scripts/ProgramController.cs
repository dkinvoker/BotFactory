using Assets.Scripts;
using Assets.Scripts.Commands;
using System;
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

    private CommandError RunCurrentCommand(Tank tank)
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

    private CommandType GetCurrentCommandType()
    {
        return Commands[ProgramCounter].Type;
    }

    public CommandError ExecuteCommandPacket(Tank tank)
    {
        CommandError commandError = null;
        List<CommandType> usedTypes = new List<CommandType>(); 
        while (!usedTypes.Contains( GetCurrentCommandType() ))
        {
            usedTypes.Add(GetCurrentCommandType());
            commandError = RunCurrentCommand(tank);
            if (commandError != null)
            {
                return commandError;
            }
        }

        return commandError;
    }
}