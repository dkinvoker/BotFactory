using Assets.Scripts.Commands;
using Assets.Scripts.Commands.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    class JumpCommandInstanceBlock : CommandInstanceBlock
    {
        public GameObject TargetBlock { get; set; }

        public void ChangeNegateStatus(bool newStatus)
        {
            (this.Command as JumpCommand).Negate = newStatus;
        }

        private void OnDestroy()
        {
            if (TargetBlock != null)
            {
                TargetBlock.GetComponent<JumpTarget>().JumpParent = null;
                Destroy(TargetBlock);
            }  
        }

    }
}
