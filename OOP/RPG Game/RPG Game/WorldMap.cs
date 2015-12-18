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
    public class WorldMap
    {
        
        public List<Tile> mapTiles;

        public Image mapImage;

        public struct Tile
        {
            public Image img;
            public Point location;
            public bool canStepOn;
        }

        public WorldMap(Form form)
        { 
            mapTiles = new List<Tile>();
            LoadMap("Map");
                 
        }
        public void LoadMap(string mapName)
        {
            StreamReader reader = new StreamReader(mapName + ".txt");
            int y = 0;
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                for (int x = 0; x < line.Length; x++)
                {
                    Tile t = new Tile();
                    t.location = new Point(x * 40, y * 40);
                    if(line[x].Equals('1'))
                    {
                        t.img = new Bitmap("GrassTile.png");
                        t.canStepOn = true;
                    }
                    if(line[x].Equals('0'))
                    {
                        t.img = new Bitmap("WaterTile.png");
                        t.canStepOn = false;
                    }
                    mapTiles.Add(t);
                }
                y++;          
            
            }       
        
        }
        public bool CheckIfTileCanBeSteppedOn(Point loc)
        {
            foreach (Tile t in mapTiles)
            {
                if (t.location == loc)
                {
                    if (t.canStepOn)
                    {
                        return true;
                    }
                }
                
            }
            return false;
        }
        public void DrawMap(Graphics device)
        {

            foreach (Tile t in mapTiles)
            {
                device.DrawImage(t.img, t.location);
            
            }     

        
        }


    }
}
