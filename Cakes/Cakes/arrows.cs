using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cakes
{
    internal class arrows
    {
        private int minPosition;
        private int maxPosition;

        public arrows(int minPosition, int maxPosition)
        {
            this.minPosition = minPosition;
            this.maxPosition = maxPosition;
        }
        
        public int Show(int pos, List<string> allChoices, Dictionary<string, int> soderzhanie, List<Menu> myMenu)
        {
            ConsoleKeyInfo key;

            do
            {
                Console.SetCursorPosition(0, pos);
                Console.WriteLine("->");

                key = Console.ReadKey();

                Console.SetCursorPosition(0, pos);
                Console.WriteLine("  ");

                if (key.Key == ConsoleKey.UpArrow && pos != minPosition)
                {
                    pos--;
                }
                else if (key.Key == ConsoleKey.DownArrow && pos != maxPosition)
                {
                    pos++;
                }
                else if (key.Key == ConsoleKey.Escape)
                { 
                    Program.show(allChoices, soderzhanie, myMenu);
                }
            } while (key.Key != ConsoleKey.Enter);

            return pos;
        }
    }
}
