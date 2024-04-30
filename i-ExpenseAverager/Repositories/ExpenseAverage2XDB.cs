using i_ExpenseAverager.Models;
using System.Xml.Linq;

namespace i_ExpenseAverager.Repositories
{
    public class ExpenseAverage2XDB
    {
        private string dbPath;
        private string dbDir;

        private string accountName;

        public string AccountName
        {
            get { return accountName; }
            set
            {
                accountName = value;
                SubmitChanges();
            }
        }
        private DateTime startDate;

        public DateTime StartDate
        {
            get { return startDate; }
            set
            {
                startDate = value;
                SubmitChanges();
            }
        }

        public ExpenseTags expenseTypes = new ExpenseTags("type");
        public ExpenseTags expenseLocations = new ExpenseTags("loc");
        public ExpenseTags expenseOccasions = new ExpenseTags("occ");
        public expenseAverages2 expenseAverages = new expenseAverages2();

        private ExpenseTag currentexpenseAverageType;

        public ExpenseAverage2XDB()
        {
            // defaults for name and time
            this.accountName = "";
            this.startDate = DateTime.Parse("1/1/" + DateTime.Now.Year);

            string dir = Directory.GetCurrentDirectory();
            dir = Path.Combine(dir, "AppData");
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            this.dbDir = string.Copy(dir);
            string filePath = Path.Combine(dir, "expenseAverage2DB.xdb");
            this.dbPath = string.Copy(filePath);
            bool exists = File.Exists(filePath);
            if (!File.Exists(filePath))
            {
                //while (expenseTypes.ToList().Count == 0) {
                //	MessageBox.Show("Please Input a new expense average type.");
                //	//expenseAverageTypeForm expenseAverageTypeForm = new expenseAverageTypeForm(this);
                //	//expenseAverageTypeForm.ShowDialog();
                //}
                SubmitChanges();
            }
            // TODO: load file if it exists and load the data while checking for errors.
            XElement doc = XElement.Load(this.dbPath);

            this.accountName = doc.Descendants("accountname").FirstOrDefault().Value;
            this.startDate = DateTime.Parse(doc.Descendants("startdate").FirstOrDefault().Value);

            ExpenseTag tag;
            foreach (XElement item in doc.Descendants(ExpenseTag.TagName))
            {
                tag = new ExpenseTag(item);
                if (tag.ExpenseTagType.Equals("type"))
                {
                    expenseTypes.Add(tag);
                }
                else if (tag.ExpenseTagType.Equals("loc"))
                {
                    expenseLocations.Add(tag);
                }
                else if (tag.ExpenseTagType.Equals("occ"))
                {
                    expenseOccasions.Add(tag);
                }
            }
            foreach (XElement item in doc.Descendants(ExpenseAverage2.TagName))
            {
                expenseAverages.Add(new ExpenseAverage2(item));
            }
        }

        public ExpenseTag GetExpenseAverageType(int expenseAverageTypeID)
        {
            ExpenseTag value = expenseTypes.ItemById(expenseAverageTypeID);
            return value;
        }

        public ExpenseTag GetExpenseAverageType(string expenseAverageType)
        {
            ExpenseTag value = expenseTypes.ItemByName(expenseAverageType);
            return value;
        }

        public ExpenseTag GetExpenseLocation(int expenseLocationID)
        {
            ExpenseTag value = expenseLocations.ItemById(expenseLocationID);
            return value;
        }

        public ExpenseTag GetExpenseLocation(string expenseLocation)
        {
            ExpenseTag value = expenseLocations.ItemByName(expenseLocation);
            return value;
        }

        public ExpenseTag GetExpenseOccasion(int expenseOccasionID)
        {
            ExpenseTag value = expenseOccasions.ItemById(expenseOccasionID);
            return value;
        }

        public ExpenseTag GetExpenseOccasion(string expenseOccasion)
        {
            ExpenseTag value = expenseOccasions.ItemByName(expenseOccasion);
            return value;
        }

        public void SaveExpenseAverageType(string expenseAverageTypeName)
        {
            expenseAverageTypeName = expenseAverageTypeName.Trim();
            ExpenseTag value = expenseTypes.ItemByName(expenseAverageTypeName);
            if (value == null)
            {
                expenseTypes.Add(expenseAverageTypeName);
            }

            SubmitChanges();
        }
        public void SaveExpenseLocation(string expenseLocationName)
        {
            expenseLocationName = expenseLocationName.Trim();
            ExpenseTag value = expenseLocations.ItemByName(expenseLocationName);
            if (value == null)
            {
                expenseLocations.Add(expenseLocationName);
            }

            SubmitChanges();
        }

