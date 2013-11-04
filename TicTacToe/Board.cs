using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Board
    {
        private string[] _boardArray = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        private int _turnsCounter = 0;

        public bool AddMark(string mark, int position)
        {
            if (_boardArray[position-1] == position.ToString())
            {
                _boardArray[position-1] = mark;
                _turnsCounter += 1;
                return true;
            }

            Console.WriteLine("That position is filled!");
            return false;
        }

        public void Display()
        {
            Console.Clear();
            Console.WriteLine(" {0} | {1} | {2}", _boardArray[0], _boardArray[1], _boardArray[2]);
            Console.WriteLine("---------------");
            Console.WriteLine(" {0} | {1} | {2}", _boardArray[3], _boardArray[4], _boardArray[5]);
            Console.WriteLine("---------------");
            Console.WriteLine(" {0} | {1} | {2}\n\n", _boardArray[6], _boardArray[7], _boardArray[8]);
        }

        public bool IsVictory(Player currentPlayer)
        {
            bool victory = IsHorizontalWin(currentPlayer.Mark) || IsVerticalWin(currentPlayer.Mark) || IsDiagonalWin(currentPlayer.Mark);
            if (victory == true)
            {
                Display();
                Console.WriteLine("{0} wins!", currentPlayer.Name);               
            }

            return victory;
        }

        private bool IsHorizontalWin(string mark)
        {
            return (_boardArray[0] == mark && _boardArray[1] == mark && _boardArray[2] == mark) ||
                   (_boardArray[3] == mark && _boardArray[4] == mark && _boardArray[5] == mark) ||
                   (_boardArray[6] == mark && _boardArray[7] == mark && _boardArray[8] == mark);
        }

        private bool IsVerticalWin(string mark)
        {
            return (_boardArray[0] == mark && _boardArray[3] == mark && _boardArray[6] == mark) ||
                   (_boardArray[1] == mark && _boardArray[4] == mark && _boardArray[7] == mark) ||
                   (_boardArray[2] == mark && _boardArray[5] == mark && _boardArray[8] == mark);
        }

        private bool IsDiagonalWin(string mark)
        {
            return (_boardArray[0] == mark && _boardArray[4] == mark && _boardArray[8] == mark) ||
                   (_boardArray[2] == mark && _boardArray[4] == mark && _boardArray[6] == mark);
        }

        public bool IsCatGame()
        {
            Display();
            Console.WriteLine("It's a tie!");
            return _turnsCounter == 9;
        }
    }
}
