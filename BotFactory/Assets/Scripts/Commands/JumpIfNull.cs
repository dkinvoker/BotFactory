using Assets.Scripts.Commands.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Commands
{
    class JumpIfNull : JumpCommand
    {
        public override string Description
        {
            get
            {
                return "Perform a program jump if certain memory cell is empty";
            }
        }

        protected override bool DirectConditionCheck(Tank tank)
        {
            throw new NotImplementedException();
        }
    }
}
