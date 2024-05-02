using i_ExpenseAverager.Models;
using System.Xml.Linq;

namespace i_ExpenseAverager.Repositories
{
    public class ExpenseAverage2XDB
    {
        private string _DBPath;
        private string _DBDir;
        private ExpenseTag _CurrentExpenseAverageType;

        private string _AccountName;

        public string AccountName
        {
            get { return _AccountName; }
            set
            {
                _AccountName = value;
                SubmitChanges();
            }
        }

        private DateTime _StartDate;

        public DateTime StartDate
        {
            get { return _StartDate; }
            set
            {
                _StartDate = value;
                SubmitChanges();
            }
        }

        public ExpenseTags ExpenseTypes = new ExpenseTags("type");
        public ExpenseTags ExpenseLocations = new ExpenseTags("loc");
        public ExpenseTags ExpenseOccasions = new ExpenseTags("occ");
        public ExpenseAverages2 ExpenseAverages = new ExpenseAverages2();



        public ExpenseAverage2XDB()
        {
            // defaults for name and time
            _AccountName = "";
            _StartDate = DateTime.Parse("1/1/" + DateTime.Now.Year);

            string dir = Directory.GetCurrentDirectory();
            dir = Path.Combine(dir, "AppData");

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            _DBDir = string.Copy(dir);
            string filePath = Path.Combine(dir, "expenseAverage2DB.xdb");
            _DBPath = string.Copy(filePath);
            bool exists = File.Exists(filePath);

            if (!File.Exists(filePath))
            {
                SubmitChanges();
            }

            // TODO: load file if it exists and load the data while checking for errors.
            XElement doc = XElement.Load(_DBPath);

            _AccountName = doc.Descendants("accountname").FirstOrDefault().Value;
            _StartDate = DateTime.Parse(doc.Descendants("startdate").FirstOrDefault().Value);

            ExpenseTag tag;

            foreach (XElement item in doc.Descendants(ExpenseTag.TagName))
            {
                tag = new ExpenseTag(item);

                if (tag.ExpenseTagType.Equals("type"))
                {
                    ExpenseTypes.Add(tag);
                }
                else if (tag.ExpenseTagType.Equals("loc"))
                {
                    ExpenseLocations.Add(tag);
                }
                else if (tag.ExpenseTagType.Equals("occ"))
                {
                    ExpenseOccasions.Add(tag);
                }
            }

            foreach (XElement item in doc.Descendants(ExpenseAverage2.TagName))
            {
                ExpenseAverages.Add(new ExpenseAverage2(item));
            }
        }

        public ExpenseTag GetExpenseAverageType(int expenseAverageTypeID)
        {
            return ExpenseTypes.ItemById(expenseAverageTypeID);
        }

        public ExpenseTag GetExpenseAverageType(string expenseAverageType)
        {
            return ExpenseTypes.ItemByName(expenseAverageType);
        }

        public ExpenseTag GetExpenseLocation(int expenseLocationID)
        {
            return ExpenseLocations.ItemById(expenseLocationID);
        }

        public ExpenseTag GetExpenseLocation(string expenseLocation)
        {
            return ExpenseLocations.ItemByName(expenseLocation);
        }

        public ExpenseTag GetExpenseOccasion(int expenseOccasionID)
        {
            return ExpenseOccasions.ItemById(expenseOccasionID);
        }

        public ExpenseTag GetExpenseOccasion(string expenseOccasion)
        {
            return ExpenseOccasions.ItemByName(expenseOccasion);
        }

        public void SaveExpenseAverageType(string expenseAverageTypeName)
        {
            expenseAverageTypeName = expenseAverageTypeName.Trim();

            if (ExpenseTypes.ItemByName(expenseAverageTypeName) == null)
            {
                ExpenseTypes.Add(expenseAverageTypeName);
            }

            SubmitChanges();
        }
        public void SaveExpenseLocation(string expenseLocationName)
        {
            expenseLocationName = expenseLocationName.Trim();

            if (ExpenseLocations.ItemByName(expenseLocationName) == null)
            {
                ExpenseLocations.Add(expenseLocationName);
            }

            SubmitChanges();
        }

        public void SaveExpenseOccasion(string expenseOccasionName)
        {
            expenseOccasionName = expenseOccasionName.Trim();

            if (ExpenseOccasions.ItemByName(expenseOccasionName) == null)
            {
                ExpenseOccasions.Add(expenseOccasionName);
            }

            SubmitChanges();
        }

