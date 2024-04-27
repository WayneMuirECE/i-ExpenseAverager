using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace i_ExpenceAverager.Models
{
    public class ExpenceTag
    {
        public static readonly string TagName = "expencetag";

        public string ExpenceTagType { get; set; }
        public int ExpenceTagID { get; set; }
        public string ExpenceTagName { get; private set; } = string.Empty;

        public ExpenceTag(string expenceTagName)
        {
            if (string.IsNullOrWhiteSpace(expenceTagName))
            {
                throw new ArgumentNullException(nameof(expenceTagName));
            }

            ExpenceTagName = expenceTagName;
        }

        public override string ToString()
        {
            return ExpenceTagName;
        }
    }
}
