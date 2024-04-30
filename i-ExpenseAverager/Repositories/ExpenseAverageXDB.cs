using i_ExpenseAverager.Forms;
using i_ExpenseAverager.Models;
using System.Xml.Linq;

namespace i_ExpenseAverager.Repositories
{
    public class ExpenseAverageXDB
    {
        private string dbPath;
        private string dbDir;

        private ExpenseAverageTypes expenceAverageTypes = new ExpenseAverageTypes();
        private ExpenseAverages expenceAverages = new ExpenseAverages();

        public ExpenseAverageXDB()
        {
            string dir = Directory.GetCurrentDirectory();
            dir = Path.Combine(dir, "AppData");
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            this.dbDir = string.Copy(dir);
            string filePath = Path.Combine(dir, "ExpenceAverageDB.expx");
            this.dbPath = string.Copy(filePath);
            bool exists = File.Exists(filePath);
            if (!File.Exists(filePath))
            {
                while (expenceAverageTypes.ToList().Count == 0)
                {
                    MessageBox.Show("Please Input a new expence average type.");
                    ExpenseTypeForm expenceAverageTypeForm = new ExpenseTypeForm(this);
                    expenceAverageTypeForm.ShowDialog();
                }
                SubmitChanges();
            }
            // TODO: load file if it exists and load the data while checking for errors.
            XElement doc = XElement.Load(this.dbPath);
            foreach (XElement item in doc.Descendants(ExpenseAverageType.TagName))
            {
                expenceAverageTypes.Add(new ExpenseAverageType(item));
            }
            foreach (XElement item in doc.Descendants(ExpenseAverage.TagName))
            {
                expenceAverages.Add(new ExpenseAverage(item));
            }
        }

        public ExpenseAverageType GetExpenceAverageType(int expenceAverageTypeID)
        {
            ExpenseAverageType expenceAverageType = expenceAverageTypes.Where(o => o.ExpenceAverageTypeID == expenceAverageTypeID).FirstOrDefault();
            return expenceAverageType;
        }

        public List<ExpenseAverage> GetExpenceAverageForExpenceAverageType(int expenceAverageTypeID)
        {
            List<ExpenseAverage> expenceAverage = expenceAverages.Where(o => o.ExpenceAverageTypeID.Equals(expenceAverageTypeID)).ToList();
            expenceAverage = expenceAverage.OrderBy(o => o.Date).ToList();
            return expenceAverage;
        }

        public ExpenseAverage GetCurrentExpenceAverageTypeLastExpenceAverage()
        {
            ExpenseAverageType expenceAverageType = GetCurrentExpenseAverageType();
            List<ExpenseAverage> expenceAverages = GetExpenceAverageForExpenceAverageType(expenceAverageType.ExpenceAverageTypeID);
            expenceAverages = expenceAverages.OrderBy(o => o.Date).ToList();
            ExpenseAverage last = null;
            if (expenceAverages.Count > 0)
            {
                last = expenceAverages[expenceAverages.Count - 1];
            }
            return last;
        }




        public bool CurrentExpenceAverageTypeSelected()
        {
            bool ret = false;
            ExpenseAverageType expenceAverageType = null;
            expenceAverageType = expenceAverageTypes.FirstOrDefault(o => o.CurrentExpenceAverageType);
            if (expenceAverageType == null)
            {
                MessageBox.Show("No current expence average type was found in the batabase." + Environment.NewLine + "Please input a new expence average type.", "No Expence Average Type Found", MessageBoxButtons.OK);
                ret = false;
            }
            if (expenceAverageType != null)
            {
                if (expenceAverageType.CurrentExpenceAverageType == true)
                {
                    ret = true;
                }
            }
            return ret;
        }

        public void SelectExpenceAverageType()
        {
            ExpenseTypeForm expenceAverageTypeForm = new ExpenseTypeForm(this);
            expenceAverageTypeForm.ShowDialog();
        }

        public void SaveCurrentExpenceAverageType(string expenceAverageTypeName, DateTime startDate)
        {
            expenceAverageTypeName = expenceAverageTypeName.Trim();
            ExpenseAverageType expenceAverageType = expenceAverageTypes.FirstOrDefault(o => o.ExpenseAverageTypeName.Equals(expenceAverageTypeName));
            if (expenceAverageType == null)
            {
                expenceAverageType = new ExpenseAverageType(expenceAverageTypeName, startDate);
                expenceAverageType.ExpenceAverageTypeID = expenceAverageTypes.ToList().Count + 1;
                expenceAverageType.CurrentExpenceAverageType = true;
                expenceAverageTypes.Add(expenceAverageType);
            }
            else
            {
                expenceAverageType.StartDate = startDate;
            }
            List<ExpenseAverageType> expenceAverageTypesList = expenceAverageTypes.ToList();
            ExpenseAverageType item;
            for (int i = 0; i < expenceAverageTypesList.Count; i++)
            {
                item = expenceAverageTypesList.ElementAt(i);
                item.CurrentExpenceAverageType = false;
            }
            expenceAverageType.CurrentExpenceAverageType = true;
            SubmitChanges();
        }

        public ExpenseAverageType GetCurrentExpenseAverageType()
        {
            ExpenseAverageType expenceAverageType = expenceAverageTypes.FirstOrDefault(o => o.CurrentExpenceAverageType);
            return expenceAverageType;
        }

        public List<ExpenseAverageType> GetExpenseAverageTypes()
        {
            return expenceAverageTypes.ToList();
        }

        public void SubmitChanges()
        {
            XElement doc = new XElement("expenceaveragedb");
            List<ExpenseAverageType> expenceAverageTypesList = expenceAverageTypes.ToList();
            foreach (ExpenseAverageType item in expenceAverageTypesList)
            {
                doc.Add(item.AsXML());
            }
            List<ExpenseAverage> expenceAveragesList = expenceAverages.ToList();
            foreach (ExpenseAverage item in expenceAveragesList)
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

        public bool SaveExpenceAverage(double amount, DateTime forDate, string note)
        {
            ExpenseAverageType expenceAverageType = GetCurrentExpenseAverageType();
            List<ExpenseAverage> expenceAveragesList = expenceAverages.ToList();
            ExpenseAverage expenceAverage = new ExpenseAverage(expenceAveragesList.Count + 1, expenceAverageType.ExpenceAverageTypeID, forDate, amount, note);
            expenceAverages.Add(expenceAverage);
            SubmitChanges();
            return true;
        }
    }
}
