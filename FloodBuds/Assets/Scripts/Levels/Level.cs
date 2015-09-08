using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace Assets.Scripts.Levels
{
    public class Level
    {
        public string Name { get; set; }
        public Construction Construction { get; set; }
    }

    public class Construction
    {
        public int GridSize { get; set; }
        public List<Barrier> Barriers { get; set; }
        public List<Player> Players { get; set; }
        public List<Danger> Dangers { get; set; }
    }

    public class Danger
    {
    }

    public class Player
    {
    }

    public class Barrier
    {

    }
}
