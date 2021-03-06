﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;

namespace RPG_Game
{
    public class PlayerParty
    {
        public WorldMapSprite partySprite;
        public CombatPartyMember member1;
        public CombatPartyMember member2 { get; set; }

        public PlayerParty(Point location, Image image, int id, CombatPartyMember member1) 
        {
            partySprite = new WorldMapSprite(location, image, id);
            this.member1 = member1;            
        }

        public PlayerParty(Point location, Image image, int id, CombatPartyMember member1, CombatPartyMember member2)
        {
            partySprite = new WorldMapSprite(location, image, id);
            this.member1 = member1;
            this.member2 = member2;
        }


        
    }
}
