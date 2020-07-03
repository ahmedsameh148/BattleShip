using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime;
using System.Drawing.Configuration;
using System.IO;
using System.Media;
using WMPLib ;
namespace BattleShip1
{  
    public partial class BattleShip : Form
    {
        WMPLib.WindowsMediaPlayer bethovenMusic = new WMPLib.WindowsMediaPlayer();
                                //variables

        Button button;
        String[][] map1;
        String[][] map2;
        Point p;
        String active;
      //  Color c;
        Bitmap bmb;
        bool start = false;
        char s2 = 'v', s3 = 'v', s32 = 'v', s4 = 'v', s5 = 'v';
        int row = 0, column = 0;
        int check_number_of_ships_are_valid = 0;
        Random rand = new Random(); int size;
        String[] ships = { "ship2", "ship3", "ship32", "ship4", "ship5" };  
        int counter_of_computer = 0, counter_of_player = 0;

        ///////////////////////////////////////////////////////////////////////////////

        public BattleShip()
        {
            InitializeComponent();
            mapp1(); mapp2();
            textBox1.Hide();
            last_target.Hide();
        }

        private void BattleShip_Load(object sender, EventArgs e)
        {
            bethovenMusic.URL = "bethovyn.mp3";
            bethovenMusic.controls.play();
            try
            {
                switch (active)
                {
                    case "ship2":
                        bmb = (Bitmap)ship2.Image;
                        ship2.Image = bmb;
                        break;
                    case "ship3":
                        bmb = (Bitmap)ship3.Image;
                        ship3.Image = bmb;
                        break;
                    case "ship32":
                        bmb = (Bitmap)ship32.Image;
                        ship32.Image = bmb;
                        break;
                    case "ship4":
                        bmb = (Bitmap)ship4.Image;
                        ship4.Image = bmb;
                        break;
                    case "ship5":
                        bmb = (Bitmap)ship5.Image;
                        ship5.Image = bmb;
                        break;
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("File Not Found");
            }
        }

        ////////////////////////////////////////////////////////////////////////////////

                                //Creating Maps
        private void mapp2()
        {
            map2 = new String[20][];
            for (int i = 0; i < 20; i++) { map2[i] = new String[20]; }
            for (int i = 0; i < 20; i++)
            {
                for (int y = 0; y < 20; y++)
                {
                    if (i <= 10 && y <= 10) map2[i][y] = ".";
                    else map2[i][y] = "Outside_The_board";
                }
            }

        }
        private void mapp1()
        {
            map1 = new String[20][];
            for (int i = 0; i < 20; i++) { map1[i] = new String[20]; }

            for (int i = 0; i < 20; i++)
            {
                for (int y = 0; y < 20; y++)
                {
                    if (i <= 10 && y <= 10) map1[i][y] = ".";
                    else map1[i][y] = "Outside_The_board";
                }
            }
        }

        /////////////////////////////////////////////////////////////////////

                                     //Ships Classes

        private void ship2_Click(object sender, EventArgs e)
        {
            if (!start)
            {
                active = "ship2";
                MouseEventArgs me = (MouseEventArgs)e;
                if (me.Button == System.Windows.Forms.MouseButtons.Right && ship2.Location.X >= 405)
                {
                    bmb = (Bitmap)ship2.Image;
                    bmb.RotateFlip(RotateFlipType.Rotate90FlipY);
                    ship2.Image = bmb;
                    int t = ship2.Width; ship2.Width = ship2.Height;
                    ship2.Height = t;
                    if (s2 == 'v') s2 = 'h';
                    else s2 = 'v';
                }
            }
        }

        private void ship3_Click(object sender, EventArgs e)
        {
            if (!start)
            {
                active = "ship3";
                MouseEventArgs me = (MouseEventArgs)e;
                if (me.Button == System.Windows.Forms.MouseButtons.Right && ship3.Location.X >= 405)
                {
                    bmb = (Bitmap)ship3.Image;
                    bmb.RotateFlip(RotateFlipType.Rotate90FlipY);
                    ship3.Image = bmb;
                    int t = ship3.Width; ship3.Width = ship3.Height;
                    ship3.Height = t;
                    if (s3 == 'v') s3 = 'h';
                    else s3 = 'v';
                }
            }
        }

        private void ship32_Click(object sender, EventArgs e)
        {
            if (!start)
            {
                active = "ship32";
                MouseEventArgs me = (MouseEventArgs)e;
                if (me.Button == System.Windows.Forms.MouseButtons.Right && ship32.Location.X >= 405)
                {
                    bmb = (Bitmap)ship32.Image;
                    bmb.RotateFlip(RotateFlipType.Rotate90FlipY);
                    ship32.Image = bmb;
                    int t = ship32.Width; ship32.Width = ship32.Height;
                    ship32.Height = t;
                    if (s32 == 'v') s32 = 'h';
                    else s32 = 'v';
                }
            }
        }

        private void ship4_Click(object sender, EventArgs e)
        {
            if (!start)
            {
                active = "ship4";
                MouseEventArgs me = (MouseEventArgs)e;
                if (me.Button == System.Windows.Forms.MouseButtons.Right && ship4.Location.X >= 405)
                {
                    bmb = (Bitmap)ship4.Image;
                    bmb.RotateFlip(RotateFlipType.Rotate90FlipY);
                    ship4.Image = bmb;
                    int t = ship4.Width; ship4.Width = ship4.Height;
                    ship4.Height = t;
                    if (s4 == 'v') s4 = 'h';
                    else s4 = 'v';
                }
            }
        }
        private void ship5_Click(object sender, EventArgs e)
        {
            if (!start)
            {
                active = "ship5";
                MouseEventArgs me = (MouseEventArgs)e;
                if (me.Button == System.Windows.Forms.MouseButtons.Right && ship5.Location.X >= 405)
                {
                    bmb = (Bitmap)ship5.Image;
                    bmb.RotateFlip(RotateFlipType.Rotate90FlipY);
                    ship5.Image = bmb;
                    int t = ship5.Width; ship5.Width = ship5.Height;
                    ship5.Height = t;
                    if (s5 == 'v') s5 = 'h';
                    else s5 = 'v';
                }
            }
        }


        /////////////////////////////////////////////////////////////////////

        //AI

        private void which_ship(String s) {
            switch (s) {
                case "ship2":
                    size = 2; break;
                case "ship3":
                case "ship32":
                    size = 3; break;
                case "ship4":
                    size = 4; break;
                case "ship5":
                    size = 5; break;
            }
        }

        private void put_ship(int n, String s) {
            int type = rand.Next(1, 3);
            if (type == 1)
            {
                while (true)
                {
                    int roww = rand.Next(1, 10);
                    int columnn = rand.Next(1, 10);
                    bool st = true;
                    for (int i = roww; i < roww + n; i++)
                    {
                        if (map2[i][columnn] != ".") { st = false; break; }
                    }
                    if (st)
                    {
                        for (int i = roww; i < roww + n; i++)
                        {
                            map2[i][columnn] = s;
                        }
                        break;
                    }
                }
            }
            else
            {
                while (true)
                {
                    int roww = rand.Next(1, 10);
                    int columnn = rand.Next(1, 10);
                    bool st = true;
                    for (int i = columnn; i < columnn + n; i++)
                    {
                        if (map2[roww][i] != ".") { st = false; break; }
                    }
                    if (st)
                    {
                        for (int i = columnn; i < columnn + n; i++)
                        {
                            map2[roww][i] = s;
                        }
                        break;
                    }
                }
            }
        }

        private void AI_put_ships() {
            for (int i = 0; i < 5; i++)
            {
                which_ship(ships[i]);
                put_ship(size, ships[i]);
            }
        }

        public void get_target()
        {
            while (true)
            {
                int row = rand.Next(1, 11);
                int column = rand.Next(1, 11);

                if (map1[row][column] != "shooted" && map1[row][column] != "Outside_The_board") {
                    coloring(row, column);
                    if (map1[row][column] != ".")
                    {
                        SoundPlayer sound2_play = new SoundPlayer("Explosion.WAV");
                        sound2_play.Play();
                        counter_of_computer++;
                    }
                    map1[row][column] = "shooted"; break;
                }
            }
            if (counter_of_player == 17)
            {
                this.Hide();
                you_win endpage = new you_win();
                endpage.ShowDialog();
                Application.Exit();
            }
            else if (counter_of_computer == 17)
            {
                this.Hide();
                computer_is_the_winner endpage = new computer_is_the_winner();
                endpage.ShowDialog();
                Application.Exit();
            }
        }

        private void coloring(int i, int y)
        {
            if (i == 1 && y == 1) button = button1;
            else if (i == 2 && y == 1) button = button2;
            else if (i == 3 && y == 1) button = button3;
            else if (i == 4 && y == 1) button = button4;
            else if (i == 5 && y == 1) button = button5;
            else if (i == 6 && y == 1) button = button6;
            else if (i == 7 && y == 1) button = button7;
            else if (i == 8 && y == 1) button = button8;
            else if (i == 9 && y == 1) button = button9;
            else if (i == 10 && y == 1) button = button10;

            else if (i == 1 && y == 2) button = button20;
            else if (i == 2 && y == 2) button = button19;
            else if (i == 3 && y == 2) button = button18;
            else if (i == 4 && y == 2) button = button17;
            else if (i == 5 && y == 2) button = button16;
            else if (i == 6 && y == 2) button = button15;
            else if (i == 7 && y == 2) button = button14;
            else if (i == 8 && y == 2) button = button13;
            else if (i == 9 && y == 2) button = button12;
            else if (i == 10 && y == 2) button = button11;

            else if (i == 1 && y == 3) button = button30;
            else if (i == 2 && y == 3) button = button29;
            else if (i == 3 && y == 3) button = button28;
            else if (i == 4 && y == 3) button = button27;
            else if (i == 5 && y == 3) button = button26;
            else if (i == 6 && y == 3) button = button25;
            else if (i == 7 && y == 3) button = button24;
            else if (i == 8 && y == 3) button = button23;
            else if (i == 9 && y == 3) button = button22;
            else if (i == 10 && y == 3) button = button21;

            else if (i == 1 && y == 4) button = button40;
            else if (i == 2 && y == 4) button = button39;
            else if (i == 3 && y == 4) button = button38;
            else if (i == 4 && y == 4) button = button37;
            else if (i == 5 && y == 4) button = button36;
            else if (i == 6 && y == 4) button = button35;
            else if (i == 7 && y == 4) button = button34;
            else if (i == 8 && y == 4) button = button33;
            else if (i == 9 && y == 4) button = button32;
            else if (i == 10 && y == 4) button = button31;

            else if (i == 1 && y == 5) button = button50;
            else if (i == 2 && y == 5) button = button49;
            else if (i == 3 && y == 5) button = button48;
            else if (i == 4 && y == 5) button = button47;
            else if (i == 5 && y == 5) button = button46;
            else if (i == 6 && y == 5) button = button45;
            else if (i == 7 && y == 5) button = button44;
            else if (i == 8 && y == 5) button = button43;
            else if (i == 9 && y == 5) button = button42;
            else if (i == 10 && y == 5) button = button41;

            else if (i == 1 && y == 6) button = button60;
            else if (i == 2 && y == 6) button = button59;
            else if (i == 3 && y == 6) button = button58;
            else if (i == 4 && y == 6) button = button57;
            else if (i == 5 && y == 6) button = button56;
            else if (i == 6 && y == 6) button = button55;
            else if (i == 7 && y == 6) button = button54;
            else if (i == 8 && y == 6) button = button53;
            else if (i == 9 && y == 6) button = button52;
            else if (i == 10 && y == 6) button = button51;

            else if (i == 1 && y == 7) button = button70;
            else if (i == 2 && y == 7) button = button69;
            else if (i == 3 && y == 7) button = button68;
            else if (i == 4 && y == 7) button = button67;
            else if (i == 5 && y == 7) button = button66;
            else if (i == 6 && y == 7) button = button65;
            else if (i == 7 && y == 7) button = button64;
            else if (i == 8 && y == 7) button = button63;
            else if (i == 9 && y == 7) button = button62;
            else if (i == 10 && y == 7) button = button61;

            else if (i == 1 && y == 8) button = button80;
            else if (i == 2 && y == 8) button = button79;
            else if (i == 3 && y == 8) button = button78;
            else if (i == 4 && y == 8) button = button77;
            else if (i == 5 && y == 8) button = button76;
            else if (i == 6 && y == 8) button = button75;
            else if (i == 7 && y == 8) button = button74;
            else if (i == 8 && y == 8) button = button73;
            else if (i == 9 && y == 8) button = button72;
            else if (i == 10 && y == 8) button = button71;

            else if (i == 1 && y == 9) button = button90;
            else if (i == 2 && y == 9) button = button89;
            else if (i == 3 && y == 9) button = button88;
            else if (i == 4 && y == 9) button = button87;
            else if (i == 5 && y == 9) button = button86;
            else if (i == 6 && y == 9) button = button85;
            else if (i == 7 && y == 9) button = button84;
            else if (i == 8 && y == 9) button = button83;
            else if (i == 9 && y == 9) button = button82;
            else if (i == 10 && y == 9) button = button81;

            else if (i == 1 && y == 10) button = button100;
            else if (i == 2 && y == 10) button = button99;
            else if (i == 3 && y == 10) button = button98;
            else if (i == 4 && y == 10) button = button97;
            else if (i == 5 && y == 10) button = button96;
            else if (i == 6 && y == 10) button = button95;
            else if (i == 7 && y == 10) button = button94;
            else if (i == 8 && y == 10) button = button93;
            else if (i == 9 && y == 10) button = button92;
            else if (i == 10 && y == 10) button = button91;

            if (map1[i][y] == ".") { button.BackColor = Color.FromArgb(255, 255, 255); }
            else
            {
                button.BackColor = Color.FromArgb(128, 0, 0); }
        }

        ////////////////////////////////////////////////////////////////

        //Move Ships Of The Player
        public void move_ship()
        {
            row = p.Y / 40; column = p.X / 40;
            p.X += 2; p.Y += 2;
            switch (active)
            {
                case "ship2":
                    if (s2 == 'v')
                    {
                        bool st = true;
                        for (int i = row; i < row + 2; i++) { if (map1[i][column] != "." && map1[i][column] != "ship2") { st = false; break; } }
                        if (!st) MessageBox.Show("Invalid Position");
                        else
                        {
                            for (int i = 0; i <= 10; i++)
                            {
                                for (int y = 0; y <= 10; y++)
                                {
                                    if (map1[i][y] == "ship2") map1[i][y] = ".";
                                }
                            }
                            ship2.Location = p; active = ".";
                            for (int i = row; i < row + 2; i++) map1[i][column] = "ship2";
                        }

                    }
                    else
                    {
                        bool st = true;
                        for (int i = column; i < column + 2; i++) { if (map1[row][i] != ".") { st = false; break; } }
                        if (!st) MessageBox.Show("Invalid Position");
                        else
                        {
                            for (int i = 0; i <= 10; i++)
                            {
                                for (int y = 0; y <= 10; y++)
                                {
                                    if (map1[i][y] == "ship2") map1[i][y] = ".";
                                }
                            }
                            ship2.Location = p; active = ".";
                            for (int i = column; i < column + 2; i++) map1[row][i] = "ship2";
                        }
                    }
                    break;
                case "ship3":
                    if (s3 == 'v')
                    {
                        bool st = true;
                        for (int i = row; i < row + 3; i++) { if (map1[i][column] != ".") { st = false; break; } }
                        if (!st) MessageBox.Show("Invalid Position");
                        else
                        {
                            for (int i = 0; i <= 10; i++)
                            {
                                for (int y = 0; y <= 10; y++)
                                {
                                    if (map1[i][y] == "ship3") map1[i][y] = ".";
                                }
                            }
                            ship3.Location = p; active = ".";
                            for (int i = row; i < row + 3; i++) map1[i][column] = "ship3";
                        }
                    }
                    else
                    {
                        bool st = true;
                        for (int i = column; i < column + 3; i++) { if (map1[row][i] != ".") { st = false; break; } }
                        if (!st) MessageBox.Show("Invalid Position");
                        else
                        {
                            for (int i = 0; i <= 10; i++)
                            {
                                for (int y = 0; y <= 10; y++)
                                {
                                    if (map1[i][y] == "ship3") map1[i][y] = ".";
                                }
                            }
                            ship3.Location = p; active = ".";
                            for (int i = column; i < column + 3; i++) map1[row][i] = "ship3";
                        }
                    }
                    break;
                case "ship32":
                    if (s32 == 'v')
                    {
                        bool st = true;
                        for (int i = row; i < row + 3; i++) { if (map1[i][column] != ".") { st = false; break; } }
                        if (!st) MessageBox.Show("Invalid Position");
                        else
                        {
                            for (int i = 0; i <= 10; i++)
                            {
                                for (int y = 0; y <= 10; y++)
                                {
                                    if (map1[i][y] == "ship32") map1[i][y] = ".";
                                }
                            }
                            ship32.Location = p; active = ".";
                            for (int i = row; i < row + 3; i++) map1[i][column] = "ship32";
                        }
                    }
                    else
                    {
                        bool st = true;
                        for (int i = column; i < column + 3; i++) { if (map1[row][i] != ".") { st = false; break; } }
                        if (!st) MessageBox.Show("Invalid Position");
                        else
                        {
                            for (int i = 0; i <= 10; i++)
                            {
                                for (int y = 0; y <= 10; y++)
                                {
                                    if (map1[i][y] == "ship32") map1[i][y] = ".";
                                }
                            }
                            ship32.Location = p; active = ".";
                            for (int i = column; i < column + 3; i++) map1[row][i] = "ship32";
                        }
                    }
                    break;
                case "ship4":
                    if (s4 == 'v')
                    {
                        bool st = true;
                        for (int i = row; i < row + 4; i++) { if (map1[i][column] != ".") { st = false; break; } }
                        if (!st) MessageBox.Show("Invalid Position");
                        else
                        {
                            for (int i = 0; i <= 10; i++)
                            {
                                for (int y = 0; y <= 10; y++)
                                {
                                    if (map1[i][y] == "ship4") map1[i][y] = ".";
                                }
                            }
                            ship4.Location = p; active = ".";
                            for (int i = row; i < row + 4; i++) map1[i][column] = "ship4";
                        }
                    }
                    else
                    {
                        bool st = true;
                        for (int i = column; i < column + 4; i++) { if (map1[row][i] != ".") { st = false; break; } }
                        if (!st) MessageBox.Show("Invalid Position");
                        else
                        {
                            for (int i = 0; i <= 10; i++)
                            {
                                for (int y = 0; y <= 10; y++)
                                {
                                    if (map1[i][y] == "ship4") map1[i][y] = ".";
                                }
                            }
                            ship4.Location = p; active = ".";
                            for (int i = column; i < column + 4; i++) map1[row][i] = "ship4";
                        }
                    }
                    break;
                case "ship5":
                    if (s5 == 'v')
                    {
                        bool st = true;
                        for (int i = row; i < row + 5; i++) { if (map1[i][column] != ".") { st = false; break; } }
                        if (!st) MessageBox.Show("Invalid Position");
                        else
                        {
                            for (int i = 0; i <= 10; i++)
                            {
                                for (int y = 0; y <= 10; y++)
                                {
                                    if (map1[i][y] == "ship5") map1[i][y] = ".";
                                }
                            }
                            ship5.Location = p; active = ".";
                            for (int i = row; i < row + 5; i++) map1[i][column] = "ship5";
                        }
                    }
                    else
                    {
                        bool st = true;
                        for (int i = column; i < column + 5; i++) { if (map1[row][i] != ".") { st = false; break; } }
                        if (!st) MessageBox.Show("Invalid Position");
                        else
                        {
                            for (int i = 0; i <= 10; i++)
                            {
                                for (int y = 0; y <= 10; y++)
                                {
                                    if (map1[i][y] == "ship5") map1[i][y] = ".";
                                }
                            }
                            ship5.Location = p; active = ".";
                            for (int i = column; i < column + 5; i++) map1[row][i] = "ship5";
                        }
                    }
                    break;
            }
        }

        public void Target(int i, int y) {
            if (map2[i][y] == "ship2")
            {
                map2[i][y] = "shooted";
                bmb = (Bitmap)ship2.Image;
                if (s2 == 'v') { bmb.RotateFlip(RotateFlipType.Rotate90FlipY); s2 = 'h'; }
                last_target.Image = bmb;
                last_target.Width = 80;
                last_target.Show(); textBox1.Show();
                counter_of_player++;
            }
            else if (map2[i][y] == "ship3")
            {
                map2[i][y] = "shooted";
                bmb = (Bitmap)ship3.Image;
                if (s3 == 'v') { bmb.RotateFlip(RotateFlipType.Rotate90FlipY); s3 = 'h'; }
                last_target.Image = bmb;
                last_target.Width = 120;
                last_target.Show(); textBox1.Show();
                counter_of_player++;
            }
            else if (map2[i][y] == "ship32")
            {
                map2[i][y] = "shooted";
                bmb = (Bitmap)ship32.Image;
                if (s32 == 'v') { bmb.RotateFlip(RotateFlipType.Rotate90FlipY); s32 = 'h'; }
                last_target.Image = bmb;
                last_target.Width = 120;
                last_target.Show(); textBox1.Show();
                counter_of_player++;
            }
            else if (map2[i][y] == "ship4")
            {
                map2[i][y] = "shooted";
                bmb = (Bitmap)ship4.Image;
                if (s4 == 'v') { bmb.RotateFlip(RotateFlipType.Rotate90FlipY); s4 = 'h'; }
                last_target.Image = bmb;
                last_target.Width = 160;
                last_target.Show(); textBox1.Show();
                counter_of_player++;
            }
            else if (map2[i][y] == "ship5")
            {
                map2[i][y] = "shooted";
                bmb = (Bitmap)ship5.Image;
                if (s5 == 'v') { bmb.RotateFlip(RotateFlipType.Rotate90FlipY); s5 = 'h'; }
                last_target.Image = bmb;
                last_target.Width = 200;
                last_target.Show(); textBox1.Show();
                counter_of_player++;
            }

            
        }
        //////////////////////////////////////////////////////////////////////////////////
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            p.Y = 42; p.X = 42;
            move_ship();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            p.Y = 42; p.X = 82;
            move_ship();
        }

