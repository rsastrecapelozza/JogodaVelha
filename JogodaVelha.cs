using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JogodaVelha
{
    public partial class JogodaVelha : Form
    {
        public JogodaVelha()
        {
            InitializeComponent();
        }

        private Square[,] _board = new Square[3, 3];
        string[,] tabuleiro = new string[3, 3];
        private int contador = 0;

        Player player = Player.Jogador1;

        private void JogodaVelha_Load(object sender, EventArgs e)
        {
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if(PlayMove(player, "0,0", out string x))
            {
                button1.Text = x;
                FinishGame(player, x);
                player = 3 - player;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (PlayMove(player, "0,1", out string x))
            {
                button2.Text = x;
                FinishGame(player, x);
                player = 3 - player;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (PlayMove(player, "0,2", out string x))
            {
                button3.Text = x;
                FinishGame(player, x);
                player = 3 - player;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (PlayMove(player, "1,0", out string x))
            {
                button4.Text = x;
                FinishGame(player, x);
                player = 3 - player;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (PlayMove(player, "1,1", out string x))
            {
                button5.Text = x;
                FinishGame(player, x);
                player = 3 - player;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (PlayMove(player, "1,2", out string x))
            {
                button6.Text = x;
                FinishGame(player, x);
                player = 3 - player;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (PlayMove(player, "2,0", out string x))
            {
                button7.Text = x;
                FinishGame(player, x);
                player = 3 - player;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (PlayMove(player, "2,1", out string x))
            {
                button8.Text = x;
                FinishGame(player, x);
                player = 3 - player;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (PlayMove(player, "2,2", out string x))
            {
                button9.Text = x;
                FinishGame(player, x);
                player = 3 - player;
            }
        }


        private void button10_Click(object sender, EventArgs e)
        {
            Clear();
        }
        private void Clear()
        {
            _board = new Square[3, 3];
            tabuleiro = new string[3, 3];
            contador = 0;
            button1.Text = String.Empty;
            button2.Text = String.Empty;
            button3.Text = String.Empty;
            button4.Text = String.Empty;
            button5.Text = String.Empty;
            button6.Text = String.Empty;
            button7.Text = String.Empty;
            button8.Text = String.Empty;
            button9.Text = String.Empty;
        }

        private bool PlayMove(Player player, string input, out string x)
        {
            string[] parts = input.Split(',');
            int.TryParse(parts[0], out int row);
            int.TryParse(parts[1], out int column);

            if (_board[row, column].Owner != Player.Noone)
            {
                MessageBox.Show("Square is already occupied, chose another one");
                x = "";
                return false;
            }

            else
            {
                _board[row, column] = new Square(player);
                x = _board[row, column].ToString();
                tabuleiro[row, column] = x;
                contador++;
                return true;
            }
        }

        private void FinishGame(Player player, string x)
        {
            bool finish = false;
            bool empate = true;

            for (int i = 0; i < 3; i++)
            {
                if (tabuleiro[i, 0] == x && tabuleiro[i, 1] == x && tabuleiro[i, 2] == x)
                {
                    MessageBox.Show($"{player} - Venceu");
                    finish = true;
                    empate = false;
                }
                if (tabuleiro[0, i] == x && tabuleiro[1, i] == x && tabuleiro[2, i] == x)
                {
                    MessageBox.Show($"{player} - Venceu");
                    finish = true;
                    empate = false;
                }
            }
            if (tabuleiro[0, 0] == x && tabuleiro[1, 1] == x && tabuleiro[2, 2] == x)
            {
                MessageBox.Show($"{player} - Venceu");
                finish = true;
                empate = false;
            }
            if (tabuleiro[0, 2] == x && tabuleiro[1, 1] == x && tabuleiro[2, 0] == x)
            {
                MessageBox.Show($"{player} - Venceu");
                finish = true;
                empate = false;
            }
            if (contador == 9 && empate)
            {
                MessageBox.Show($"Empate");
                finish = true;
                empate = false;
            }

            if (finish) { Clear(); }

        }
    }
}
