using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class FunctionItem : MenuItem
    {
        private IFunction m_Function;

        public FunctionItem(string i_Title, IFunction i_Function) : base(i_Title)
        {
            m_Function = i_Function;
        }

        public override void onClick()
        {
            m_Function.Run();
        }
    }
}
