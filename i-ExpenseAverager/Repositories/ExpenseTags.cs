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
            TagType = tagType;
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
                item.ExpenseTagType = TagType;
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
            list.Remove(list.Where(o => o.ExpenseTagID.Equals(itemID)).FirstOrDefault());
        }
        /// <summary>
        /// Returns the first or default item that has the given ID
        /// </summary>
        /// <param name="itemID"></param>
        /// <returns></returns>
        public ExpenseTag ItemById(int itemID)
        {
            return list.Where(o => o.ExpenseTagID.Equals(itemID)).FirstOrDefault();
        }
        /// <summary>
        /// Returns the first or default item that has the given name
        /// </summary>
        /// <param name="itemName"></param>
        /// <returns></returns>
        public ExpenseTag ItemByName(string itemName)
        {
            return list.Where(o => o.ExpenseTagName.Equals(itemName)).FirstOrDefault();
        }

        public IEnumerable<ExpenseTag> Where(Func<ExpenseTag, bool> predicate)
        {
            return list.Where(predicate);
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
            return list.OrderBy(o => o.ExpenseTagName).ToList();
        }
    }
}
