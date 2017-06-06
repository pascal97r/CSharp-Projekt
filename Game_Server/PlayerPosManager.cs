using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Game_Server
{
    class PlayerPosManager
    {
        Thread thread;
        ThreadStart ts;
        Spieler player;

        public PlayerPosManager(Spieler player)
        {
            this.player = player;
        }

        public void sendPos()
        {

        }
    }
}
