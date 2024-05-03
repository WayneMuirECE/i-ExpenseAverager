using i_ExpenseAverager.Models;

namespace i_ExpenseAverager.Repositories
{
    /// <summary>
	/// The DB Table
	/// </summary>
	public class ExpenseTags
    {
        private List<ExpenseTag> _list = new List<ExpenseTag>();

        public string TagType { get; private set; }

        public ExpenseTags(string tagType)
        {
            TagType = tagType;
        }

        public void Add(ExpenseTag item)
        {
            ExpenseTag item1 = FirstOrDefault(o => o.ExpenseTagName.Equals(item.ExpenseTagName));

            if (item1 == null)
            {
                item.ExpenseTagType = TagType;
                _list.Add(item);
            }

            if (item.ExpenseTagID == 0)
            {
                item.ExpenseTagID = _list.Count();
            }
        }

        public void Add(string itemName)
        {
            ExpenseTag item1 = FirstOrDefault(o => o.ExpenseTagName.Equals(itemName));
            ExpenseTag item = new ExpenseTag(itemName);

            if (item1 == null)
            {
                item.ExpenseTagType = TagType;
                _list.Add(item);
            }

            if (item.ExpenseTagID == 0)
            {
                item.ExpenseTagID = _list.Count();
            }
        }

        public void Remove(ExpenseTag item)
        {
            _list.Remove(item);
        }

        public void Remove(int itemID)
        {
            _list.Remove(_list.Where(o => o.ExpenseTagID.Equals(itemID)).FirstOrDefault());
        }
        /// <summary>
        /// Returns the first or default item that has the given ID
        /// </summary>
        /// <param name="itemID"></param>
        /// <returns></returns>
        public ExpenseTag ItemById(int itemID)
        {
            return _list.Where(o => o.ExpenseTagID.Equals(itemID)).FirstOrDefault();
        }
        /// <summary>
        /// Returns the first or default item that has the given name
        /// </summary>
        /// <param name="itemName"></param>
        /// <returns></returns>
        public ExpenseTag ItemByName(string itemName)
        {
            return _list.Where(o => o.ExpenseTagName.Equals(itemName)).FirstOrDefault();
        }

        public IEnumerable<ExpenseTag> Where(Func<ExpenseTag, bool> predicate)
        {
            return _list.Where(predicate);
        }

        public ExpenseTag FirstOrDefault(Func<ExpenseTag, bool> predicate)
        {
            return _list.FirstOrDefault(predicate);
        }

        public List<ExpenseTag> ToList()
        {
            return _list;
        }

        public List<ExpenseTag> ToListByName()
        {
            return _list.OrderBy(o => o.ExpenseTagName).ToList();
        }
    }
}
