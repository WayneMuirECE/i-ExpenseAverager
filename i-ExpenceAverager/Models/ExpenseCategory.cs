using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace i_ExpenceAverager.Models
{
    public class ExpenseCategory
    {
        public string Name { get; set; }
        public List<ExpenseTag> Tags { get; } = new List<ExpenseTag>();
        public string YearAvg { get; set; }
        public string SixMonthAvg { get; set; }
        public string ThreeMonthAvg { get; set; }
        public string MonthAvg { get; set; }
        public string DailyAvg { get; set; }
        public string TotalAvg { get; set; }

        public ExpenseCategory(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }

}
