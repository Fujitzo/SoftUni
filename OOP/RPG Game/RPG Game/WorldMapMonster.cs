using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;

namespace RPG_Game
{
    public class WorldMapMonster:WorldMapSprite
    {
        public bool isMoving;
        public bool isAlive;
        public CombatPartyMember member;

        public WorldMapMonster(Point location, Image image, int id, CombatPartyMember member)
            : base(location, image, id)
        {
            this.member = member;
            isMoving = false;
            isAlive = true;
        }

    }
}
