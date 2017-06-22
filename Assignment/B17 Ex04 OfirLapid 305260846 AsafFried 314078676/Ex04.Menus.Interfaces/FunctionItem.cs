using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    class FunctionItem : MenuItem
    {
        private IFunction m_Function;

        public FunctionItem(IFunction function)
        {
            m_Function = function;
        }

        protected override void onClick()
        {
            throw new NotImplementedException();
        }

        
    }
}
