using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    class LvlManager : MonoBehaviour
    {
        public int ResourcesRequied = 1;
        public bool TimeToDestroy { get; set; } = false;
    }
}
