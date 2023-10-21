using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cakes
{
    internal class Program
    {
        public static List<Menu> menu()
        {
            List<Menu> menu = new List<Menu>();
            Menu form = new Menu("  Форма", new Dictionary<string, int>
            {
                {"  Круг", 500},
                {"  Квадрат", 500},
                {"  Прямоугольник", 500},
                {"  Сердечко", 500}
            });
            Menu size = new Menu("  Размер", new Dictionary<string, int>
            {
                {"  Маленький (Диаметр - 16 см, 8 порций", 1000 },
                {"  Средний (Диаметр - 18 см, 10 порций", 1200 },
                {"  Большой (Диаметр - 28 см, 24 порций", 2000 },
            });
            Menu taste = new Menu("  Вкус", new Dictionary<string, int>
            {
                {"  Ванильный", 100 },
                {"  Шоколадный", 100 },
                {"  Карамельный", 150 },
                {"  Ягодный", 200 },
                {"  Кокосовый", 250 },
            });
            Menu quantity = new Menu("  Количество коржей", new Dictionary<string, int>
            {
                {"  1 корж", 200 },
                {"  2 коржа", 400 },
                {"  3 коржа", 600 },
                {"  4 коржа", 800 },
            });
            Menu glaze = new Menu("  Глазурь", new Dictionary<string, int>
            {
                {"  Шоколад", 100 },
                {"  Крем", 100 },
                {"  Бизе", 150 },
                {"  Драже", 150 },
                {"  Ягоды", 200 },
            });
            Menu decor = new Menu("  Декор", new Dictionary<string, int>
            {
                {"  Шоколадная", 150},
                {"  Ягодная", 150 },
                {"  Кремовая", 150 },
            });
            menu.Add(form);
            menu.Add(size);
            menu.Add(taste);
            menu.Add(quantity);
            menu.Add(glaze);
            menu.Add(decor);

            return menu;
        }
        public static void writeInFile(Dictionary<string, int> soderzhanie)
        {
            //string text = File.ReadAllText("zakaz.txt");
            string text = "\nТорт содержит: ";
            foreach (var item in soderzhanie)
            {
                text += "\n" + item.ToString();
            }
            if (!File.Exists("заказ.txt"))
            {
                string allText = "История заказов: ";
                File.WriteAllText("заказ.txt", allText + text);
            } else
            {
                string allText = File.ReadAllText("заказ.txt");
                allText += text;
                File.WriteAllText("заказ.txt", allText);
            }

        }

        public static void show(List<string> allChoices, Dictionary<string, int> soderzhanie, List<Menu> myMenu)
        {
            Console.Clear();
            Console.WriteLine("Закажи свой любимый ТОРТ!");
            Console.WriteLine("Собери свой торт:");
            Console.WriteLine("--------------------------");
            foreach (var choice in allChoices)
            {
                Console.WriteLine(choice);
            }
            Console.WriteLine();
            Console.WriteLine("Цена: ");
            string allSoderzhanie = "Ваш заказ содержит: ";
            foreach (var choice in soderzhanie)
            {
                allSoderzhanie += $"{choice.Key} - {choice.Value}";
            }
            Console.WriteLine(allSoderzhanie);
            arrows menuArrows = new arrows(3, allChoices.Count + 2);
            int choiceNum = menuArrows.Show(3, allChoices, soderzhanie, myMenu) - 3;
            if (choiceNum != 6)
            {
                showDetailedMenu(myMenu.ToArray()[choiceNum].choices, allChoices, soderzhanie, myMenu);
            } else
            {
                writeInFile(soderzhanie);
                soderzhanie.Clear();
                show(allChoices, soderzhanie, myMenu);
            }
        }

        public static void showDetailedMenu(Dictionary<string, int> descripton, List<string> allChoices, Dictionary<string, int> soderzhanie, List<Menu> myMenu)
        {
            Console.Clear();
            List<string> choices = new List<string>();
            foreach (var choice in descripton.Keys)
            {
                Console.Write(choice + " - ");
                Console.WriteLine(descripton[choice]);
                choices.Add(choice);
            }
            arrows detailArrows = new arrows(0, descripton.Count - 1);
            int choiceNum = detailArrows.Show(1, allChoices, soderzhanie, myMenu);
            string ourChoice = choices.ToArray()[choiceNum];
            soderzhanie[ourChoice] = descripton[ourChoice];
            show(allChoices, soderzhanie , myMenu);
        }

        static void Main(string[] args)
        {
            List<Menu> myMenu = menu();
            List<string> allChoices = new List<string>(); 
            foreach (var choice in myMenu)
            {
                allChoices.Add(choice.nameOfChoice);
            }
            allChoices.Add("  Сделать заказ)");
            Dictionary<string, int> soderzhanieCake = new Dictionary<string, int>();
            show(allChoices, soderzhanieCake, myMenu);
        }
    }
}
