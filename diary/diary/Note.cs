using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diary
{
    internal class Note
    {
        public string Title;
        public string Description;
        public DateTime Date;

        public Note(string title, string description, DateTime date)
        {
            Title = title;
            Description = description;
            Date = date;
        }


        public string GetFullInfo()
        {
            return $"Название: {Title}\nОписание: {Description}\nДата: {Date.ToShortDateString()}\n";
        }
    }
}
