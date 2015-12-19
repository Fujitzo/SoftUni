using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;

using System.IO;

namespace RPG_Game
{
    public class Game
    {
        Form gameForm;
        public static CombatGUI combatGUI;
        WorldMap worldMap;
        PlayerParty playerParty;
        PictureBox worldMapSpritePb;

        List<WorldMapMonster> monsters;
        WorldMapMonster monsterInCombat;

        bool inCombat;

        public Form GameForm { get; set; }

        public Game(Form gameForm)
        {
            this.GameForm = gameForm;
            this.GameForm.Height = 800;
            this.GameForm.Width = 800;
            this.GameForm.BackColor = Color.White;

            worldMap = new WorldMap(GameForm);            
            

            inCombat = false;

            Bitmap bmp = new Bitmap("PlayerPartySprite.png");
            Bitmap bmpMon = new Bitmap("MonsterSprite.png");

            playerParty = new PlayerParty(new Point(80, 80), bmp, 1, new CombatPartyMember(10, 5, new Bitmap("PlayerPartySprite.png")));

            monsters = new List<WorldMapMonster>();
            monsters.Add(new WorldMapMonster(new Point(0,0), bmpMon, 2, new CombatPartyMember(10, 5, new Bitmap("MonsterSprite.png"))));

            worldMapSpritePb = new PictureBox();
            worldMapSpritePb.Height = GameForm.Height;
            worldMapSpritePb.Width = GameForm.Width;
            worldMapSpritePb.BackColor = Color.Transparent;
            worldMapSpritePb.Parent = GameForm;

            Draw();

        }
        public void HandleKeyPressed(KeyEventArgs e)
        {
            if (!inCombat)
            {
                Point p = new Point(0,0);

                if (e.KeyCode == Keys.Left)
                {
                    p = new Point(-40, 0);
                   
                    //playerParty.partySprite.Move(-1, 0);
                }
                if (e.KeyCode == Keys.Right)
                {
                    p = new Point(40, 0);
                    //playerParty.partySprite.Move(1, 0);
                }
                if (e.KeyCode == Keys.Up)
                {
                    p = new Point(0, -40);
                    //playerParty.partySprite.Move(0, -1);
                }
                if (e.KeyCode == Keys.Down)
                {
                    p = new Point(0, 40);
                    //playerParty.partySprite.Move(0, 1);
                }
                if(worldMap.CheckIfTileCanBeSteppedOn(new Point(p.X + playerParty.partySprite.location.X, p.Y + playerParty.partySprite.location.Y)))
                {
                    playerParty.partySprite.Move(p.X, p.Y);
                }
            }
            else
            { 
             //Use MonsterInCombat to remove the correct sprite
             //If the combat GUI has exited combat remove our enemy sprite
                if (inCombat)
                {
                    monsterInCombat.isAlive = false;
                    KillMonsterInList(monsterInCombat);
                    inCombat = false;
                }            
            }            

            Draw();
            DetectCollision();
        }
        public void DetectCollision()
        {
            foreach (WorldMapMonster monster in monsters)
            {
                //check if monster is Alive and start combat only if it is Alive
                if (monster.isAlive && playerParty.partySprite.location == monster.location)
                {
                    //
                    monsterInCombat = monster;
                    inCombat = true;
                    combatGUI = new CombatGUI();
                    combatGUI.Visible = true;
                    combatGUI.StartCombat(playerParty, monsterInCombat.member);                
                }            
            }       

        }

        void KillMonsterInList(WorldMapMonster monsterToBeKilled)
        {
            foreach (WorldMapMonster monster in monsters)
            {
                if (monster == monsterToBeKilled)
                {
                    monster.isAlive = false;
                }
            }       
        
        }

        void Draw()
        {
            Graphics device;
            Image img = new Bitmap(GameForm.Width, GameForm.Height);
            device = Graphics.FromImage(img);

            worldMap.DrawMap(device);

            playerParty.partySprite.Draw(device);
            foreach (WorldMapMonster monster in monsters)
            {
                if (monster.isAlive)
                { 
                    monster.Draw(device);
                }
                
            }        
            

            worldMapSpritePb.Image = img;


        }

    }
}
 