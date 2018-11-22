using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.UI
{
    class JumpTarget : MonoBehaviour
    {
        public GameObject JumpParent { get; set; }

        private void OnDestroy()
        {
            if (JumpParent != null)
            {
                JumpParent.GetComponent<JumpCommandInstanceBlock>().TargetBlock = null;
                Destroy(JumpParent);
            }       
        }

    }
}
