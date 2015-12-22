using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;

namespace RPG_Game
{
    public class WorldMapSprite
    {
        public Point location;
        public Image image;
        public int id;
        public string textFileName = "";

        public WorldMapSprite(Point location, Image image, int id)
        {
            this.location = location;
            this.image = image;
            this.id = id;        
        }

        public Point Location { get; set; }
        public Image Image { get; set; }
        public int ID { get; set; }
        public string TextFileName { get; set; }

        public void Move(int x, int y)
        {
            this.location.X += x;
            this.location.Y += y;
        }

        public void Draw(Graphics device)
        {
            device.DrawImage(image, location);
        }

    }
}
