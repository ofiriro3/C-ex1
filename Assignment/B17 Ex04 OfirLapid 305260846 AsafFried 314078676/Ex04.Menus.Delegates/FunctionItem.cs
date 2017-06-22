using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public delegate void ClickDelegate();

    public class FunctionItem : MenuItem
    {
        public event ClickDelegate ClickOccured;

        public FunctionItem(string i_Title) : base(i_Title)
        {}

        public override void onClick()
        {
            ClickOccured.Invoke();
            throw new FinishedOperation(this);
        }
    }
}
