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

        /// <summary>
		/// Converts a expencetag XElement into a ExpenceTag object.
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
