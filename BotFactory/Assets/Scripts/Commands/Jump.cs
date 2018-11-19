using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Commands
{
    [Description("Redirect program flow to specific command number")]
    class Jump : JumpCommand
    {
        public override CommandType Type
        {
            get
            {
                return CommandType.Jump;
            }
        }

        public override CommandError Execute(Tank tank)
        {
            //-1 position jumping is required becouse program controller incresses program counter at the end of each execution
            tank.ProgramController.ProgramCounter = this.JumpPosition - 1;
            return null;
        }
    }
}
