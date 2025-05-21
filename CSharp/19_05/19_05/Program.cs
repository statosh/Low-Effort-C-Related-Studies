using System;
using System.Collections.Generic;

namespace TicTacToe {
    class Game {
        private char[,] board = new char[3, 3];
        private Random rand = new Random();
        private char playerSymbol = 'X';
        private char computerSymbol = 'O';
        private bool isPlayerTurn;

        public void StartSinglePlayer() {
            ResetBoard();
            isPlayerTurn = rand.Next(2) == 0;
            Console.WriteLine("Вы играете за " + playerSymbol);
            Console.WriteLine(isPlayerTurn ? "Вы ходите первым." : "Компьютер ходит первым.");

            PlayGame(() => {
                if (isPlayerTurn) PlayerMove();
                else ComputerMove();
                isPlayerTurn = !isPlayerTurn;
            });
        }

        public void StartMultiplayer() {
            ResetBoard();
            isPlayerTurn = true;
            Console.WriteLine("Игрок 1: X, Игрок 2: O");
            Console.WriteLine("Игрок 1 ходит первым.");

            PlayGame(() => {
                if (isPlayerTurn) PlayerMove('X');
                else PlayerMove('O');
                isPlayerTurn = !isPlayerTurn;
            });
        }

        private void ResetBoard() {
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {
                    board[i, j] = '-';
                }
            }
        }

        private void DrawBoard() {
            Console.WriteLine("\nТекущее поле:");
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private void PlayerMove(char symbol = 'X') {
            int row, col;
            do {
                Console.Write($"Ход {symbol}. Введите строку и столбец (0-2): ");
                while (!int.TryParse(Console.ReadLine(), out row) || row < 0 || row > 2) {
                    Console.Write("Введите корректную строку (0-2): ");
                }
                while (!int.TryParse(Console.ReadLine(), out col) || col < 0 || col > 2) {
                    Console.Write("Введите корректный столбец (0-2): ");
                }
            } while (!MakeMove(row, col, symbol));

            Console.WriteLine($"Игрок поставил {symbol} на ({row}, {col})");
        }

        private void ComputerMove() {
            int row, col;
            do {
                row = rand.Next(3);
                col = rand.Next(3);
            } while (!MakeMove(row, col, computerSymbol));
            Console.WriteLine($"Компьютер поставил {computerSymbol} на ({row}, {col})");
        }

        private bool MakeMove(int row, int col, char symbol) {
            if (board[row, col] != '-') return false;
            board[row, col] = symbol;
            return true;
        }

        private bool CheckWin(char symbol) {
            for (int i = 0; i < 3; i++) {
                if ((board[i, 0] == symbol && board[i, 1] == symbol && board[i, 2] == symbol) ||
                    (board[0, i] == symbol && board[1, i] == symbol && board[2, i] == symbol))
                    return true;
            }
            if ((board[0, 0] == symbol && board[1, 1] == symbol && board[2, 2] == symbol) ||
                (board[0, 2] == symbol && board[1, 1] == symbol && board[2, 0] == symbol))
                return true;

            return false;
        }

        private bool IsFull() {
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {
                    if (board[i, j] == '-') return false;
                }
            }
            return true;
        }

        private void PlayGame(Action turnAction) {
            while (true) {
                DrawBoard();
                turnAction();

                if (CheckWin(playerSymbol)) {
                    DrawBoard();
                    Console.WriteLine("Вы победили!");
                    break;
                } else if (CheckWin(computerSymbol)) {
                    DrawBoard();
                    Console.WriteLine("Компьютер победил!");
                    break;
                } else if (IsFull()) {
                    DrawBoard();
                    Console.WriteLine("Ничья.");
                    break;
                }
            }
        }
    }
}

