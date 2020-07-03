using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleShip1
{
    public partial class Form5 : Form
    {
        int X = 0;
        public Form5()
        {
           
            InitializeComponent();
           
        }
        void closee(int x) { 
          if (x == 1)
            {
                this.Hide();
                BattleShip ss = new BattleShip();
                ss.ShowDialog();
            }
        }
        private void Form5_Load(object sender, EventArgs e)
        {
          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(1);
            if (progressBar1.Value == 100) {
                timer1.Stop(); X = 1; closee(X);
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
