using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace g2048
{
    public partial class Form1 : Form
    {
        Label[,] game_board;
        int n = 4;
        int r_x, r_y;
        string r;
        bool mo = false;

        public Form1()
        {
            InitializeComponent();
            game_board = new Label[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    game_board[i, j] = new Label();
                    game_board[i, j].Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                    game_board[i, j].Font = new Font("Tahoma", 32);
                    game_board[i, j].BackColor = Color.Red;
                    game_board[i, j].ForeColor = Color.Gold;
                    game_board[i, j].TextAlign = ContentAlignment.MiddleCenter;
                    var margin = game_board[i, j].Margin;
                    margin.All = 4;
                    game_board[i, j].Margin = Margin;
                    tableLayoutPanel1.Controls.Add(game_board[i, j], i, j);
                }

            }
            Random r = new Random();
            int r1, r2, r1_x, r1_y, r2_x, r2_y, ran_index;
            int[] init_numbers = { 2, 2, 2, 2, 2, 4 };
            ran_index = r.Next(0, init_numbers.Length);
            r1 = init_numbers[ran_index];
            r2 = init_numbers[ran_index];

            r1_x = r.Next(0, 3);
            r1_y = r.Next(0, 3);
            do
            {
                r2_x = r.Next(0, 3);
                r2_y = r.Next(0, 3);
            } while (r1_x == r2_x && r1_y == r2_y);

            game_board[r1_x, r1_y].Text = Convert.ToString(r1);
            game_board[r2_x, r2_y].Text = Convert.ToString(r2);

        }





                private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            bool mo = false;
            for (int k = 0; k < 3; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        string win = "2048";
                        if (game_board[i, j].Text != "")
                        {
                            if (e.KeyData == Keys.Left)
                            {

                                if (i > 0 && game_board[i - 1, j].Text == "")
                                {
                                    mo = true;
                                    game_board[i - 1, j].Text = game_board[i, j].Text;
                                    game_board[i, j].Text = "";

                                }
                                else if (i > 0 && game_board[i - 1, j].Text == game_board[i, j].Text)
                                {
                                    game_board[i - 1, j].Text = Convert.ToString(Convert.ToInt32(game_board[i, j].Text) * 2);
                                    game_board[i, j].Text = "";
                                }
                            }
                            else if (e.KeyData == Keys.Right)
                            {
                                if (i < 3 && game_board[i + 1, j].Text == "")
                                {
                                    mo = true;
                                    game_board[i + 1, j].Text = game_board[i, j].Text;
                                    game_board[i, j].Text = "";

                                }
                                else if (i < 3 && game_board[i + 1, j].Text == game_board[i, j].Text)
                                {
                                    game_board[i + 1, j].Text = Convert.ToString(Convert.ToInt32(game_board[i, j].Text) * 2);
                                    game_board[i, j].Text = "";
                                }
                            }

                            else if (e.KeyData == Keys.Down)
                            {
                                if (j < 3 && game_board[i, j + 1].Text == "")
                                {
                                    mo = true;
                                    game_board[i, j + 1].Text = game_board[i, j].Text;
                                    game_board[i, j].Text = "";

                                }
                                else if (j < 3 - 1 && game_board[i, j + 1].Text == game_board[i, j].Text)
                                {
                                    game_board[i, j + 1].Text = Convert.ToString(Convert.ToInt32(game_board[i, j].Text) * 2);
                                    game_board[i, j].Text = "";
                                }
                            }
                            else if (e.KeyData == Keys.Up)
                            {
                                if (j > 0 && game_board[i, j - 1].Text == "")
                                {
                                    mo = true;
                                    game_board[i, j - 1].Text = game_board[i, j].Text;
                                    game_board[i, j].Text = "";

                                }
                                else if (j > 0 && game_board[i, j - 1].Text == game_board[i, j].Text)
                                {
                                    game_board[i, j - 1].Text = Convert.ToString(Convert.ToInt32(game_board[i, j].Text) * 2);
                                    game_board[i, j].Text = "";
                                }
                            }
                        }
                        if(game_board[i,j].Text == win)
                        {
                            MessageBox.Show("U won!");
                        }
                    }
                    }
                    }
                  
                    if (mo == true)
                    {
                        make_rand();
                       }
                }

                    
            
        private void make_rand()
        {
            var rand = new Random();
            int[] num = { 2, 2, 2, 4 };
            bool empty;
            do
            {
                empty = true;

                r_x = rand.Next(0, n - 1);
                r_y = rand.Next(0, n - 1);

                if (game_board[r_x, r_y].Text != "")
                    empty = false;
            } while (empty == false);

            r = (num[rand.Next(0, num.Length)]).ToString();
            game_board[r_x, r_y].Text = r;
        }
    }
}