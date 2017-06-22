using System;
using Ex04.Menus.Delegates;

namespace Ex04.Menus.Test
{
    public static class TestDelegate
    {
        public static void Run()
        {
            MainMenuItem mainMenu = new MainMenuItem("Main Menu");
            SubMenuItem accessAndInfo = new SubMenuItem("Actions and Info");
            SubMenuItem showDateAndTime = new SubMenuItem("Show Date/Time");

            SubMenuItem Actions = new SubMenuItem("Actions");
            Actions.AddItem(new MenuItem("show"));

            
            Actions.AddItem(new FunctionItem("Chars Count", new CharsCount()));
            accessAndInfo.AddItem(new FunctionItem("Display Version", new DisplayVersion()));
            accessAndInfo.AddItem(Actions);

            showDateAndTime.AddItem(new FunctionItem("Show Time", new ShowTime()));
            showDateAndTime.AddItem(new FunctionItem("Show Date", new ShowDate()));

            mainMenu.AddItem((accessAndInfo));
            mainMenu.AddItem(showDateAndTime);

            mainMenu.onClick();
        }
    }
}
