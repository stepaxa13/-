using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diary
{
    internal class Program
    {
        static List<Day> days = new List<Day>();
        static List<Note> notes = new List<Note>();
        static int currentNoteIndex = 0;
        static DateTime day = DateTime.Now;
        static int id = 0;

        static void Main()
        {
            InitializeNotes();
            InitializeDays();
            ConsoleKeyInfo keyInfo;

            DisplayDate(id);
            do
            { 
                keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.LeftArrow:
                        day = day.AddDays(-1);
                        id = Date(day);
                        DisplayDate(id);
                        break;
                    case ConsoleKey.RightArrow:
                        day = day.AddDays(1);
                        id = Date(day);
                        DisplayDate(id);
                        break;
                    case ConsoleKey.UpArrow:
                        PreviousNote(id);
                        break;
                    case ConsoleKey.DownArrow:
                        NextNote(id);
                        break;
                    case ConsoleKey.Enter:
                        ShowNoteDetails(id, currentNoteIndex);
                        break;
                }
            } while (keyInfo.Key != ConsoleKey.Escape);
        }

        static void InitializeNotes()
        {
            notes.Add(new Note("  EXERCISE 1", "DESCRIPTION", day));
            notes.Add(new Note("  EXERCISE 2", "DESCRIPTION 2", day));
            notes.Add(new Note("  Задача 1", "Описание задачи 1", DateTime.Now.AddDays(1)));
            notes.Add(new Note("  Задача 2", "Описание задачи 2", DateTime.Now.AddDays(3)));
            notes.Add(new Note("  Задача 3", "Описание задачи 3", DateTime.Now.AddDays(5)));
            notes.Add(new Note("  Задача 4", "Описание задачи 4", DateTime.Now.AddDays(7)));
            notes.Add(new Note("  Задача 5", "Описание задачи 5", DateTime.Now.AddDays(9)));
        }

        static void InitializeDays()
        {
            List<DateTime> allDates = new List<DateTime>();
            foreach(Note note in notes)
            {
                if (!allDates.Contains(note.Date))
                {
                    allDates.Add(note.Date);
                }
            }
            foreach(DateTime date in allDates)
            {
                List<Note> allNotes = new List<Note>();
                foreach (Note note in notes.Where(noteDate => noteDate.Date == date).ToList())
                {
                    allNotes.Add(note);
                }
                days.Add(new Day(date, allNotes.ToArray()));
            }

        }

        static void DisplayDate( int id)
        {
            Console.Clear();
            Console.WriteLine(days.ToArray()[id].date);
            for (int i = 0; i < days.ToArray()[id].notes.Length; i++)
            {
                Console.WriteLine(days.ToArray()[id].notes[i].Title);
            }
        }

        static int Date(DateTime day)
        {
            int id = -1;
            Day[] daysArr = days.ToArray();
            for (int i = 0; i < daysArr.Length; i++)
            {
                if (daysArr[i].date == day)
                {
                    id = i;
                    return id;
                }
                else
                {
                    id++;
                }
            }
            if (id + 1 == daysArr.Length)
            {
                days.Add(new Day(day, new Note[] { new Note("  Задача 10", "Описание задачи 10", day) }));
            }
            return id + 1;
        }


        static void PreviousNote(int id)
        {
            if (currentNoteIndex > 1)
            {
                currentNoteIndex--;
            }
            Console.Clear();
            DisplayDate(id);
            Console.SetCursorPosition(0, currentNoteIndex);
            Console.Write("->");
        }

        static void NextNote(int id)
        {
            if (currentNoteIndex < days.ToArray()[id].notes.Length)
            {
                currentNoteIndex++;
            }
            Console.Clear();
            DisplayDate(id);
            Console.SetCursorPosition(0, currentNoteIndex);
            Console.Write("->");
        }

        static void ShowNoteDetails(int id, int noteId)
        {
            Console.Clear();
            Console.WriteLine(days.ToArray()[id].notes[noteId - 1].GetFullInfo());
            Console.WriteLine("Нажмите Enter для продолжения...");
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Enter)
            {
                DisplayDate(id);
            }
        }
    }
}
