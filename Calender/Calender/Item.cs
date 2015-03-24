using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calender
{
    public class Item
    {
        private int id;
        private String name;
        private DateTime startDate;
        private DateTime endDate;
        private String description;

        public Item(int id, String name, DateTime start, DateTime end, String description)
        {
            this.id = id;
            this.name = name;
            this.startDate = start;
            this.endDate = end;
            this.description = description;
        }

        public int GetId()
        {
            return this.id;
        }

        public string GetName()
        {
            return this.name;
        }

        public DateTime GetStartDate()
        {
            return this.startDate;
        }

        public DateTime GetEndDate()
        {
            return this.endDate;
        }

        public string GetDescription()
        {
            return this.description;
        }
    }
}
