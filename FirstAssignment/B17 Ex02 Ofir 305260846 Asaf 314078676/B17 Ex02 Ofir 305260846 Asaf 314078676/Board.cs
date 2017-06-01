using System;
using System.Collections.Generic;
using System.Text;

namespace B17_Ex02_Ofir_305260846_Asaf_314078676
{
    class Board
    {


        public String ReadInput()
        {
            Console.WriteLine("Please type your next guess <A B C D>  or 'Q' to exit");
            string inputFromUser = Console.ReadLine();

            return inputFromUser;
        }
    }
}
