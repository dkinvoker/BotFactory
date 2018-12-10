using Assets.Scripts.Commands.Unique;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    class ArithmeticalComparisonCommandInstanceBlock : JumpCommandInstanceBlock
    {
        public Dropdown MemoryIndex1Dropdown;
        public Dropdown MemoryIndex2Dropdown;
        public Dropdown OperatorDropdown;

        protected override void Start()
        {
            FillMemoryDropowns();
        }

        private void FillMemoryDropowns()
        {
            var manager = GameObject.FindGameObjectWithTag("Programming Manager");
            var memorySize = manager.GetComponent<ProgrammingManager>().MemorySize;
            List<string> options = new List<string>();
            for (int i = 0; i < memorySize; ++i)
            {
                options.Add(i.ToString());
            }
            MemoryIndex1Dropdown.ClearOptions();
            MemoryIndex1Dropdown.AddOptions(options);
            MemoryIndex1Dropdown.onValueChanged.AddListener(MemoryDropdown1ValueChange);
            MemoryIndex2Dropdown.ClearOptions();
            MemoryIndex2Dropdown.AddOptions(options);
            MemoryIndex2Dropdown.onValueChanged.AddListener(MemoryDropdown2ValueChange);

            options.Clear();
            options.Add("=");
            options.Add("!=");
            options.Add(">");
            options.Add(">=");
            options.Add("<");
            options.Add("<=");

            OperatorDropdown.ClearOptions();
            OperatorDropdown.AddOptions(options);
            OperatorDropdown.onValueChanged.AddListener(OperationDropdownValueChange);
        }

        private void MemoryDropdown1ValueChange(int index)
        {
            (this.Command as ArithmeticalComparison).MemoryIndex1 = index;
        }

        private void MemoryDropdown2ValueChange(int index)
        {
            (this.Command as ArithmeticalComparison).MemoryIndex2 = index;
        }

        private void OperationDropdownValueChange(int index)
        {
            var command = this.Command as ArithmeticalComparison;
            switch (OperatorDropdown.options[index].text)
            {
                case "=":
                    command.Operator = ArithmeticalComparison.ComparisonOperator.Equals;
                    break;
                case "!=":
                    command.Operator = ArithmeticalComparison.ComparisonOperator.NotEquals;
                    break;
                case ">":
                    command.Operator = ArithmeticalComparison.ComparisonOperator.Greater;
                    break;
                case ">=":
                    command.Operator = ArithmeticalComparison.ComparisonOperator.GreaterOrEquals;
                    break;
                case "<":
                    command.Operator = ArithmeticalComparison.ComparisonOperator.Less;
                    break;
                case "<=":
                    command.Operator = ArithmeticalComparison.ComparisonOperator.LessOrEquals;
                    break;
                default:
                    throw new Exception("Invalid Operator");
            }
        }
    }
}
