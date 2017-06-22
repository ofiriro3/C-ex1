using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    class FunctionItem : MenuItem
    {
        private IFunction m_Function;

        public FunctionItem(string i_Title, IFunction i_Function) : base(i_Title)
        {
            m_Function = i_Function;
        }

        internal override void onClick()
        {
            m_Function.Run();
        }
    }
}
