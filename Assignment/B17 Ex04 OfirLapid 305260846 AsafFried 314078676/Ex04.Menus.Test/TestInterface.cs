using System;
using Ex04.Menus.Interfaces;
namespace Ex04.Menus.Test
{
    public static class TestInterface
    {
		public static void Run()
		{
            MainMenuItem mainMenu = new MainMenuItem("Main Menu");
            FunctionItem displayVersion = new FunctionItem("Display Version", new DisplayVersion());
            FunctionItem countSpaces = new FunctionItem("Count Spaces", new CountSpace());
            FunctionItem charsCount = new FunctionItem("Display Version", new CharsCount());

            SubMenuItem a = new SubMenuItem("Actions and Info")
                .AddItem(new FunctionItem("Display Version", new CharsCount()));
            
            mainMenu.onClick();
		}
    }
}