        private void button38_Click(object sender, EventArgs e)
        {
            p.Y = 122; p.X = 162;
            move_ship();
        }

        private void button56_Click(object sender, EventArgs e)
        {
            p.Y = 202; p.X = 242;
            move_ship();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            p.Y = 402; p.X = 82;
            move_ship();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            p.Y = 402; p.X = 122;
            move_ship();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            p.Y = 402; p.X = 162;
            move_ship();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            p.Y = 402; p.X = 42;
            move_ship();
        }

        private void button57_Click(object sender, EventArgs e)
        {
            p.Y = 162; p.X = 242;
            move_ship();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            p.Y = 42; p.X = 122;
            move_ship();
        }

        private void button40_Click(object sender, EventArgs e)
        {
            p.X = 162; p.Y = 42;
            move_ship();
        }

        private void button41_Click(object sender, EventArgs e)
        {
            p.Y = 402; p.X = 202;
            move_ship();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            p.Y = 82; p.X = 42;
            move_ship();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            p.Y = 122; p.X = 42;
            move_ship();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            p.Y = 162; p.X = 42;
            move_ship();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            p.Y = 202; p.X = 42;
            move_ship();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            p.Y = 242; p.X = 42;
            move_ship();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            p.Y = 282; p.X = 42;
            move_ship();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            p.Y = 322; p.X = 42;
            move_ship();
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            p.Y = 362; p.X = 42;
            move_ship();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            p.Y = 82; p.X = 82;
            move_ship();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            p.Y = 122; p.X = 82;
            move_ship();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            p.Y = 162; p.X = 82;
            move_ship();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            p.Y = 202; p.X = 82;
            move_ship();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            p.Y = 242; p.X = 82;
            move_ship();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            p.Y = 282; p.X = 82;
            move_ship();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            p.Y = 322; p.X = 82;
            move_ship();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            p.Y = 362; p.X = 82;
            move_ship();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            p.Y = 82; p.X = 122;
            move_ship();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            p.Y = 122; p.X = 122;
            move_ship();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            p.Y = 162; p.X = 122;
            move_ship();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            p.Y = 202; p.X = 122;
            move_ship();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            p.Y = 242; p.X = 122;
            move_ship();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            p.Y = 282; p.X = 122;
            move_ship();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            p.Y = 322; p.X = 122;
            move_ship();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            p.Y = 362; p.X = 122;
            move_ship();
        }

