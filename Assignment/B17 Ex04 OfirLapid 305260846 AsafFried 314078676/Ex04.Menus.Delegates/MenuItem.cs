using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public abstract class MenuItem
    {
        protected string m_Title;
        protected int m_Index;

        public MenuItem(string i_Title)
        {
            m_Title = i_Title;
        }

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

        public int Index
        {
            get
            {
                return m_Index;
            }
            set
            {
                m_Index = value;
            }
        }

        internal void Show()
        {
            if( m_Index == 0)
            {
                Console.WriteLine("{0}", m_Title);
            }
            else
            {
                Console.WriteLine("{0}. {1}", m_Index, m_Title);
            }
        }

        public abstract void onClick();

    }
}