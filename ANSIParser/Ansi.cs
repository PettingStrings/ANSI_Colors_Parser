/*
 * What i used to learn about ANSI escape codes:
 * https://gist.github.com/fnky/458719343aabd01cfb17a3a4f7296797
 * http://ascii-table.com/ansi-escape-sequences.php
 * 
 */
using System;
using System.Collections.Generic;
using System.Drawing;

namespace ANSIParser
{
    class Ansi
    {

        public static readonly char EscapeChar = '\u001b';// ← or \u001b;
        public static readonly char AnsiColor = 'm';

        public class AnsiFont
        {
            public ConsoleColor ForeColor = ConsoleColor.White;
            public ConsoleColor BackColor = ConsoleColor.Black;
            public FontStyle Font = FontStyle.Regular;
        }
        public class AnsiString
        {
            public AnsiFont Style = new AnsiFont();
            public string Text = "";
        }
        //Code I stole from:
        //https://stackoverflow.com/questions/33774590/c-sharp-convert-system-consolecolor-to-system-drawing-color
        public static Color FromColor(ConsoleColor c)
        {
            int[] cColors = {  
                    0x000000, //Black = 0
                    0x000080, //DarkBlue = 1
                    0x008000, //DarkGreen = 2
                    0x008080, //DarkCyan = 3
                    0x800000, //DarkRed = 4
                    0x800080, //DarkMagenta = 5
                    0x808000, //DarkYellow = 6
                    0xC0C0C0, //Gray = 7
                    0x808080, //DarkGray = 8
                    0x0000FF, //Blue = 9
                    0x00FF00, //Green = 10
                    0x00FFFF, //Cyan = 11
                    0xFF0000, //Red = 12
                    0xFF00FF, //Magenta = 13
                    0xFFFF00, //Yellow = 14
                    0xFFFFFF  //White = 15
                };
            return Color.FromArgb(cColors[(int)c]);
        }

        public static List<AnsiString> AnsiParser(string ansitext)
        {
            List<AnsiString> ansiText = new List<AnsiString>();
            string[] escapedText = ansitext.Split(EscapeChar);
            if (escapedText.Length == 1)
            {
                ansiText.Add(new AnsiString() { Text = ansitext });
                return ansiText;
            }
            foreach (var line in escapedText)
            {

                AnsiString @string = new AnsiString();
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string[] splitted = line.Split(new char[] { 'm' }, 2);
                @string.Style = AnsiToFont(splitted[0].Trim('['));
                @string.Text = splitted[1];
                ansiText.Add(@string);
            }

            return ansiText;
        }

        public static AnsiFont AnsiToFont(string ansiEscape)
        {
            ansiEscape = ansiEscape.Trim(new char[] { '←', '[', 'm' });
            string[] parameters = ansiEscape.Split(';');
            AnsiFont font = new AnsiFont();
            //COLOR PARAMETERS: FontStyle Foreground Background
            for (int i = 0; i < parameters.Length; i++)
            {
                if (i == 0)
                {
                    font.Font = ToFont(parameters[i] == "" ? 0 : Convert.ToInt32(parameters[i]));
                }
                else if (i == 1)
                {
                    font.ForeColor = ToColor(parameters[i] == "" ? 37 : Convert.ToInt32(parameters[i]));
                }
                else if (i == 2)
                {
                    font.BackColor = ToColor(parameters[i] == "" ? 32 : Convert.ToInt32(parameters[i]));
                }
            }
            return font;
        }

        public static FontStyle ToFont(int fontCode)
        {
          /* 
            *  0	All attributes off 
            *  1	Bold on 
            *  4	Underscore (on monochrome display adapter only)
            *  5	Blink on 
            *  7	Reverse video on 
            *  8	Concealed on
             */
            switch (fontCode)
            {
                case 0://Normal Text
                case '0':
                default:
                    return FontStyle.Regular;
                case 1:
                case '1':
                    return FontStyle.Bold;
                case 4:
                case '4':
                    return FontStyle.Underline;
            }//I don't know/understand the other fonts
        }

        /// <summary>
        /// < 40 are Fore Ground colors
        /// >= 40 are Background colors
        /// </summary>
        /// <param name="colorCode"></param>
        /// <returns></returns>
        public static ConsoleColor ToColor(int colorCode)
        {
            switch (colorCode)
            {
                case 30:
                case 40:
                    return ConsoleColor.Black;
                case 31:
                case 41:
                    return ConsoleColor.Red;
                case 32:
                case 42:
                    return ConsoleColor.Green;
                case 33:
                case 43:
                    return ConsoleColor.Yellow;
                case 34:
                case 44:
                    return ConsoleColor.Blue;
                case 35:
                case 45:
                    return ConsoleColor.Magenta;
                case 36:
                case 46:
                    return ConsoleColor.Cyan;
                case 37:
                case 47:
                    return ConsoleColor.White;
                default:
                    return ConsoleColor.Black;
            }
        }

        /// <summary>
        /// Just a normal output.
        /// </summary>
        /// <param name="strings"></param>
        public static void Print(List<AnsiString> strings)
        {
            foreach (var line in strings)
            {
                Console.ForegroundColor = line.Style.ForeColor;
                Console.BackgroundColor = line.Style.BackColor;//Can't color bg per word
                Console.Write(line.Text);
                Console.ResetColor();
            }
        }

    }
}
