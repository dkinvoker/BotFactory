using Assets.Scripts.Commands.Bases;
using Assets.Scripts.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Commands.Unique
{
    class ArithmeticalComparison : JumpCommand
    {
        public int MemoryIndex1 { get; set; }
        public int MemoryIndex2 { get; set; }
        public ComparisonOperator Operator { get; set; }

        public override CommandType Type
        {
            get
            {
                return CommandType.Comparison;
            }
        }

        public override string Description
        {
            get
            {
                return "Compares the values from two memory cells";
            }
        }

        public override CommandError Execute(Tank tank)
        {
            var error = Validate(tank);
            if (error == null)
            {
                return base.Execute(tank);
            }
            else
            {
                return error;
            }
            
        }

        protected override bool DirectConditionCheck(Tank tank)
        {
            var memoryData1 = tank.Memory[MemoryIndex1] as Number;
            var memoryData2 = tank.Memory[MemoryIndex2] as Number;

            switch (this.Operator)
            {
                case ComparisonOperator.Equals:
                    if (memoryData1.Value == memoryData2.Value)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case ComparisonOperator.Greater:
                    if (memoryData1.Value > memoryData2.Value)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case ComparisonOperator.GreaterOrEquals:
                    if (memoryData1.Value >= memoryData2.Value)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case ComparisonOperator.Less:
                    if (memoryData1.Value < memoryData2.Value)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case ComparisonOperator.LessOrEquals:
                    if (memoryData1.Value <= memoryData2.Value)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case ComparisonOperator.NotEquals:
                    if (memoryData1.Value != memoryData2.Value)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                default:
                    throw new Exception("Default!? HAŁ?");
            }
        }

        private CommandError Validate(Tank tank)
        {
            var memoryData1 = tank.Memory[MemoryIndex1];
            var memoryData2 = tank.Memory[MemoryIndex2];

            if (memoryData1 == null)
            {
                return new CommandError($"Memory at {MemoryIndex1} is empty!");
            }
            else if (memoryData2 == null)
            {
                return new CommandError($"Memory at {MemoryIndex2} is empty!");
            }
            else if (!(memoryData1 is Number))
            {
                return new CommandError($"Variable at {MemoryIndex1} should be Number type");
            }
            else if (!(memoryData2 is Number))
            {
                return new CommandError($"Variable at {MemoryIndex2} should be Number type");
            }
            else
            {
                return null;
            }
        }

        public enum ComparisonOperator
        {
            Equals,
            NotEquals,
            Greater,
            GreaterOrEquals,
            Less,
            LessOrEquals
        }

    }
}
