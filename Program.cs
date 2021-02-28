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
            /*
             * When set to 'true', will provide user with additional information
             * about the data being processed
             */
            bool debug = false;
            string input = "";
            /*
             * Dictionary contains each character in Morse Code and the conversion
             * of the characters
             *
             * Rules: 
             * Dot = 1 Unit
             * Dash = 3 Units
             * Space between parts of the same letter = 1 Unit
             * Space between letters of the same word = 3 Units
             * Space between words = 7 Units
             *
             * Each unit is counted as 200 milliseconds
             */
             /* 'unit' is a period of duration when the sound will play */
             int unit = 100;
             /* 'hrtz' is the frequency that will be played by the 'beep' */
             int hrtz = 700;
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
            /* Return that shows the user the Morse Code conversion */
            Console.Write("\nInput: " + input + " | Morse Code: ");
            /* Loops through each character in the input */
            for(int i = 0; i < input.Length; i++){
                if(dict[input[i]].Equals(dict[' ']) == true){
                    /* Adds converted value to visual output */
                    Console.Write("| ");
                } else { 
                    /* Adds converted value to visual output */
                    Console.Write(dict[input[i]] + " ");
                }



                // Space between words
                if(dict[input[i]].Equals(" ")){
                    System.Threading.Thread.Sleep(unit * 7);
                    if(debug){
                        Console.WriteLine("Word Space");
                    }
                } else {
                    if(debug){
                        Console.WriteLine(dict[input[i]]);
                    }

                    for(int j = 0; j < dict[input[i]].Length; j++){
                        // Dots
                        if(dict[input[i]][j].Equals('.')) {
                            Console.Beep(hrtz, unit * 1);
                            if(debug){
                                Console.WriteLine("Short");
                            }
                        // Dashes
                        } else if(dict[input[i]][j].Equals('-')) {
                            Console.Beep(hrtz, unit * 2);
                            if(debug){
                                Console.WriteLine("Long");
                            }
                        }
                        // Space between dots and dashes
                        System.Threading.Thread.Sleep(unit * 1);
                        if(debug){
                            Console.WriteLine("Character Space");
                        }
                    }
                    // Space between each letter of the input
                    System.Threading.Thread.Sleep(unit * 3);
                    if(debug){
                        Console.WriteLine("Letter Space");
                    }
                }
            }
            Console.Write("\n");
        }
    }
}
