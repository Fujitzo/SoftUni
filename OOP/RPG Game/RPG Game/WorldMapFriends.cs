using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;

namespace RPG_Game
{
    class WorldMapFriend:WorldMapSprite
    {
        public bool isMoving;
        public bool isAlive;
        public PlayerParty member;

        public WorldMapFriend(Point location, Image image, int id, PlayerParty member)
            : base(location, image, id)
        {
            this.member = member;
            isMoving = false;
            isAlive = true;
        }

    }
}