        private void button39_Click(object sender, EventArgs e)
        {
            p.Y = 82; p.X = 162;
            move_ship();
        }

        private void button37_Click(object sender, EventArgs e)
        {
            p.Y = 162; p.X = 162;
            move_ship();
        }

        private void button36_Click(object sender, EventArgs e)
        {
            p.Y = 202; p.X = 162;
            move_ship();
        }

        private void button35_Click(object sender, EventArgs e)
        {
            p.Y = 242; p.X = 162;
            move_ship();
        }

        private void button34_Click(object sender, EventArgs e)
        {
            p.Y = 282; p.X = 162;
            move_ship();
        }

        private void button33_Click(object sender, EventArgs e)
        {
            p.Y = 322; p.X = 162;
            move_ship();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            p.Y = 362; p.X = 162;
            move_ship();
        }

        private void button50_Click(object sender, EventArgs e)
        {
            p.Y = 42; p.X = 202;
            move_ship();
        }

        private void button49_Click(object sender, EventArgs e)
        {
            p.Y = 82; p.X = 202;
            move_ship();
        }

        private void button48_Click(object sender, EventArgs e)
        {
            p.Y = 122; p.X = 202;
            move_ship();
        }

        private void button47_Click(object sender, EventArgs e)
        {
            p.Y = 162; p.X = 202;
            move_ship();
        }