        public void SaveExpenseOccasion(string expenseOccasionName)
        {
            expenseOccasionName = expenseOccasionName.Trim();
            ExpenseTag value = expenseOccasions.ItemByName(expenseOccasionName);
            if (value == null)
            {
                expenseOccasions.Add(expenseOccasionName);
            }

            SubmitChanges();
        }

        public bool SaveExpenseAverage(string type, string location, string occasion, DateTime forDate, double amount, string note)
        {
            ExpenseTag expenseType = GetExpenseAverageType(type);
            ExpenseTag expenseLocation = GetExpenseLocation(location);
            ExpenseTag expenseOccasion = GetExpenseOccasion(occasion);
            List<ExpenseAverage2> expenseAveragesList = expenseAverages.ToList();
            ExpenseAverage2 expenseAverage = new ExpenseAverage2(expenseAveragesList.Count + 1, expenseType.ExpenseTagID, expenseLocation.ExpenseTagID, expenseOccasion.ExpenseTagID, forDate, amount, note);
            expenseAverages.Add(expenseAverage);
            SubmitChanges();
            return true;
        }

        public bool DeleteExpenseAverage(ExpenseAverage2 expense)
        {
            expenseAverages.Remove(expense);
            return true;
        }








        public List<ExpenseAverage2> GetExpenseAverageForexpenseAverageType(int expenseAverageTypeID)
        {
            List<ExpenseAverage2> expenseAverage = expenseAverages.Where(o => o.ExpenseAverageTypeID.Equals(expenseAverageTypeID)).ToList();
            expenseAverage = expenseAverage.OrderBy(o => o.Date).ToList();
            return expenseAverage;
        }

        public ExpenseAverage2 GetCurrentExpenseAverageTypeLastexpenseAverage()
        {
            ExpenseTag expenseAverageType = GetCurrentExpenseAverageType();
            List<ExpenseAverage2> expenseAverages = GetExpenseAverageForexpenseAverageType(expenseAverageType.ExpenseTagID);
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
            expenseAverageType = this.currentexpenseAverageType;
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

        public void SelectExpenseAverageType()
        {
            //expenseAverageTypeForm expenseAverageTypeForm = new expenseAverageTypeForm(this);
            //expenseAverageTypeForm.ShowDialog();
        }

        public void SaveCurrentExpenseAverageType(string expenseAverageTypeName)
        {
            expenseAverageTypeName = expenseAverageTypeName.Trim();
            ExpenseTag expenseAverageType = expenseTypes.FirstOrDefault(o => o.ExpenseTagName.Equals(expenseAverageTypeName));
            if (expenseAverageType == null)
            {
                //expenseAverageType = new expenseLocation(expenseAverageTypeName, startDate);
                expenseAverageType.ExpenseTagID = expenseTypes.ToList().Count + 1;
                expenseTypes.Add(expenseAverageType);
            }
            else
            {
                //expenseAverageType.StartDate = startDate;
            }
            this.currentexpenseAverageType = expenseAverageType;
            SubmitChanges();
        }

        public ExpenseTag GetCurrentExpenseAverageType()
        {
            ExpenseTag expenseAverageType = this.currentexpenseAverageType;
            return expenseAverageType;
        }

        public List<ExpenseTag> GetExpenseAverageTypes()
        {
            return expenseTypes.ToList();
        }

        public void SubmitChanges()
        {
            XElement doc = new XElement("expenseaveragedb");

            doc.Add(new XElement("accountname", this.accountName));
            doc.Add(new XElement("startdate", this.startDate.ToShortDateString()));

            List<ExpenseTag> expenseAverageTypesList = expenseTypes.ToList();
            foreach (ExpenseTag item in expenseAverageTypesList)
            {
                doc.Add(item.AsXML());
            }

            List<ExpenseTag> expenseLocationsList = expenseLocations.ToList();
            foreach (ExpenseTag item in expenseLocationsList)
            {
                doc.Add(item.AsXML());
            }

            List<ExpenseTag> expenseOccasionsList = expenseOccasions.ToList();
            foreach (ExpenseTag item in expenseOccasionsList)
            {
                doc.Add(item.AsXML());
            }

            List<ExpenseAverage2> expenseAveragesList = expenseAverages.ToListByDate();
            int i = 0;
            foreach (ExpenseAverage2 item in expenseAveragesList)
            {
                i++;
                item.ExpenseAverageID = i;
                doc.Add(item.AsXML());
            }
            string tmpPath = Path.Combine(this.dbDir, "temp.xdb");
            doc.Save(tmpPath);
            if (File.Exists(dbPath))
            {
                File.Delete(dbPath);
            }
            File.Move(tmpPath, dbPath);
        }


    }
}
