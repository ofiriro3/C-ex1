using System;
using System.Collections.Generic;
using System.Text;
using eGuessLetter = B17_Ex02_Ofir_305260846_Asaf_314078676.Game.eGuessLetter;
using eGuessResult = B17_Ex02_Ofir_305260846_Asaf_314078676.Game.eGuessResult;
using eGameResult = B17_Ex02_Ofir_305260846_Asaf_314078676.Game.eGameResult;

namespace B17_Ex02_Ofir_305260846_Asaf_314078676
{
    public class Program
    {
        public static void Main()
        {
            eGameResult gameResult = eGameResult.Loss;
            string userInput;

            while (gameResult != eGameResult.Abort)
            {
                Game game = new Game();
                game.Run();
                gameResult = game.GameResult;
                if (gameResult != eGameResult.Abort)
                {
                    if(gameResult == eGameResult.Win)
                    {
                        Board.PrintWinningMessage(game.GetNumOfGuessMade());
                    }

                    else
                    {
                       Board.PrintLosingMessage();
                    }

                    userInput = Board.ReadNewGameSelect();
                    while (!userInput.Equals("Y") && !userInput.Equals("N"))
                    {
                        userInput = Board.ReadNewGameSelect();
                    }

                    if (userInput.Equals("N"))
                    {
                        break;
                    }
                }
            }

            Board.WriteLine("Thank you very much for playing Bye Bye");
            Board.WriteLine("Please press any key to continue");
            Board.ReadLine();
        }
    }
}
