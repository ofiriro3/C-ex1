using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    class SubMenuItem : MenuItem
    {
        protected List<MenuItem> m_MenuItems;

        public SubMenuItem()
        {
            m_MenuItems = new List<MenuItem>();
        }
        protected override void onClick()
        {
            throw new NotImplementedException();
        }
    }
}
