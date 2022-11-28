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
        private char[] cardFaces = { 'A', 'J', 'Q', 'K', 'S', 'H', 'D', 'C' };
        private int[] cardValues = { 1, 11, 12, 13, 4, 3, 2, 1 };
        public winner(string? userInput) 
        {
            _userInput= userInput;
        }

        public string? GetInputFile()
        {
            return _userInput?.Substring(_userInput.IndexOf(" ")+1, _userInput.IndexOf("."));
        }

        public string GetGameWinner(string fileName)
        {
            string winner;
            int highScore = 0;
            try
            {
                string fileInput;
                using StreamReader file = new StreamReader(fileName);
                while ((fileInput = file.ReadLine()) != null)
                {
                    int playerScore = GetPlayerScore(fileInput);
                    if(playerScore > highScore)
                        highScore = playerScore;
                }
                
            }
            catch (Exception)
            {
                return "ERROR";
            }
            finally
            {
                
            }
            return "";
        }

        public int GetPlayerScore(string fileInput) 
        {
            int cardValue, playerScore = 0;
            string player = fileInput.Split(':')[0];
            string playerCards = fileInput.Substring(fileInput.IndexOf(':')+1);
            
            for(int k = 0; k < playerCards.Length; k++) 
            {
                if (Char.IsLetter(playerCards[k]))
                    cardValue = cardValues[Array.IndexOf(cardFaces, playerCards[k])];
                else
                    cardValue = (int)Char.GetNumericValue(playerCards[k]);

                k += IncrementLoopControl(playerCards[k + 1]);
                playerScore += cardValue;
            }
            return playerScore;
        }

        public int IncrementLoopControl(Char nextCharacter)
        {
            if (Char.IsNumber(nextCharacter))
                return 1;
            return 2;
        }
    }
}
