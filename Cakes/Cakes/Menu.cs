using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Cakes
{
    internal class Menu
    {
        public string nameOfChoice;
        public Dictionary<string, int> choices;

        public Menu(string nameOfChoice, Dictionary<string, int> choices)
        {
            this.nameOfChoice = nameOfChoice;
            this.choices = choices;
        }

    }
}
