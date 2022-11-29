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
            _userInput = userInput;
        }

        public string? GetInputFile()
        {
            return _userInput?.Substring(_userInput.IndexOf(" ") + 1, _userInput.IndexOf("."));
        }

        public string? GetOutPutFile()
        {
            return _userInput?.Substring(_userInput.LastIndexOf(" ") + 1);
        }

        public void GetGameWinner(string? inputFileName, string? outputFileName)
        {
            string gameOutcome = string.Empty;
            int highScore = 0;
            try
            {
                string fileInput;
                int playerScore;
                using var file = new StreamReader(inputFileName);
                while ((fileInput = file.ReadLine()) != null)
                {
                    string results = GetPlayerScore(fileInput);
                    playerScore = Convert.ToInt16(results.Substring(results.IndexOf(":") + 1));
                    if (playerScore > highScore)
                    {
                        highScore = playerScore;
                        gameOutcome = results;
                    }
                }
                LogResults(gameOutcome);
            }
            catch (Exception)
            {
                LogResults("ERROR");
            }
        }

        public string GetPlayerScore(string fileInput)
        {
            int cardValue, playerScore = 0;
            string player = fileInput.Split(':')[0];
            string playerCards = fileInput.Substring(fileInput.IndexOf(':') + 1);

            for (int k = 0; k < playerCards.Length; k++)
            {
                if (Char.IsLetter(playerCards[k]))
                    cardValue = cardValues[Array.IndexOf(cardFaces, playerCards[k])];
                else
                    cardValue = (int)Char.GetNumericValue(playerCards[k]);

                k += IncrementLoopControl(playerCards[k + 1]);
                playerScore += cardValue;
            }
            return $"{player}: {playerScore}";
        }

        public int IncrementLoopControl(Char nextCharacter)
        {
            if (Char.IsNumber(nextCharacter))
                return 1;
            return 2;
        }

        public void LogResults(string gameOutcome)
        {
            string? fileName = GetOutPutFile();
            try
            {
                using var writer = new StreamWriter(fileName);
                writer.Write(gameOutcome);
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }

        public static void Main()
        {
            string? command = Console.ReadLine();
            winner winner = new(command);
            winner.GetGameWinner(winner.GetInputFile(), winner.GetOutPutFile());
        }
    }
}
