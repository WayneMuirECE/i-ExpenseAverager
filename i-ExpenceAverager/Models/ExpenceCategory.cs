using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace i_ExpenceAverager.Models
{
    public class ExpenceCategory
    {
        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    return;
                }
                name = value;
            }
        }
        public List<ExpenceTag> tags;

        public string yearAvg;
        public string sixMonthAvg;
        public string threeMonthAvg;
        public string monthAvg;
        public string dailyAvg;
        public string totalAvg;

        public ExpenceCategory(string name)
        {
            this.name = name;
            this.tags = new List<ExpenceTag>();
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}
