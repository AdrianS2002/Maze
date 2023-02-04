using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P1_Schiop_Adrian
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            lbl_vieti.Text = Convert.ToString(vieti);
        }

        bool st, dr, sus, jos;
        int viteza = 10,i=1,j=1;
        int vieti = 5;
        int timpramas = 30;
        int spd = 7;
        int spd1 = 9;

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btn_iesire_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            if(timpramas !=0)
            {
                timpramas--;
                lbl_time.Text = Convert.ToString(timpramas);

            }
        }
        
        
       

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (inamic1.Right >= z2.Left || inamic1.Left <= x1.Right)
            {
                spd = -spd;
                inamic1.Image.RotateFlip(RotateFlipType.Rotate180FlipY);
            }
            inamic1.Left += spd;
            if(inamic1.Bounds.IntersectsWith(player.Bounds))
            {
                vieti--;
                lbl_vieti.Text = Convert.ToString(vieti);
                player.Top = inamic1.Bottom + 5;
            }
            //
            if (dusman.Right >= z0.Left || dusman.Left <= x0.Right)
            {
                spd1 = -spd1;
                dusman.Image.RotateFlip(RotateFlipType.Rotate180FlipY);
            }
            dusman.Left += spd1;
            if (dusman.Bounds.IntersectsWith(player.Bounds))
            {
                vieti--;
                lbl_vieti.Text = Convert.ToString(vieti);
                player.Top = dusman.Bottom + 5;
            }
            
            if (st == true)
            {
                if (i == 1)
                {
                    player.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    i--;
                }
                foreach (Control x in this.Controls)
                {
                    if ((string)x.Tag == "ziduri")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            vieti--;
                            lbl_vieti.Text = Convert.ToString(vieti);
                            st = false;
                            player.Left = player.Left + 15;
                        }
                    }
                }
              
                    player.Left = player.Left - viteza;
                
            }
            if (dr == true)
            {
                if (i == 0)
                {
                    player.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    i++;
                }
                foreach (Control x in this.Controls)
                {
                    if ((string)x.Tag == "ziduri")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            vieti--;
                            lbl_vieti.Text = Convert.ToString(vieti);
                            dr = false;
                            player.Left = player.Left - 15;
                        }
                    }
                }
                
                    player.Left = player.Left + viteza;
                
            }
            //aici
            if (sus == true)
            {
                /*if (player.Top<=34)
                {
                    player.Top = player.Top + 2;
                    vieti--;
                    lbl_vieti.Text = Convert.ToString(vieti);
                    sus = false;
                }*/
                foreach (Control x in this.Controls)
                {
                    if ((string)x.Tag == "ziduri")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            vieti--;
                            lbl_vieti.Text = Convert.ToString(vieti);
                            sus = false;
                            player.Top = player.Top + 15;
                        }
                    }
                }
                player.Top = player.Top - viteza;
            }
            if (jos == true)
            {
                foreach (Control x in this.Controls)
                {
                    if ((string)x.Tag == "ziduri")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            vieti--;
                            lbl_vieti.Text = Convert.ToString(vieti);
                            jos = false;
                            player.Top = player.Top - 15;
                        }
                    }
                }
               
                 player.Top = player.Top + viteza;
            }
            if (vieti == 0)
            {
                timer1.Enabled = false;
                MessageBox.Show("GAME OVER!");
            }
            if(player.Bounds.IntersectsWith(finish.Bounds))
            {
                timer1.Enabled = false;
                lbl_final.Visible = true;
            }

                 
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            timpramas--;
            lbl_time.Text = Convert.ToString(timpramas);
            if (timpramas == 0)
                MessageBox.Show("Ati pierdut!");

        }
        
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
           
                st = true;
           
            if (e.KeyCode == Keys.Right)
                dr = true;
         
                if (e.KeyCode == Keys.Up)
                sus = true;
            if (e.KeyCode == Keys.Down)
                jos = true;
            
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left)
                st = false;
            if (e.KeyCode == Keys.Right)
                dr = false;
            if (e.KeyCode == Keys.Up)
                sus = false;
            if (e.KeyCode == Keys.Down)
                jos = false;
        }
    }
}
