/*
 * Program takes a user input and produced a sequence of beeps in the console
 * based off of Morse Code
 *
 * NOTE: You will not hear a beep when using some specialized command consoles.
 * Does work with Windows Command Console and GitBash.
 *
 * Author: Stewart
 * 9/15/2019
 */

using System;
// Required in order to use dictionary
using System.Collections.Generic;
// Allows for the use of REGEX in code
using System.Text.RegularExpressions;

namespace MorseCodeConverter {
    class Program {
        static void Main(string[] args) {
            string input = "";
            /*
             * Dictionary contains each character in Morse Code and the conversion
             * of the characters
             */
            Dictionary<char, string> dict = new Dictionary<char, string>(){
                {'a', ".-"}, {'b', "-..."}, {'c', "-.-."}, {'d', "-.."}, {'e', "."},
                {'f', "..-."}, {'g', "--."}, {'h', "...."}, {'i', ".."}, {'j', ".---"},
                {'k', "-.-"}, {'l', ".-.."}, {'m', "--"}, {'n', "-."}, {'o', "---"},
                {'p', ".--."}, {'q', "--.-"}, {'r', ".-."}, {'s', "..."}, {'t', "-"},
                {'u', "..-"}, {'v', "...-"}, {'w', ".--"}, {'x', "-..-"}, {'y', "-.--"},
                {'z', "--.."}, {'1', ".----"}, {'2', "..---"}, {'3', "...--"}, {'4', "....-"},
                {'5', "....."}, {'6', "-...."}, {'7', "--..."}, {'8', "---.."}, {'9', "----."},
                {'0', "-----"}, {' ', " "}
            };

            // Prompts user for an input
            try {
                Console.Write("Enter A Word To Convert Into Morse Code: ");
                input = Console.ReadLine();
            } catch (Exception e) {
                Console.Write("ERROR: " + e);
            }

            /* Removes any values in input that do not match a key in 'dict' */
            input = Regex.Replace(input, "[^A-Za-z0-9 _]", "");
            /* Converts all characters to case for compaison to the keys in 'dict' */
            input = input.ToLower();

            /*
             * Converts user input into Morse Code sequence using '.' as a short
             * beep and '-' as a long beep. ' ' is treated as a pause.
             */
            string str = "";
            for(int i = 0; i < input.Length; i++){
                if(dict[input[i]].Equals(dict[' ']) == true){
                    str += "| ";
                } else { 
                    str += dict[input[i]] + " ";
                }
            }

            /*
             * Searches 'str' and outputs beeps according to what is read
             */
            for(int j = 0; j < str.Length; j++){
                // Short Beep
                if(str[j].Equals('.')){
                    Console.Beep(800, 300);
                // Long Beep
                } else if(str[j].Equals('-')) {
                    Console.Beep(800, 550);
                // Space Between Characters
                } else if(str[j].Equals(' ')) {
                    System.Threading.Thread.Sleep(200);
                // Space Between Words
                } else {
                    System.Threading.Thread.Sleep(700);
                }
            }

            Console.WriteLine("Input: " + input + " | Morse Code: " + str);
        }
    }
}
