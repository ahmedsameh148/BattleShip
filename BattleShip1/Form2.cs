using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace BattleShip1
{   
    public partial class welcome_page : Form
    {
        public welcome_page()
        {  
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            Form5 sss=new Form5() ;
            sss.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("If you Want to Start the game \n press 'play now..' \n else if You want to Exit press Exit ! (: ");
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }
    }
}
