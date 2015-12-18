using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace RPG_Game
{

    public partial class CombatGUI : Form
    {
        List<CombatPartyMember> playerPartyMembers;
        CombatPartyMember enemyMember;
        int currentPartyMember = 0;
        public bool inCombat;
        //
        public bool playerTurn;
        List<ActiveSkill> activeSkills = new List<ActiveSkill>();

        public CombatGUI()
        {
            InitializeComponent();
            playerPartyMembers = new List<CombatPartyMember>();

            inCombat = false;
            //
            playerTurn = true;
            enemyAttackTimer.Interval = 1500;
            systemSleepTimer.Interval = 1500;
        }


        public void StartCombat(PlayerParty playerParty, CombatPartyMember enemy)
        {
            enemyMember = enemy;
            playerPartyMembers.Add(playerParty.member1);
            inCombat = true;

            Party1.Image = playerPartyMembers[0].Img;
            Enemy1.Image = enemyMember.Img;
            LoadSkillsForPlayer();
        }

        void OutputFlavourText(string text)
        {
            textBox.AppendText(text + "\n");
        }

        void LoadSkillsForPlayer()
        {
            comboSkill.Items.Clear();

            foreach (Skill s in playerPartyMembers[currentPartyMember].skills)
            {
                comboSkill.Items.Add(s.name);
            }
        }

        void ApplySkillDamage()
        {
            for (int x = 0; x < activeSkills.Count; x++)
            {
                var a = activeSkills[x];
                a.target.Health -= a.skill.damagePerTurn;
                a.remainingTurns--;

                OutputFlavourText(a.skill.name + " did " + a.skill.damagePerTurn + " damage!");

                if (a.remainingTurns == 0)
                    activeSkills.RemoveAt(x);
            }
        }

        private void attackButton_Click(object sender, EventArgs e)
        {
            ApplySkillDamage();

            if (inCombat)
            {
                if (playerTurn)
                {
                    LoadSkillsForPlayer();

                    if (partyActionAttack.Checked)
                    {
                        //Damage done will vary
                        int damage = playerPartyMembers[currentPartyMember].AttackPower;

                        OutputFlavourText("Attacked enemy with " + damage + " damage");

                        enemyMember.Health -= damage;
                    }
                    if (partyActionSkill.Checked)
                    {
                        //get skill which matches skill in box
                        foreach (Skill s in playerPartyMembers[currentPartyMember].skills)
                        {
                            if (s.name == comboSkill.Text)
                            {
                                ActiveSkill a = new ActiveSkill();
                                a.skill = s;
                                a.target = enemyMember;
                                a.remainingTurns = s.duration;
                                activeSkills.Add(a);

                                enemyMember.Health -= s.initialDamage;
                                OutputFlavourText("Cast " + "\"" + s.name + "\" for " + s.initialDamage);
                            }
                        }
                    }
                    if (currentPartyMember < playerPartyMembers.Count-1)
                    {
                        currentPartyMember++;
                    }
                    else
                    {
                        currentPartyMember = 0;
                        playerTurn = false;
                        enemyAttackTimer.Enabled = true;
                    }
                }

                //Exit battle if enemy is dead
                if (enemyMember.Health <= 0)
                {
                    textBox.AppendText("\n" + "Enemy defeated!");
                    //systemSleepTimer.Enabled = true;
                    inCombat = false;
                    System.Threading.Thread.Sleep(1500);                                        
                    Game.combatGUI.Visible = false;
                }
            }
        }

        private void enemyAttackTimer_Tick(object sender, EventArgs e)
        {
            //Target a random player
            Random rand = new Random();
            int x = rand.Next(0, playerPartyMembers.Count);
            //Damage player
            playerPartyMembers[x].Health -= enemyMember.AttackPower;
            OutputFlavourText("Player suffered " + enemyMember.AttackPower + " damage!");

            //Check if all players are still alive
            inCombat = false;
            foreach (CombatPartyMember c in playerPartyMembers)
            {
                if (c.Health >= 0)
                {
                    inCombat = true;
                }
            }

            enemyAttackTimer.Enabled = false;

            if (inCombat == false)
            {
                OutputFlavourText("Player party defeated!");
                //do something  (TO DO)
            }
            else
            {
                playerTurn = true;
            }
        }
        private void textBox1_TextChanged (object sender, EventArgs e)
        {
            
        }
        private void checkBox1_CheckedChanged (object sender, EventArgs e)
        {
            
        }

        private void SleepTick(object sender, EventArgs e)
        {
            //systemSleepTimer.Enabled = false;
        }
    }
}

