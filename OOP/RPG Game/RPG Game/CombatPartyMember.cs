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

            Skill s = new Skill();
            s.damagePerTurn = 2;
            s.initialDamage = 3;
            s.duration = 1;
            s.name = "Bleed";
            skills.Add(s);

        }

        public int Health { get; set; }
        public int AttackPower { get; set; }
        public Image Img { get; set; }


    }
}
