using Assets.Scripts;
using Assets.Scripts.Commands;
using System;
using System.Collections.Generic;

public class ProgramController
{
    public static Dictionary<string, List<List<Command>>> Programs { get; private set; }

    public int ProgramCounter { get; set; }

    private string _player { get; set; } = string.Empty;
    private int _programIndex = -1;

    private List<Command> CurrnetProgram
    {
        get
        {
            return Programs[_player][_programIndex];
        }
    }

    static ProgramController()
    {
        Programs = new Dictionary<string, List<List<Command>>>();
    }

    public ProgramController()
    {
        ProgramCounter = 0;
    }

    private CommandError RunCurrentCommand(Tank tank)
    {
        var returner = CurrnetProgram[ProgramCounter].Execute(tank);
        if (returner == null)
        {
            if (ProgramCounter == CurrnetProgram.Count - 1)
            {
                ProgramCounter = 0;
            }
            else
            {
                ProgramCounter++;
            }
        }

        return returner;
    }

    private CommandType GetCurrentCommandType()
    {
        return CurrnetProgram[ProgramCounter].Type;
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

    public static void RegisterProgram(string player, List<Command> program)
    {
        if (!Programs.ContainsKey(player))
        {
            Programs.Add(player, new List<List<Command>>());
        }
        Programs[player].Add(program);      
    }

    public void SetToTankProgram(Tank tank)
    {
        _player = tank.Player;
        _programIndex = tank.ProgramInex;
    }
}