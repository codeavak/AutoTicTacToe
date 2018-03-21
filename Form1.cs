using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        string[,] gameBoard;
        List<string> takenBoard;
        Random rnd;
        int moveCounter;
        string whosTurn;

        void Initialize()
        {
            takenBoard = new List<string>();
            foreach (Control c in this.Controls)
            {
                if (c is Label)
                {
                    c.Text = "";
                }
            }
            txtResult.Clear();
            rnd = new Random();
            gameBoard = new string[3, 3];
            moveCounter = 1;
            whosTurn = rnd.Next(0, 2) == 1 ? "X" : "O";

            while (CheckWin() == 0 && moveCounter < 10)
            {
                Play();
                moveCounter++;
            }
            int result = CheckWin();
            DrawBoard();
            if (CheckWin() == 1)
                txtResult.Text = "Player 1 won!";
            else if (result == 2)
                txtResult.Text = "Player 2 won!";
            else txtResult.Text = "We have a Tie!";

        }
        void Play()
        {
            int row, column;
            row = rnd.Next(0, 3);
            column = rnd.Next(0, 3);
            while (takenBoard.Contains($"{row}{column}"))
            {
                row = rnd.Next(0, 3);
                column = rnd.Next(0, 3);
            }
            takenBoard.Add($"{row}{column}");
            gameBoard[row, column] = whosTurn;
            SwitchTurn();

        }
        void DrawBoard()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    string LabelText = $"{i}{j}";
                    foreach (Control c in this.Controls)
                    {

                        if (c is Label && c != null)
                        {
                            if (c.Name.EndsWith(LabelText))
                                c.Text = gameBoard[i, j];
                        }
                    }
                }

        }
        int CheckWin()
        {
            if (gameBoard[0, 0] == "X" && gameBoard[0, 1] == "X" && gameBoard[0, 2] == "X" ||

             gameBoard[1, 0] == "X" && gameBoard[1, 1] == "X" && gameBoard[1, 2] == "X" ||
             gameBoard[2, 0] == "X" && gameBoard[2, 1] == "X" && gameBoard[2, 2] == "X" ||
             gameBoard[0, 0] == "X" && gameBoard[1, 0] == "X" && gameBoard[2, 0] == "X" ||
             gameBoard[0, 1] == "X" && gameBoard[1, 1] == "X" && gameBoard[2, 1] == "X" ||
             gameBoard[0, 2] == "X" && gameBoard[1, 2] == "X" && gameBoard[2, 2] == "X" ||
             gameBoard[0, 0] == "X" && gameBoard[1, 1] == "X" && gameBoard[2, 2] == "X" ||

             gameBoard[0, 2] == "X" && gameBoard[1, 1] == "X" && gameBoard[2, 0] == "X")
            {
                return 1;
            }
            else if (gameBoard[0, 0] == "O" && gameBoard[0, 1] == "O" && gameBoard[0, 2] == "O" ||

           gameBoard[1, 0] == "O" && gameBoard[1, 1] == "O" && gameBoard[1, 2] == "O" ||
           gameBoard[2, 0] == "O" && gameBoard[2, 1] == "O" && gameBoard[2, 2] == "O" ||
           gameBoard[0, 0] == "O" && gameBoard[1, 0] == "O" && gameBoard[2, 0] == "O" ||
           gameBoard[0, 1] == "O" && gameBoard[1, 1] == "O" && gameBoard[2, 1] == "O" ||
           gameBoard[0, 2] == "O" && gameBoard[1, 2] == "O" && gameBoard[2, 2] == "O" ||
           gameBoard[0, 0] == "O" && gameBoard[1, 1] == "O" && gameBoard[2, 2] == "O" ||

           gameBoard[0, 2] == "O" && gameBoard[1, 1] == "O" && gameBoard[2, 0] == "O")

                return 2;
            else return 0;

        }

        void SwitchTurn()
        {
            if (whosTurn == "X")
                whosTurn = "O";
            else
                whosTurn = "X";
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            Initialize();

        }
    }
}