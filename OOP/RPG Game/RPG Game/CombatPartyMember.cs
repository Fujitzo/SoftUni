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

            Skill lifeSteal = new Skill();
            lifeSteal.damagePerTurn = 0;
            lifeSteal.healAmmount = 3;
            lifeSteal.initialDamage = 3;
            lifeSteal.duration = 1;
            lifeSteal.name = "Life Steal";
            skills.Add(lifeSteal);

        }

        public int Health { get; set; }
        public int AttackPower { get; set; }
        public Image Img { get; set; }


    }
}
