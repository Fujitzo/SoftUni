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
    public partial class MainWindow : Form
    {

        Game game;
        public MainWindow()
        {
            InitializeComponent();
            game = new Game(this);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            game.HandleKeyPressed(e);
        }
    }
}
