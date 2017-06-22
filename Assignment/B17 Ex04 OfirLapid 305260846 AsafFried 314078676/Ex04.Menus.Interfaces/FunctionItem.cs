using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    class FunctionItem : MenuItem
    {
        private IFunction m_Function;

        public FunctionItem(IFunction i_Function)
        {
            m_Function = i_Function;
        }

        protected override void onClick()
        {
            m_Function.Run();
        }
    }
}
