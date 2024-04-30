using i_ExpenseAverager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace i_ExpenseAverager.Models
{
    public class ExpenseTag
    {
        public static readonly string TagName = "expensetag";

        public string ExpenseTagType { get; set; }
        public int ExpenseTagID { get; set; }
        public string ExpenseTagName { get; private set; }

        public ExpenseTag(string expenseTagName)
        {
            if (string.IsNullOrWhiteSpace(expenseTagName))
            {
                throw new ArgumentNullException(nameof(expenseTagName));
            }

            

            ExpenseTagName = expenseTagName;
        }

        /// <summary>
		/// Converts a expensetag XElement into a expenseTag object.
		/// </summary>
		/// <param name="xml"></param>
		public ExpenseTag(XElement xml)
        {
            ExpenseTagType = xml.Attribute("type").Value;
            ExpenseTagID = int.Parse(xml.Attribute("id").Value);
            ExpenseTagName = xml.Attribute("name").Value;
        }

        public XElement AsXML()
        {
            XElement self = new XElement(ExpenseTag.TagName, new XAttribute("type", ExpenseTagType),
                new XAttribute("id", ExpenseTagID.ToString()), new XAttribute("name", ExpenseTagName));
            return self;
        }

        public override string ToString()
        {
            return ExpenseTagName;
        }
    }
}
