using Assets.Scripts;
using Assets.Scripts.Commands;
using System;
using System.Collections.Generic;

namespace Assets.Scripts
{
    public class ProgramController
    {
        public int ProgramCounter { get; set; }

        private string _player { get; set; } = string.Empty;
        private int _programIndex = -1;
        private List<Command> _program;


        public ProgramController(string player, int index)
        {
            _program = PlayersManager.GetPlayerByName(player).Programs[index];
            ProgramCounter = 0;
        }

        public int MaxCommandIndex
        {
            get
            {
                return _program.Count - 1;
            }
        }

        private CommandError RunCurrentCommand(Tank tank)
        {
            var returner = _program[ProgramCounter].Execute(tank);
            if (returner == null)
            {
                if (ProgramCounter == _program.Count - 1)
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
            return _program[ProgramCounter].Type;
        }

        public CommandError ExecuteCommandPacket(Tank tank)
        {
            CommandError commandError = null;
            List<CommandType> usedTypes = new List<CommandType>();
            while (!usedTypes.Contains(GetCurrentCommandType()))
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
}