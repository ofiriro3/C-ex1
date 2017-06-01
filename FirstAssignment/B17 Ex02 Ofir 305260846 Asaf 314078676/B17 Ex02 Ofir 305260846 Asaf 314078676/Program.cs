using System;
using System.Collections.Generic;
using System.Text;
using eGuessLetter = B17_Ex02_Ofir_305260846_Asaf_314078676.Game.eGuessLetter;
using eGuessResult = B17_Ex02_Ofir_305260846_Asaf_314078676.Game.eGuessResult;
using eGameResult = B17_Ex02_Ofir_305260846_Asaf_314078676.Game.eGameResult;


namespace B17_Ex02_Ofir_305260846_Asaf_314078676
{
    class Program
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
        }
    }
}