namespace MorseCode {
    class MorseTranslator {
        private Dictionary<char, string> morseMap = new Dictionary<char, string>() {
            {'a', ".-"}, {'b', "-..."}, {'c', "-.-."}, {'d', "-.."}, {'e', "."},
            {'f', "..-."}, {'g', "--."}, {'h', "...."}, {'i', ".."}, {'j', ".---"},
            {'k', "-.-"}, {'l', ".-.."}, {'m', "--"}, {'n', "-."}, {'o', "---"},
            {'p', ".--."}, {'q', "--.-"}, {'r', ".-."}, {'s', "..."}, {'t', "-"},
            {'u', "..-"}, {'v', "...-"}, {'w', ".--"}, {'x', "-..-"}, {'y', "-.--"},
            {'z', "--.."}, {'1', ".----"}, {'2', "..---"}, {'3', "...--"}, {'4', "....-"},
            {'5', "....."}, {'6', "-...."}, {'7', "--..."}, {'8', "---.."}, {'9', "----."},
            {'0', "-----"}
        };

        private Dictionary<string, char> reverseMorseMap = new Dictionary<string, char>() {
            {".-", 'a'}, {"-...", 'b'}, {"-.-.", 'c'}, {"-..", 'd'}, {".", 'e'},
            {"..-.", 'f'}, {"--.", 'g'}, {"....", 'h'}, {"..", 'i'}, {".---", 'j'},
            {"-.-", 'k'}, {".-..", 'l'}, {"--", 'm'}, {"-.", 'n'}, {"---", 'o'},
            {".--.", 'p'}, {"--.-", 'q'}, {".-.", 'r'}, {"...", 's'}, {"-", 't'},
            {"..-", 'u'}, {"...-", 'v'}, {".--", 'w'}, {"-..-", 'x'}, {"-.--", 'y'},
            {"--..", 'z'}, {".----", '1'}, {"..---", '2'}, {"...--", '3'}, {"....-", '4'},
            {".....", '5'}, {"-....", '6'}, {"--...", '7'}, {"---..", '8'}, {"----.", '9'},
            {"-----", '0'}
        };

        public string TextToMorse(string text) {
            string result = "";
            foreach (char c in text.ToLower()) {
                if (c == ' ') result += " / ";
                else if (morseMap.ContainsKey(c)) result += morseMap[c] + " ";
            }
            return result.Trim();
        }

        public string MorseToText(string morse) {
            string[] words = morse.Split(new string[] { " / " }, StringSplitOptions.None);
            string result = "";

            foreach (string word in words) {
                string[] symbols = word.Split(' ');
                foreach (string s in symbols) {
                    if (reverseMorseMap.ContainsKey(s)) result += reverseMorseMap[s];
                }
                result += " ";
            }

            return result.Trim();
        }
    }
}

class Program {

    static void Main() {
        while (true) {
            Console.Clear();
            Console.WriteLine("1. Игра Крестики-Нолики (против компьютера)");
            Console.WriteLine("2. Игра Крестики-Нолики (между двумя игроками)");
            Console.WriteLine("3. Перевести текст в азбуку Морзе");
            Console.WriteLine("4. Перевести из азбуки Морзе в текст");
            Console.WriteLine("0. Выход");
            Console.Write("Выберите задание: ");

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 4) {
                Console.Write("Неверный выбор. Повторите: ");
            }

            Console.Clear();

            switch (choice) {
                case 1:
                    var game1 = new TicTacToe.Game();
                    game1.StartSinglePlayer();
                    break;

                case 2:
                    var game2 = new TicTacToe.Game();
                    game2.StartMultiplayer();
                    break;

                case 3:
                    TranslateTextToMorse();
                    break;

                case 4:
                    TranslateMorseToText();
                    break;

                case 0:
                    Console.WriteLine("Выход...");
                    return;
            }

            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
    }

    static void TranslateTextToMorse() {
        var translator = new MorseCode.MorseTranslator();
        Console.Write("Введите текст: ");
        string input = Console.ReadLine();
        Console.WriteLine("Азбука Морзе: " + translator.TextToMorse(input));
    }

    static void TranslateMorseToText() {
        var translator = new MorseCode.MorseTranslator();
        Console.Write("Введите текст азбукой Морзе (разделитель - пробел, между словами - / ): ");
        string input = Console.ReadLine();
        Console.WriteLine("Переведено: " + translator.MorseToText(input));
    }
}