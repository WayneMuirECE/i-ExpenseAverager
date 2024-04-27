using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace i_ExpenceAverager.Models
{
    public class ExpenseTag
    {
        public static readonly string TagName = "expencetag";

        public string ExpenseTagType { get; set; }
        public int ExpenseTagID { get; set; }
        public string ExpenseTagName { get; private set; }

        public ExpenseTag(string expenceTagName)
        {
            if (string.IsNullOrWhiteSpace(expenceTagName))
            {
                throw new ArgumentNullException(nameof(expenceTagName));
            }

            

            ExpenseTagName = expenceTagName;
        }

        public override string ToString()
        {
            return ExpenseTagName;
        }
    }
}
