using i_ExpenseAverager.Models;

namespace i_ExpenseAverager.Repositories
{
    /// <summary>
	/// The DB Table
	/// </summary>
	public class ExpenseTags
    {
        private List<ExpenseTag> list = new List<ExpenseTag>();

        private string tagType;

        public string TagType
        {
            get { return tagType; }
            private set { tagType = value; }
        }

        public ExpenseTags(string tagType)
        {
            this.TagType = tagType;
        }

        public void Add(ExpenseTag item)
        {
            ExpenseTag item1 = FirstOrDefault(o => o.ExpenseTagName.Equals(item.ExpenseTagName));
            if (item1 == null)
            {
                item.ExpenseTagType = this.TagType;
                list.Add(item);
            }
            if (item.ExpenseTagID == 0)
            {
                item.ExpenseTagID = list.Count();
            }
        }

        public void Add(string itemName)
        {
            ExpenseTag item1 = FirstOrDefault(o => o.ExpenseTagName.Equals(itemName));
            ExpenseTag item = new ExpenseTag(itemName);
            if (item1 == null)
            {
                item.ExpenseTagType = this.TagType;
                list.Add(item);
            }
            if (item.ExpenseTagID == 0)
            {
                item.ExpenseTagID = list.Count();
            }
        }

        public void Remove(ExpenseTag item)
        {
            list.Remove(item);
        }

        public void Remove(int itemID)
        {
            ExpenseTag item = list.Where(o => o.ExpenseTagID.Equals(itemID)).FirstOrDefault();
            list.Remove(item);
        }
        /// <summary>
        /// Returns the first or default item that has the given ID
        /// </summary>
        /// <param name="itemID"></param>
        /// <returns></returns>
        public ExpenseTag ItemById(int itemID)
        {
            ExpenseTag item = list.Where(o => o.ExpenseTagID.Equals(itemID)).FirstOrDefault();
            return item;
        }
        /// <summary>
        /// Returns the first or default item that has the given name
        /// </summary>
        /// <param name="itemName"></param>
        /// <returns></returns>
        public ExpenseTag ItemByName(string itemName)
        {
            ExpenseTag item = list.Where(o => o.ExpenseTagName.Equals(itemName)).FirstOrDefault();
            return item;
        }

        public IEnumerable<ExpenseTag> Where(Func<ExpenseTag, bool> predicate)
        {
            return (IEnumerable<ExpenseTag>)list.Where(predicate);
        }

        public ExpenseTag FirstOrDefault(Func<ExpenseTag, bool> predicate)
        {
            return list.FirstOrDefault(predicate);
        }

        public List<ExpenseTag> ToList()
        {
            return list;
        }

        public List<ExpenseTag> ToListByName()
        {
            List<ExpenseTag> items;
            items = list.OrderBy(o => o.ExpenseTagName).ToList();
            return items;
        }

    }
}
