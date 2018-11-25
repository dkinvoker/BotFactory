using Assets.Scripts.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class Player
    {
        public string PlayerName { get; set; }
        public string SideName { get; set; }

        public int Resources { get; set; }

        public List<List<Command>> Programs { get; set; }

    }
}
