using i_ExpenseAverager.Interfaces;
using i_ExpenseAverager.Models;
using System.Xml.Linq;

namespace i_ExpenseAverager.Repositories
{
    public class ExpenseAverageXDB : IExpenseAverageXDB
    {
        private string _dbPath;
        private string _dbDir;
        private ExpenseTag _currentExpenseAverageType;

        private string _accountName;
        private DateTime _startDate;



        public string AccountName
        {
            get { return _accountName; }
            set
            {
                _accountName = value;
                SubmitChanges();
            }
        }



        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                _startDate = value;
                SubmitChanges();
            }
        }

        public ExpenseTags ExpenseTypes { get; set; } = new ExpenseTags("type");
        public ExpenseTags ExpenseLocations { get; set; } = new ExpenseTags("loc");
        public ExpenseTags ExpenseOccasions { get; set; } = new ExpenseTags("occ");
        public ExpenseAverages ExpenseAverages { get; set; } = new ExpenseAverages();

        public ExpenseAverageXDB()
        {
            // defaults for name and time
            _accountName = "";
            _startDate = DateTime.Parse("1/1/" + DateTime.Now.Year);

            string dir = Directory.GetCurrentDirectory();
            dir = Path.Combine(dir, "AppData");

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            _dbDir = string.Copy(dir);
            string filePath = Path.Combine(dir, "expenseAverage2DB.xdb");
            _dbPath = string.Copy(filePath);
            bool exists = File.Exists(filePath);

            if (!File.Exists(filePath))
            {
                SubmitChanges();
            }

            // TODO: load file if it exists and load the data while checking for errors.
            XElement doc = XElement.Load(_dbPath);

            _accountName = doc.Descendants("accountname").FirstOrDefault().Value;
            _startDate = DateTime.Parse(doc.Descendants("startdate").FirstOrDefault().Value);

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

            foreach (XElement item in doc.Descendants(ExpenseAverage.TagName))
            {
                ExpenseAverages.Add(new ExpenseAverage(item));
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
            List<ExpenseAverage> expenseAveragesList = ExpenseAverages.ToList();
            ExpenseAverage expenseAverage = new ExpenseAverage(expenseAveragesList.Count + 1, expenseType.ExpenseTagID, expenseLocation.ExpenseTagID, expenseOccasion.ExpenseTagID, forDate, amount, note);
            ExpenseAverages.Add(expenseAverage);
            SubmitChanges();

            return true;
        }

        public bool DeleteExpenseAverage(ExpenseAverage expense)
        {
            ExpenseAverages.Remove(expense);

            return true;
        }

        public List<ExpenseAverage> GetExpenseAverageForExpenseAverageType(int expenseAverageTypeID)
        {
            List<ExpenseAverage> expenseAverage = ExpenseAverages.Where(o => o.ExpenseAverageTypeID.Equals(expenseAverageTypeID)).ToList();
            expenseAverage = expenseAverage.OrderBy(o => o.Date).ToList();

            return expenseAverage;
        }

        public ExpenseAverage GetCurrentExpenseAverageTypeLastExpenseAverage()
        {
            ExpenseTag expenseAverageType = GetCurrentExpenseAverageType();
            List<ExpenseAverage> expenseAverages = GetExpenseAverageForExpenseAverageType(expenseAverageType.ExpenseTagID);
            expenseAverages = expenseAverages.OrderBy(o => o.Date).ToList();
            ExpenseAverage last = null;

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
            expenseAverageType = _currentExpenseAverageType;

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

            _currentExpenseAverageType = expenseAverageType;
            SubmitChanges();
        }

        public ExpenseTag GetCurrentExpenseAverageType()
        {
            return _currentExpenseAverageType;
        }

        public List<ExpenseTag> GetExpenseAverageTypes()
        {
            return ExpenseTypes.ToList();
        }

        public void SubmitChanges()
        {
            var doc = new XElement("expenseaveragedb");
            doc.Add(new XElement("accountname", _accountName));
            doc.Add(new XElement("startdate", _startDate.ToShortDateString()));

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

            var tmpPath = Path.Combine(_dbDir, "temp.xdb");
            doc.Save(tmpPath);

            if (File.Exists(_dbPath))
            {
                File.Delete(_dbPath);
            }

            File.Move(tmpPath, _dbPath);
        }
    }
}