        private void button46_Click(object sender, EventArgs e)
        {
            p.Y = 202; p.X = 202;
            move_ship();
        }

        private void button45_Click(object sender, EventArgs e)
        {
            p.Y = 242; p.X = 202;
            move_ship();
        }

        private void button44_Click(object sender, EventArgs e)
        {
            p.Y = 282; p.X = 202;
            move_ship();
        }

        private void button43_Click(object sender, EventArgs e)
        {
            p.Y = 322; p.X = 202;
            move_ship();
        }

        private void button42_Click(object sender, EventArgs e)
        {
            p.Y = 362; p.X = 202;
            move_ship();
        }

        private void button60_Click(object sender, EventArgs e)
        {
            p.Y = 42; p.X = 242;
            move_ship();
        }

        private void button59_Click(object sender, EventArgs e)
        {
            p.Y = 82; p.X = 242;
            move_ship();
        }

        private void button58_Click(object sender, EventArgs e)
        {
            p.Y = 122; p.X = 242;
            move_ship();
        }

        private void button55_Click(object sender, EventArgs e)
        {
            p.Y = 242; p.X = 242;
            move_ship();
        }

        private void button54_Click(object sender, EventArgs e)
        {
            p.Y = 282; p.X = 242;
            move_ship();
        }

        private void button53_Click(object sender, EventArgs e)
        {
            p.Y = 322; p.X = 242;
            move_ship();
        }

