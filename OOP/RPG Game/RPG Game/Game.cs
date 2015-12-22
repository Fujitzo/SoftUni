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
        List<WorldMapSprite> friendlyHeroes;
        WorldMapMonster monsterInCombat;
        //List<WorldMapFriend> friends;
        WorldMapFriend friendsInCombat;
        TextBoxReader textBoxReader;

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

            friendlyHeroes = new List<WorldMapSprite>();
            friendlyHeroes.Add(new WorldMapSprite(new Point(120, 0), new Bitmap("rogue2.png"), 3));
            friendlyHeroes[0].textFileName = "rogueIntro";

            textBoxReader = new TextBoxReader();

            //combatGUI = new CombatGUI();
            //combatGUI.Visible = true;
            inCombat = false;

            //Add combat party members for this class
            //playerParty = new PlayerParty(new Point(80, 0), new Bitmap("PlayerPartySprite.png"), 1,
            //    new CombatPartyMember(10, 5, new Bitmap("PlayerKnightCombatSprite.png")));


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
                if (textBoxReader.isOpen)
                {
                    if (e.KeyCode == Keys.Enter)
                        textBoxReader.Next();
 
                    if (textBoxReader.instructions.Count > 0)
                        ExectueInstruction(textBoxReader.instructions);
                }
                else
                {
                     Point p = new Point(0, 0);

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
                     if (worldMap.CheckIfTileCanBeSteppedOn(new Point(p.X + playerParty.partySprite.location.X, p.Y + playerParty.partySprite.location.Y)))
                     {
                         playerParty.partySprite.Move(p.X, p.Y);
                     }


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
            foreach (WorldMapSprite fr in friendlyHeroes)
            {                
                if (playerParty.partySprite.location == fr.location)
                {
                    playerParty.partySprite.location.X += 40;
                    if (fr.textFileName != "")
                    {
                        textBoxReader.OpenText(fr.textFileName, fr);
                    }                    
                }      
            
            }
        }

        public void ExectueInstruction(List<string> instructions)
        {
            if (instructions.Count > 0)
            {
                switch (instructions[0].Substring(1, 4))
                {
                    case "NEWP":
                        playerParty.member2 = new CombatPartyMember(int.Parse(instructions[1]), int.Parse(instructions[2]),
                            new Bitmap(instructions[3]));
                        instructions.RemoveRange(0, 4);
                        ExectueInstruction(instructions);
                        break;

                    case "REMV":
                        friendlyHeroes.Remove((WorldMapSprite)textBoxReader.sender);
                        instructions.RemoveRange(0, 1);
                        ExectueInstruction(instructions);
                        break;
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
            foreach (WorldMapSprite fr in friendlyHeroes)
            {                
                    fr.Draw(device);                
            }

            if (textBoxReader.isOpen)
            {
                device.FillRectangle(new SolidBrush(Color.Blue), new Rectangle(0, 800, 800, 70));
                device.DrawString(textBoxReader.currentLine, new Font("arial", 20),
                    new SolidBrush(Color.White), new Point(5, 305));

                //device.FillRectangle(new SolidBrush(Color.Blue), new Rectangle(0, 300, 400, 70));
                //device.DrawString(textBoxReader.currentLine, new Font("arial", 10),
                //    new SolidBrush(Color.White), new Point(5, 305));
                
                
            }
            

            worldMapSpritePb.Image = img;


        }

    }
}
 