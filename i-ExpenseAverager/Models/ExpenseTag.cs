﻿using System.Xml.Linq;

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
            ExpenseTagName = !string.IsNullOrWhiteSpace(expenseTagName) ? expenseTagName : throw new ArgumentNullException(nameof(expenseTagName));
        }

        public ExpenseTag(string expenseTagName, int expenseTagID, string expenseTagType)
        {
            ExpenseTagName = !string.IsNullOrWhiteSpace(expenseTagName) ? expenseTagName : throw new ArgumentNullException(nameof(expenseTagName));
            ExpenseTagID = expenseTagID > 0 ? expenseTagID : throw new ArgumentOutOfRangeException(nameof(expenseTagID));
            ExpenseTagType = !string.IsNullOrWhiteSpace(expenseTagType) ? expenseTagType : throw new ArgumentNullException(nameof(expenseTagType));
        }

        public ExpenseTag(XElement xml)
        {
            ExpenseTagType = xml.Attribute("type").Value;
            ExpenseTagID = int.Parse(xml.Attribute("id").Value);
            ExpenseTagName = xml.Attribute("name").Value;
        }

        public XElement AsXML() =>
            new XElement(TagName,
                new XAttribute("type", ExpenseTagType),
                new XAttribute("id", ExpenseTagID),
                new XAttribute("name", ExpenseTagName));

        public override string ToString() => ExpenseTagName;
    }
}
