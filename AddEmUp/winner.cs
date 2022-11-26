using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddEmUp
{
    public class winner
    {
        private string? _userInput;
        private char[] cardFaces = { 'A', 'J', 'Q', 'K' };
        private int[] cardValues = { 1, 11, 12, 13 };
        public winner(string? userInput) 
        {
            _userInput= userInput;
        }

        public string? GetInputFile(string? userInput)
        {
            string? inputFile = userInput?.Substring(0, userInput.IndexOf(" "));
            return inputFile;
        }
    }
}
