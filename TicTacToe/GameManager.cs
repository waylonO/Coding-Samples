using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class GameManager
    {
        private bool _gameOver;

        private Player _player1;
        private Player _player2;
        private Player _currentPlayer;

        private Board _board;

        public void PlayGame()
        {
            bool playAgain = true;

            while (playAgain)
            {
                SetUp();
                ProcessTurns();

                Console.WriteLine("Play Again (Y/N)?");
                string response = Console.ReadLine();
                playAgain = response == "Y";
            }
        }

        private void ProcessTurns()
        {
            while (!_gameOver)
            {
                NextPlayer();
                _board.Display();
                PromptUser();
                _gameOver = _board.IsVictory(_currentPlayer) || _board.IsCatGame();
            }
        }

        private void PromptUser()
        {
            bool validInput = false;
            int position;

            while (!validInput)
            {
                Console.Write("{0} enter a board position: ", _currentPlayer.Name);
                validInput = int.TryParse(Console.ReadLine(), out position);

                if (!validInput)
                {
                    Console.WriteLine("Invalid entry!");
                    continue;
                }

                validInput = _board.AddMark(_currentPlayer.Mark, position);
            }
        }

        private void SetUp()
        {
            Console.Clear();
            _player1 = CreatePlayer(1, "X");
            _player2 = CreatePlayer(2, "O");

            _board = new Board();
            _gameOver = false;
            _currentPlayer = null;
        }

        private void NextPlayer()
        {
            if (_currentPlayer == null || _currentPlayer.Number == 2) // start of game
                _currentPlayer = _player1;
            else
                _currentPlayer = _player2;
        }

        private Player CreatePlayer(int number, string mark)
        {
            Player p = new Player();

            Console.Write("Player {0} your name: ", number);
            p.Name = Console.ReadLine();
            p.Mark = mark;
            p.Number = number;

            return p;
        }
    }
}