        private void button52_Click(object sender, EventArgs e)
        {
            p.Y = 362; p.X = 242;
            move_ship();
        }

        private void button51_Click(object sender, EventArgs e)
        {
            p.Y = 402; p.X = 242;
            move_ship();
        }

        private void button70_Click(object sender, EventArgs e)
        {
            p.Y = 42; p.X = 282;
            move_ship();
        }

        private void button69_Click(object sender, EventArgs e)
        {
            p.Y = 82; p.X = 282;
            move_ship();
        }

        private void button68_Click(object sender, EventArgs e)
        {
            p.Y = 122; p.X = 282;
            move_ship();
        }

        private void button67_Click(object sender, EventArgs e)
        {
            p.Y = 162; p.X = 282;
            move_ship();
        }

        private void button66_Click(object sender, EventArgs e)
        {
            p.Y = 202; p.X = 282;
            move_ship();
        }

        private void button65_Click(object sender, EventArgs e)
        {
            p.Y = 242; p.X = 282;
            move_ship();
        }

        private void button64_Click(object sender, EventArgs e)
        {
            p.Y = 282; p.X = 282;
            move_ship();
        }

        private void button63_Click(object sender, EventArgs e)
        {
            p.Y = 322; p.X = 282;
            move_ship();
        }

        private void button62_Click(object sender, EventArgs e)
        {
            p.Y = 362; p.X = 282;
            move_ship();
        }

        private void button61_Click(object sender, EventArgs e)
        {
            p.Y = 402; p.X = 282;
            move_ship();
        }

        private void button80_Click(object sender, EventArgs e)
        {
            p.Y = 42; p.X = 322;
            move_ship();
        }

        private void button79_Click(object sender, EventArgs e)
        {
            p.Y = 82; p.X = 322;
            move_ship();
        }