        public bool SaveExpenseAverage(string type, string location, string occasion, DateTime forDate, double amount, string note)
        {
            ExpenseTag expenseType = GetExpenseAverageType(type);
            ExpenseTag expenseLocation = GetExpenseLocation(location);
            ExpenseTag expenseOccasion = GetExpenseOccasion(occasion);
            List<ExpenseAverage2> expenseAveragesList = ExpenseAverages.ToList();
            ExpenseAverage2 expenseAverage = new ExpenseAverage2(expenseAveragesList.Count + 1, expenseType.ExpenseTagID, expenseLocation.ExpenseTagID, expenseOccasion.ExpenseTagID, forDate, amount, note);
            ExpenseAverages.Add(expenseAverage);
            SubmitChanges();

            return true;
        }

        public bool DeleteExpenseAverage(ExpenseAverage2 expense)
        {
            ExpenseAverages.Remove(expense);

            return true;
        }

        public List<ExpenseAverage2> GetExpenseAverageForExpenseAverageType(int expenseAverageTypeID)
        {
            List<ExpenseAverage2> expenseAverage = ExpenseAverages.Where(o => o.ExpenseAverageTypeID.Equals(expenseAverageTypeID)).ToList();
            expenseAverage = expenseAverage.OrderBy(o => o.Date).ToList();

            return expenseAverage;
        }

        public ExpenseAverage2 GetCurrentExpenseAverageTypeLastExpenseAverage()
        {
            ExpenseTag expenseAverageType = GetCurrentExpenseAverageType();
            List<ExpenseAverage2> expenseAverages = GetExpenseAverageForExpenseAverageType(expenseAverageType.ExpenseTagID);
            expenseAverages = expenseAverages.OrderBy(o => o.Date).ToList();
            ExpenseAverage2 last = null;

            if (expenseAverages.Count > 0)
            {
                last = expenseAverages[expenseAverages.Count - 1];
            }

            return last;
        }

        public bool CurrentExpenseAverageTypeSelected()
        {
            bool ret = false;
            ExpenseTag expenseAverageType = null;
            expenseAverageType = _CurrentExpenseAverageType;

            if (expenseAverageType == null)
            {
                MessageBox.Show("No current expense average type was found in the batabase." + Environment.NewLine + "Please input a new expense average type.", "No expense Average Type Found", MessageBoxButtons.OK);
                ret = false;
            }

            if (expenseAverageType != null)
            {
                ret = true;
            }

            return ret;
        }

        public void SaveCurrentExpenseAverageType(string expenseAverageTypeName)
        {
            expenseAverageTypeName = expenseAverageTypeName.Trim();
            ExpenseTag expenseAverageType = ExpenseTypes.FirstOrDefault(o => o.ExpenseTagName.Equals(expenseAverageTypeName));

            if (expenseAverageType == null)
            {
                expenseAverageType.ExpenseTagID = ExpenseTypes.ToList().Count + 1;
                ExpenseTypes.Add(expenseAverageType);
            }

            _CurrentExpenseAverageType = expenseAverageType;
            SubmitChanges();
        }

        public ExpenseTag GetCurrentExpenseAverageType()
        {
            return _CurrentExpenseAverageType;
        }

        public List<ExpenseTag> GetExpenseAverageTypes()
        {
            return ExpenseTypes.ToList();
        }

        public void SubmitChanges()
        {
            var doc = new XElement("expenseaveragedb");
            doc.Add(new XElement("accountname", _AccountName));
            doc.Add(new XElement("startdate", _StartDate.ToShortDateString()));

            foreach (var item in ExpenseTypes.ToList().Concat(ExpenseLocations.ToList()).Concat(ExpenseOccasions.ToList()))
            {
                doc.Add(item.AsXML());
            }

            var expenseAveragesList = ExpenseAverages.ToListByDate();
            for (int i = 0; i < expenseAveragesList.Count; i++)
            {
                expenseAveragesList[i].ExpenseAverageID = i + 1;
                doc.Add(expenseAveragesList[i].AsXML());
            }

            var tmpPath = Path.Combine(_DBDir, "temp.xdb");
            doc.Save(tmpPath);

            if (File.Exists(_DBPath))
            {
                File.Delete(_DBPath);
            }

            File.Move(tmpPath, _DBPath);
        }
    }
}
