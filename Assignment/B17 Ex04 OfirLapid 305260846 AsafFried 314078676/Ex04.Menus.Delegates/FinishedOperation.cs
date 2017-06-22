using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    class FinishedOperation : Exception
    {
        public FinishedOperation(FunctionItem i_FunctionItem)
        : base(string.Format("The opreation {0} was successfuly executed !", i_FunctionItem.Title))
        {}
    }
}
