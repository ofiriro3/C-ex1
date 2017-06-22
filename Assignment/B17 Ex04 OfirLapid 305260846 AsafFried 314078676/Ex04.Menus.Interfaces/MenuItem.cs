using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    abstract class MenuItem
    {
        protected string m_Title;

        public string Title
        {
            get
            {
                return m_Title;
            }
            set
            {
                m_Title = value;
            }
        }

        protected void Show()
        {
            Console.WriteLine("{0}",m_Title);
        }

        protected abstract void onClick();

    }
}