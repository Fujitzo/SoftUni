using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;

namespace RPG_Game
{
    public class CombatPartyMember
    {
        private int health;
        private int attackPower;
        private Image img;

        public List<Skill> skills = new List<Skill>(); 

        public CombatPartyMember(int health, int attackPower, Image img)
        {
            this.Health = health;
            this.AttackPower = attackPower;
            this.Img = img;

            Skill bleed = new Skill();
            bleed.damagePerTurn = 2;
            bleed.healAmmount = 0;
            bleed.initialDamage = 3;
            bleed.duration = 1;
            bleed.name = "Bleed";
            skills.Add(bleed);

            Skill heal = new Skill();
            heal.damagePerTurn = 0;
            heal.healAmmount = 3;
            heal.initialDamage = 3;
            heal.duration = 1;
            heal.name = "Life Steal";
            skills.Add(heal);

        }

        public int Health { get; set; }
        public int AttackPower { get; set; }
        public Image Img { get; set; }


    }
}
