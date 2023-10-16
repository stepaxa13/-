using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diary
{
    internal class Day
    {
        public DateTime date;
        public Note[] notes;

        public Day(DateTime date, Note[] notes)
        {
            this.date = date;
            this.notes = notes;
        }


    }
}