        private void button78_Click(object sender, EventArgs e)
        {
            p.Y = 122; p.X = 322;
            move_ship();
        }

        private void button77_Click(object sender, EventArgs e)
        {
            p.Y = 162; p.X = 322;
            move_ship();
        }

        private void button76_Click(object sender, EventArgs e)
        {
            p.Y = 202; p.X = 322;
            move_ship();
        }

        private void button75_Click(object sender, EventArgs e)
        {
            p.Y = 242; p.X = 322;
            move_ship();
        }

        private void button74_Click(object sender, EventArgs e)
        {
            p.Y = 282; p.X = 322;
            move_ship();
        }

        private void button73_Click(object sender, EventArgs e)
        {
            p.Y = 322; p.X = 322;
            move_ship();
        }

        private void button72_Click(object sender, EventArgs e)
        {
            p.Y = 362; p.X = 322;
            move_ship();
        }

        private void button71_Click(object sender, EventArgs e)
        {
            p.Y = 402; p.X = 322;
            move_ship();
        }

        private void button90_Click(object sender, EventArgs e)
        {
            p.Y = 42; p.X = 362;
            move_ship();
        }

        private void button89_Click(object sender, EventArgs e)
        {
            p.Y = 82; p.X = 362;
            move_ship();
        }

        private void button88_Click(object sender, EventArgs e)
        {
            p.Y = 122; p.X = 362;
            move_ship();
        }

        private void button87_Click(object sender, EventArgs e)
        {
            p.Y = 162; p.X = 362;
            move_ship();
        }

        private void button86_Click(object sender, EventArgs e)
        {
            p.Y = 202; p.X = 362;
            move_ship();
        }

        private void button85_Click(object sender, EventArgs e)
        {
            p.Y = 242; p.X = 362;
            move_ship();
        }

        private void button84_Click(object sender, EventArgs e)
        {
            p.Y = 282; p.X = 362;
            move_ship();
        }

        private void button83_Click(object sender, EventArgs e)
        {
            p.Y = 322; p.X = 362;
            move_ship();
        }

        private void button82_Click(object sender, EventArgs e)
        {
            p.Y = 362; p.X = 362;
            move_ship();
        }

        private void button81_Click(object sender, EventArgs e)
        {
            p.Y = 402; p.X = 362;
            move_ship();
        }

        private void button100_Click(object sender, EventArgs e)
        {
            p.Y = 42; p.X = 402;
            move_ship();
        }

        private void button99_Click(object sender, EventArgs e)
        {
            p.Y = 82; p.X = 402;
            move_ship();
        }

        private void button98_Click(object sender, EventArgs e)
        {
            p.Y = 122; p.X = 402;
            move_ship();
        }

        private void button97_Click(object sender, EventArgs e)
        {
            p.Y = 162; p.X = 402;
            move_ship();
        }

        private void button96_Click(object sender, EventArgs e)
        {
            p.Y = 202; p.X = 402;
            move_ship();
        }

