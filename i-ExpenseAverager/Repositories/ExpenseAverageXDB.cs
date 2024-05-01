using i_ExpenseAverager.Forms;
using i_ExpenseAverager.Models;
using System.Xml.Linq;

namespace i_ExpenseAverager.Repositories
{
    public class ExpenseAverageXDB
    {
        private string dbPath;
        private string dbDir;

        private ExpenseAverageTypes expenseAverageTypes = new ExpenseAverageTypes();
        private ExpenseAverages expenseAverages = new ExpenseAverages();

        public ExpenseAverageXDB()
        {
            string dir = Directory.GetCurrentDirectory();
            dir = Path.Combine(dir, "AppData");
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            this.dbDir = string.Copy(dir);
            string filePath = Path.Combine(dir, "expenseAverageDB.expx");
            this.dbPath = string.Copy(filePath);
            bool exists = File.Exists(filePath);
            if (!File.Exists(filePath))
            {
                while (expenseAverageTypes.ToList().Count == 0)
                {
                    MessageBox.Show("Please Input a new expense average type.");
                    ExpenseTypeForm expenseAverageTypeForm = new ExpenseTypeForm(this);
                    expenseAverageTypeForm.ShowDialog();
                }
                SubmitChanges();
            }
            // TODO: load file if it exists and load the data while checking for errors.
            XElement doc = XElement.Load(this.dbPath);
            foreach (XElement item in doc.Descendants(ExpenseAverageType.TagName))
            {
                expenseAverageTypes.Add(new ExpenseAverageType(item));
            }
            foreach (XElement item in doc.Descendants(ExpenseAverage.TagName))
            {
                expenseAverages.Add(new ExpenseAverage(item));
            }
        }

        public ExpenseAverageType GetexpenseAverageType(int expenseAverageTypeID)
        {
            ExpenseAverageType expenseAverageType = expenseAverageTypes.Where(o => o.ExpenseAverageTypeID == expenseAverageTypeID).FirstOrDefault();
            return expenseAverageType;
        }

        public List<ExpenseAverage> GetexpenseAverageForexpenseAverageType(int expenseAverageTypeID)
        {
            List<ExpenseAverage> expenseAverage = expenseAverages.Where(o => o.ExpenseAverageTypeID.Equals(expenseAverageTypeID)).ToList();
            expenseAverage = expenseAverage.OrderBy(o => o.Date).ToList();
            return expenseAverage;
        }

        public ExpenseAverage GetCurrentexpenseAverageTypeLastexpenseAverage()
        {
            ExpenseAverageType expenseAverageType = GetCurrentExpenseAverageType();
            List<ExpenseAverage> expenseAverages = GetexpenseAverageForexpenseAverageType(expenseAverageType.ExpenseAverageTypeID);
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
            ExpenseAverageType expenseAverageType = null;
            expenseAverageType = expenseAverageTypes.FirstOrDefault(o => o.CurrentexpenseAverageType);
            if (expenseAverageType == null)
            {
                MessageBox.Show("No current expense average type was found in the batabase." + Environment.NewLine + "Please input a new expense average type.", "No expense Average Type Found", MessageBoxButtons.OK);
                ret = false;
            }
            if (expenseAverageType != null)
            {
                if (expenseAverageType.CurrentexpenseAverageType == true)
                {
                    ret = true;
                }
            }
            return ret;
        }

        public void SelectexpenseAverageType()
        {
            ExpenseTypeForm expenseAverageTypeForm = new ExpenseTypeForm(this);
            expenseAverageTypeForm.ShowDialog();
        }

        public void SaveCurrentExpenseAverageType(string expenseAverageTypeName, DateTime startDate)
        {
            expenseAverageTypeName = expenseAverageTypeName.Trim();
            ExpenseAverageType expenseAverageType = expenseAverageTypes.FirstOrDefault(o => o.ExpenseAverageTypeName.Equals(expenseAverageTypeName));
            if (expenseAverageType == null)
            {
                expenseAverageType = new ExpenseAverageType(expenseAverageTypeName, startDate);
                expenseAverageType.ExpenseAverageTypeID = expenseAverageTypes.ToList().Count + 1;
                expenseAverageType.CurrentexpenseAverageType = true;
                expenseAverageTypes.Add(expenseAverageType);
            }
            else
            {
                expenseAverageType.StartDate = startDate;
            }
            List<ExpenseAverageType> expenseAverageTypesList = expenseAverageTypes.ToList();
            ExpenseAverageType item;
            for (int i = 0; i < expenseAverageTypesList.Count; i++)
            {
                item = expenseAverageTypesList.ElementAt(i);
                item.CurrentexpenseAverageType = false;
            }
            expenseAverageType.CurrentexpenseAverageType = true;
            SubmitChanges();
        }

        public ExpenseAverageType GetCurrentExpenseAverageType()
        {
            ExpenseAverageType expenseAverageType = expenseAverageTypes.FirstOrDefault(o => o.CurrentexpenseAverageType);
            return expenseAverageType;
        }

        public List<ExpenseAverageType> GetExpenseAverageTypes()
        {
            return expenseAverageTypes.ToList();
        }

        public void SubmitChanges()
        {
            XElement doc = new XElement("expenseaveragedb");
            List<ExpenseAverageType> expenseAverageTypesList = expenseAverageTypes.ToList();
            foreach (ExpenseAverageType item in expenseAverageTypesList)
            {
                doc.Add(item.AsXML());
            }
            List<ExpenseAverage> expenseAveragesList = expenseAverages.ToList();
            foreach (ExpenseAverage item in expenseAveragesList)
            {
                doc.Add(item.AsXML());
            }
            string tmpPath = Path.Combine(this.dbDir, "temp.slpx");
            doc.Save(tmpPath);
            if (File.Exists(dbPath))
            {
                File.Delete(dbPath);
            }
            File.Move(tmpPath, dbPath);
        }

        public bool SaveexpenseAverage(double amount, DateTime forDate, string note)
        {
            ExpenseAverageType expenseAverageType = GetCurrentExpenseAverageType();
            List<ExpenseAverage> expenseAveragesList = expenseAverages.ToList();
            ExpenseAverage expenseAverage = new ExpenseAverage(expenseAveragesList.Count + 1, expenseAverageType.ExpenseAverageTypeID, forDate, amount, note);
            expenseAverages.Add(expenseAverage);
            SubmitChanges();
            return true;
        }
    }
}
