using System;
using System.Collections.Generic;
using System.Text;

namespace MorseApp
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Title = "Переводчик в Азбуку Морзе";

            MorseTranslator translator = new MorseTranslator();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== ПЕРЕВОДЧИК АЗБУКИ МОРЗЕ ===");
                Console.WriteLine("1 - Обычный текст → Азбука Морзе");
                Console.WriteLine("2 - Азбука Морзе → Обычный текст");
                Console.WriteLine("0 - Выход");
                Console.Write("\nВаш выбор: ");

                string choice = Console.ReadLine();

                if (choice == "0") break;

                switch (choice)
                {
                    case "1":
                        Console.Write("\nВведите текст: ");
                        string text = Console.ReadLine();
                        string morse = translator.TextToMorse(text);
                        Console.WriteLine($"\nТекст в азбуке Морзе:\n{morse}");
                        break;

                    case "2":
                        Console.Write("\nВведите текст в азбуке Морзе (буквы разделяйте пробелом, слова — /):\n");
                        string morseInput = Console.ReadLine();
                        string decoded = translator.MorseToText(morseInput);
                        Console.WriteLine($"\nРасшифровка:\n{decoded}");
                        break;

                    default:
                        Console.WriteLine("Некорректный выбор. Попробуйте снова.");
                        break;
                }

                Console.WriteLine("\nНажмите любую клавишу, чтобы продолжить...");
                Console.ReadKey();
            }
        }
    }

    class MorseTranslator
    {
        private readonly Dictionary<char, string> _textToMorse;
        private readonly Dictionary<string, char> _morseToText;

        public MorseTranslator()
        {
            _textToMorse = new Dictionary<char, string>()
            {
                // Латинские буквы
                {'A', ".-"}, {'B', "-..."}, {'C', "-.-."}, {'D', "-.."}, {'E', "."},
                {'F', "..-."}, {'G', "--."}, {'H', "...."}, {'I', ".."}, {'J', ".---"},
                {'K', "-.-"}, {'L', ".-.."}, {'M', "--"}, {'N', "-."}, {'O', "---"},
                {'P', ".--."}, {'Q', "--.-"}, {'R', ".-."}, {'S', "..."}, {'T', "-"},
                {'U', "..-"}, {'V', "...-"}, {'W', ".--"}, {'X', "-..-"}, {'Y', "-.--"},
                {'Z', "--.."},

                // Кириллица
                {'А', ".-"}, {'Б', "-..."}, {'В', ".--"}, {'Г', "--."}, {'Д', "-.."},
                {'Е', "."}, {'Ж', "...-"}, {'З', "--.."}, {'И', ".."}, {'Й', ".---"},
                {'К', "-.-"}, {'Л', ".-.."}, {'М', "--"}, {'Н', "-."}, {'О', "---"},
                {'П', ".--."}, {'Р', ".-."}, {'С', "..."}, {'Т', "-"}, {'У', "..-"},
                {'Ф', "..-."}, {'Х', "...."}, {'Ц', "-.-."}, {'Ч', "---."}, {'Ш', "----"},
                {'Щ', "--.-"}, {'Ъ', "--.--"}, {'Ы', "-.--"}, {'Ь', "-..-"}, {'Э', "..-.."},
                {'Ю', "..--"}, {'Я', ".-.-"},

                // Цифры
                {'0', "-----"}, {'1', ".----"}, {'2', "..---"}, {'3', "...--"},
                {'4', "....-"}, {'5', "....."}, {'6', "-...."}, {'7', "--..."},
                {'8', "---.."}, {'9', "----."},

                {' ', "/"}
            };

            _morseToText = new Dictionary<string, char>();
            foreach (var kv in _textToMorse)
                _morseToText[kv.Value] = kv.Key;
        }

        public string TextToMorse(string text)
        {
            StringBuilder result = new StringBuilder();

            foreach (char ch in text.ToUpper())
            {
                if (_textToMorse.ContainsKey(ch))
                    result.Append(_textToMorse[ch] + " ");
                else
                    result.Append("? ");
            }

            return result.ToString().Trim();
        }

        public string MorseToText(string morse)
        {
            StringBuilder result = new StringBuilder();
            string[] words = morse.Split('/');

            foreach (string word in words)
            {
                string[] symbols = word.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                foreach (string symbol in symbols)
                {
                    if (_morseToText.ContainsKey(symbol))
                        result.Append(_morseToText[symbol]);
                    else
                        result.Append('?');
                }
                result.Append(' ');
            }

            return result.ToString().Trim();
        }
    }
}