        private void button199_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(2, 1);
                button199.Enabled = false;
                if (map2[2][1] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button199.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button199.BackColor = Color.FromArgb(128, 0, 0);

                }  get_target();
              
            }
        }

        private void button198_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(3, 1);
                button198.Enabled = false;
                if (map2[3][1] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button198.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button198.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();
            }
        }

        private void button197_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(4, 1);
                button200.Enabled = false;
                if (map2[4][1] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button197.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button197.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();
            }
        }

        private void button196_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(5, 1);
                button196.Enabled = false;
                if (map2[5][1] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button196.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button196.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();
            }
        }

        private void button195_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(6, 1);
                button195.Enabled = false;
                if (map2[6][1] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button195.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button195.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();
            }
        }

        private void button194_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(7, 1);
                button194.Enabled = false;
                if (map2[7][1] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button194.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button194.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();
            }
        }

        private void button193_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(8, 1);
                button193.Enabled = false;
                if (map2[8][1] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button193.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button193.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();
            }
        }

        private void button192_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(9, 1);
                button192.Enabled = false;
                if (map2[9][1] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button192.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button192.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();
            }
        }

        private void button191_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(10, 1);
                button191.Enabled = false;
                if (map2[10][1] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play();
                    button191.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button191.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();
            }
        }

        private void button190_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(1, 2);
                button190.Enabled = false;
                if (map2[1][2] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play();
                    button190.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    button190.BackColor = Color.FromArgb(128, 0, 0);
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                }
                get_target();
            }
        }

        private void button189_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(2, 2);
                button189.Enabled = false;
                if (map2[1][3] == ".") button189.BackColor = Color.FromArgb(255, 255, 255);
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button189.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();
            }
        }

        private void button188_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(3, 2);
                button188.Enabled = false;
                if (map2[3][2] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button188.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button188.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();
            }
        }

        private void button187_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(4, 2);
                button187.Enabled = false;
                if (map2[4][2] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button187.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button187.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();
            }
        }

        private void button186_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(5, 2);
                button186.Enabled = false;
                if (map2[5][2] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button186.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button186.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();
            }
        }

        private void button185_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(6, 2);
                button185.Enabled = false;
                if (map2[6][2] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button185.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button185.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();
            }
        }

        private void button184_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(7, 2);
                button184.Enabled = false;
                if (map2[7][2] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button184.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button184.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();
            }
        }

        private void button183_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(8, 2);
                button183.Enabled = false;
                if (map2[8][2] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button183.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button183.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();
            }
        }

        private void button182_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(9, 2);
                button182.Enabled = false;
                if (map2[9][2] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button182.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button182.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();
            }
        }

        private void button181_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(10, 2);
                button181.Enabled = false;
                if (map2[10][2] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play();
                    button181.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button181.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();
            }
        }

        private void button180_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(1, 3);
                button180.Enabled = false;
                if (map2[1][3] == ".") button180.BackColor = Color.FromArgb(255, 255, 255);
                else button180.BackColor = Color.FromArgb(128, 0, 0);
                get_target();
            }
        }

        private void button179_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(2, 3);
                button179.Enabled = false;
                if (map2[2][3] == ".") button179.BackColor = Color.FromArgb(255, 255, 255);
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button179.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();
            }
        }

        private void button178_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(3, 3);
                button178.Enabled = false;
                if (map2[3][3] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button178.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button178.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();
            }
        }

        private void button177_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(4, 3);
                button177.Enabled = false;
                if (map2[4][3] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button177.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button177.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();
            }
        }

        private void button176_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(5, 3);
                button176.Enabled = false;
                if (map2[5][3] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button176.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button176.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();
            }
        }

        private void button175_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(6, 3);
                button175.Enabled = false;
                if (map2[6][3] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button175.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button175.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button174_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(7, 3);
                button174.Enabled = false;
                if (map2[7][3] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button174.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button174.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button173_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(8, 3);
                button173.Enabled = false;
                if (map2[8][3] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button173.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button173.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button172_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(9, 3);
                button172.Enabled = false;
                if (map2[9][3] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button172.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button172.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button171_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(10, 3);
                button171.Enabled = false;
                if (map2[10][3] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button171.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button171.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button170_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(1, 4);
                button170.Enabled = false;
                if (map2[1][4] == ".")
                { SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button170.BackColor = Color.FromArgb(255, 255, 255);}
                else
                {
                    button170.BackColor = Color.FromArgb(128, 0, 0);
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                }
                get_target();

            }
        }

        private void button169_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(2, 4);
                button169.Enabled = false;
                if (map2[2][4] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button169.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button169.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button168_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(3, 4);
                button168.Enabled = false;
                if (map2[3][4] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button168.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button168.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button167_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(4, 4);
                button167.Enabled = false;
                if (map2[4][4] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button167.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button167.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button166_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(5, 4);
                button166.Enabled = false;
                if (map2[5][4] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button166.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button166.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }

        }

        private void button165_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(6, 4);
                button165.Enabled = false;
                if (map2[6][4] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button165.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button165.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button164_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(7, 4);
                button164.Enabled = false;
                if (map2[7][4] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button164.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button164.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button163_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(8, 4);
                button163.Enabled = false;
                if (map2[8][4] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button163.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button163.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button162_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(9, 4);
                button162.Enabled = false;
                if (map2[9][4] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button162.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button162.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button161_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(10, 4);
                button161.Enabled = false;
                if (map2[10][4] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button161.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button161.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button160_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(1, 5);
                button160.Enabled = false;
                if (map2[1][5] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button160.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    button160.BackColor = Color.FromArgb(128, 0, 0);
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                }
                get_target();

            }
        }

        private void button159_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(2, 5);
                button159.Enabled = false;
                if (map2[2][5] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button159.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button159.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button158_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(3, 5);
                button158.Enabled = false;
                if (map2[3][5] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button158.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button158.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button157_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(4, 5);
                button157.Enabled = false;
                if (map2[4][5] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button157.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button157.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button156_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(5, 5);
                button156.Enabled = false;
                if (map2[5][5] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button156.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button156.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button155_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(6, 5);
                button155.Enabled = false;
                if (map2[6][5] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button155.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button155.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button154_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(7, 5);
                button154.Enabled = false;
                if (map2[7][5] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button154.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button154.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button153_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(8, 5);
                button153.Enabled = false;
                if (map2[8][5] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button153.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button153.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button152_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(9, 5);
                button152.Enabled = false;
                if (map2[9][5] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button152.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button152.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button151_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(10, 5);
                button151.Enabled = false;
                if (map2[10][5] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button151.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button151.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button150_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(1, 6);
                button150.Enabled = false;
                if (map2[1][6] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button150.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    button150.BackColor = Color.FromArgb(128, 0, 0);
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                }
                get_target();

            }
        }

        private void button149_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(2, 6);
                button149.Enabled = false;
                if (map2[2][6] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button149.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button149.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button148_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(3, 6);
                button148.Enabled = false;
                if (map2[3][6] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button148.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button148.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button147_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(4, 6);
                button147.Enabled = false;
                if (map2[4][6] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button147.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button147.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button146_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(5, 6);
                button146.Enabled = false;
                if (map2[5][6] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button146.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button146.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button145_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(6, 6);
                button145.Enabled = false;
                if (map2[6][6] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button145.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button145.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button144_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(7, 6);
                button144.Enabled = false;
                if (map2[7][6] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button144.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button144.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button143_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(8, 6);
                button143.Enabled = false;
                if (map2[8][6] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button143.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button143.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button142_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(9, 6);
                button142.Enabled = false;
                if (map2[9][6] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button142.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button142.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button141_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(10, 6);
                button141.Enabled = false;
                if (map2[10][6] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button141.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button141.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button140_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(1, 7);
                button140.Enabled = false;
                if (map2[1][7] == ".") button140.BackColor = Color.FromArgb(255, 255, 255);
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play(); button140.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button139_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(2, 7);
                button139.Enabled = false;
                if (map2[2][7] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button139.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button139.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button138_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(3, 7);
                button138.Enabled = false;
                if (map2[3][7] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button138.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button138.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button137_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(4, 7);
                button137.Enabled = false;
                if (map2[4][7] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button137.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button137.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button136_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(5, 7);
                button136.Enabled = false;
                if (map2[5][7] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button136.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button136.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button135_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(6, 7);
                button135.Enabled = false;
                if (map2[6][7] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button135.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button135.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button134_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(7, 7);
                button134.Enabled = false;
                if (map2[7][7] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button134.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button134.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button133_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(8, 7);
                button133.Enabled = false;
                if (map2[8][7] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button133.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button133.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button132_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(9, 7);
                button132.Enabled = false;
                if (map2[9][7] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button132.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button132.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button131_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(10, 7);
                button131.Enabled = false;
                if (map2[10][7] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button131.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button131.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button130_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(1, 8);
                button130.Enabled = false;
                if (map2[1][8] == "."){ SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button130.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play(); button130.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button129_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(2, 8);
                button129.Enabled = false;
                if (map2[2][8] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button129.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button129.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button128_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(3, 8);
                button128.Enabled = false;
                if (map2[3][8] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button128.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button128.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button127_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(4, 8);
                button127.Enabled = false;
                if (map2[4][8] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button127.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button127.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button126_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(5, 8);
                button126.Enabled = false;
                if (map2[5][8] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button126.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button126.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button125_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(6, 8);
                button125.Enabled = false;
                if (map2[6][8] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button125.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button125.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button124_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(7, 8);
                button124.Enabled = false;
                if (map2[7][8] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button124.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button124.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button123_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(8, 8);
                button123.Enabled = false;
                if (map2[8][8] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button123.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button123.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button122_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(9, 8);
                button122.Enabled = false;
                if (map2[9][8] == ".")
                { SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button122.BackColor = Color.FromArgb(255, 255, 255);}
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button122.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button121_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(10, 8);
                button121.Enabled = false;
                if (map2[10][8] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button121.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button121.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button120_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(1, 9);
                button120.Enabled = false;
                if (map2[1][9] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button120.BackColor = Color.FromArgb(255, 255, 255);
                }
                else button120.BackColor = Color.FromArgb(128, 0, 0);
                get_target();

            }
        }

        private void button119_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(2, 9);
                button119.Enabled = false;
                if (map2[2][9] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button119.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button119.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button118_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(3, 9);
                button118.Enabled = false;
                if (map2[3][9] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button118.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button118.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button117_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(4, 9);
                button117.Enabled = false;
                if (map2[4][9] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button117.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button117.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button116_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(5, 9);
                button116.Enabled = false;
                if (map2[5][9] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button116.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button116.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button115_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(6, 9);
                button115.Enabled = false;
                if (map2[6][9] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button115.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button115.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button114_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(7, 9);
                button114.Enabled = false;
                if (map2[7][9] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button114.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button114.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button113_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(8, 9);
                button113.Enabled = false;
                if (map2[8][9] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button113.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button113.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button112_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(9, 9);
                button112.Enabled = false;
                if (map2[9][9] == ".") button112.BackColor = Color.FromArgb(255, 255, 255);
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button112.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button111_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(10, 9);
                button111.Enabled = false;
                if (map2[10][9] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button111.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button111.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button110_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(1, 10);
                button110.Enabled = false;
                if (map2[1][10] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button110.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    button110.BackColor = Color.FromArgb(128, 0, 0);
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                }
                get_target();

            }
        }

        private void button109_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(2, 10);
                button109.Enabled = false;
                if (map2[2][10] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button109.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button109.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button108_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(3, 10);
                button108.Enabled = false;
                if (map2[3][10] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button108.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button108.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button107_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(4, 10);
                button107.Enabled = false;
                if (map2[4][10] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button107.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button107.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button106_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(5, 10);
                button106.Enabled = false;
                if (map2[5][10] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button106.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button106.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button105_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(6, 10);
                button105.Enabled = false;
                if (map2[6][10] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button105.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button105.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button104_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(7, 10);
                button104.Enabled = false;
                if (map2[7][10] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button104.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button104.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button103_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(8, 10);
                button103.Enabled = false;
                if (map2[8][10] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button103.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button103.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button102_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(9, 10);
                button102.Enabled = false;
                if (map2[9][10] == ".") button102.BackColor = Color.FromArgb(255, 255, 255);
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button102.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button101_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(10, 10);
                button101.Enabled = false;
                if (map2[10][10] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play(); button101.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                    button101.BackColor = Color.FromArgb(128, 0, 0);
                }
                get_target();

            }
        }

        private void button95_Click(object sender, EventArgs e)
        {
            p.Y = 242; p.X = 402;
            move_ship();
        }

        private void button94_Click(object sender, EventArgs e)
        {
            p.Y = 282; p.X = 402;
            move_ship();
        }

        private void button93_Click(object sender, EventArgs e)
        {
            p.Y = 322; p.X = 402;
            move_ship();
        }

        private void button92_Click(object sender, EventArgs e)
        {
            p.Y = 362; p.X = 402;
            move_ship();
        }

        private void button91_Click(object sender, EventArgs e)
        {
            p.Y = 402; p.X = 402;
            move_ship();
        }



        private void button200_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Target(1, 1);
                button200.Enabled = false;
                if (map2[1][1] == ".")
                {
                    SoundPlayer sound2_play = new SoundPlayer("water sound.WAV");
                    sound2_play.Play();
                    button200.BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    button200.BackColor = Color.FromArgb(128, 0, 0);
                    SoundPlayer sound_play = new SoundPlayer("Explosion.WAV");
                    sound_play.Play();
                }
                    get_target();
                }
            }


        private void start_battle_Click(object sender, EventArgs e) {
            if (ship2.Location.X < 405 && ship2.Location.Y < 405) check_number_of_ships_are_valid++;
            if (ship3.Location.X < 405 && ship3.Location.Y < 405) check_number_of_ships_are_valid++;
            if (ship32.Location.X < 405 && ship32.Location.Y < 405) check_number_of_ships_are_valid++;
            if (ship4.Location.X < 405 && ship4.Location.Y < 405) check_number_of_ships_are_valid++;
            if (ship5.Location.X < 405 && ship5.Location.Y < 405) check_number_of_ships_are_valid++;

            if (check_number_of_ships_are_valid == 5)
            {
                AI_put_ships();
                start = true;
                active = ".";
                start_battle.Hide();
                pictureBox2.Hide();
                button201.Hide();
                label1.Hide();
            }
            else {
                check_number_of_ships_are_valid = 0;
                MessageBox.Show("Please Put All The Ships Into The Map");
            }
            
        }

        private void button201_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button201_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("you Sould put your Ships in The Left map and in the Right positions and you can not rr5otate after put it in map .. and press in Start battle then \n enjoy ..(: ");
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }
        
    }

}
