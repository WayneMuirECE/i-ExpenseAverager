using i_ExpenceAverager.Models;
using System.Xml.Linq;

namespace i_ExpenceAverager.Repositories
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

        public ExpenseTags expenceTypes = new ExpenseTags("type");
        public ExpenseTags expenceLocations = new ExpenseTags("loc");
        public ExpenseTags expenceOccasions = new ExpenseTags("occ");
        public ExpenceAverages2 expenceAverages = new ExpenceAverages2();

        private ExpenseTag currentExpenceAverageType;

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
            string filePath = Path.Combine(dir, "ExpenceAverage2DB.xdb");
            this.dbPath = string.Copy(filePath);
            bool exists = File.Exists(filePath);
            if (!File.Exists(filePath))
            {
                //while (expenceTypes.ToList().Count == 0) {
                //	MessageBox.Show("Please Input a new expence average type.");
                //	//ExpenceAverageTypeForm expenceAverageTypeForm = new ExpenceAverageTypeForm(this);
                //	//expenceAverageTypeForm.ShowDialog();
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
                    expenceTypes.Add(tag);
                }
                else if (tag.ExpenseTagType.Equals("loc"))
                {
                    expenceLocations.Add(tag);
                }
                else if (tag.ExpenseTagType.Equals("occ"))
                {
                    expenceOccasions.Add(tag);
                }
            }
            foreach (XElement item in doc.Descendants(ExpenseAverage2.TagName))
            {
                expenceAverages.Add(new ExpenseAverage2(item));
            }
        }

        public ExpenseTag GetExpenceAverageType(int expenceAverageTypeID)
        {
            ExpenseTag value = expenceTypes.ItemById(expenceAverageTypeID);
            return value;
        }

        public ExpenseTag GetExpenceAverageType(string expenceAverageType)
        {
            ExpenseTag value = expenceTypes.ItemByName(expenceAverageType);
            return value;
        }

        public ExpenseTag GetExpenceLocation(int expenceLocationID)
        {
            ExpenseTag value = expenceLocations.ItemById(expenceLocationID);
            return value;
        }

        public ExpenseTag GetExpenceLocation(string expenceLocation)
        {
            ExpenseTag value = expenceLocations.ItemByName(expenceLocation);
            return value;
        }

        public ExpenseTag GetExpenceOccasion(int expenceOccasionID)
        {
            ExpenseTag value = expenceOccasions.ItemById(expenceOccasionID);
            return value;
        }

        public ExpenseTag GetExpenceOccasion(string expenceOccasion)
        {
            ExpenseTag value = expenceOccasions.ItemByName(expenceOccasion);
            return value;
        }

        public void SaveExpenceAverageType(string expenceAverageTypeName)
        {
            expenceAverageTypeName = expenceAverageTypeName.Trim();
            ExpenseTag value = expenceTypes.ItemByName(expenceAverageTypeName);
            if (value == null)
            {
                expenceTypes.Add(expenceAverageTypeName);
            }

            SubmitChanges();
        }
        public void SaveExpenceLocation(string expenceLocationName)
        {
            expenceLocationName = expenceLocationName.Trim();
            ExpenseTag value = expenceLocations.ItemByName(expenceLocationName);
            if (value == null)
            {
                expenceLocations.Add(expenceLocationName);
            }

            SubmitChanges();
        }

        public void SaveExpenceOccasion(string expenceOccasionName)
        {
            expenceOccasionName = expenceOccasionName.Trim();
            ExpenseTag value = expenceOccasions.ItemByName(expenceOccasionName);
            if (value == null)
            {
                expenceOccasions.Add(expenceOccasionName);
            }

            SubmitChanges();
        }

        public bool SaveExpenceAverage(string type, string location, string occasion, DateTime forDate, double amount, string note)
        {
            ExpenseTag expenceType = GetExpenceAverageType(type);
            ExpenseTag expenceLocation = GetExpenceLocation(location);
            ExpenseTag expenceOccasion = GetExpenceOccasion(occasion);
            List<ExpenseAverage2> expenceAveragesList = expenceAverages.ToList();
            ExpenseAverage2 expenceAverage = new ExpenseAverage2(expenceAveragesList.Count + 1, expenceType.ExpenseTagID, expenceLocation.ExpenseTagID, expenceOccasion.ExpenseTagID, forDate, amount, note);
            expenceAverages.Add(expenceAverage);
            SubmitChanges();
            return true;
        }

        public bool DeleteExpenceAverage(ExpenseAverage2 expence)
        {
            expenceAverages.Remove(expence);
            return true;
        }








        public List<ExpenseAverage2> GetExpenceAverageForExpenceAverageType(int expenceAverageTypeID)
        {
            List<ExpenseAverage2> expenceAverage = expenceAverages.Where(o => o.ExpenceAverageTypeID.Equals(expenceAverageTypeID)).ToList();
            expenceAverage = expenceAverage.OrderBy(o => o.Date).ToList();
            return expenceAverage;
        }

        public ExpenseAverage2 GetCurrentExpenceAverageTypeLastExpenceAverage()
        {
            ExpenseTag expenceAverageType = GetCurrentExpenceAverageType();
            List<ExpenseAverage2> expenceAverages = GetExpenceAverageForExpenceAverageType(expenceAverageType.ExpenseTagID);
            expenceAverages = expenceAverages.OrderBy(o => o.Date).ToList();
            ExpenseAverage2 last = null;
            if (expenceAverages.Count > 0)
            {
                last = expenceAverages[expenceAverages.Count - 1];
            }
            return last;
        }




        public bool CurrentExpenceAverageTypeSelected()
        {
            bool ret = false;
            ExpenseTag expenceAverageType = null;
            expenceAverageType = this.currentExpenceAverageType;
            if (expenceAverageType == null)
            {
                MessageBox.Show("No current expence average type was found in the batabase." + Environment.NewLine + "Please input a new expence average type.", "No Expence Average Type Found", MessageBoxButtons.OK);
                ret = false;
            }
            if (expenceAverageType != null)
            {
                ret = true;
            }
            return ret;
        }

        public void SelectExpenceAverageType()
        {
            //ExpenceAverageTypeForm expenceAverageTypeForm = new ExpenceAverageTypeForm(this);
            //expenceAverageTypeForm.ShowDialog();
        }

        public void SaveCurrentExpenceAverageType(string expenceAverageTypeName)
        {
            expenceAverageTypeName = expenceAverageTypeName.Trim();
            ExpenseTag expenceAverageType = expenceTypes.FirstOrDefault(o => o.ExpenseTagName.Equals(expenceAverageTypeName));
            if (expenceAverageType == null)
            {
                //expenceAverageType = new ExpenceLocation(expenceAverageTypeName, startDate);
                expenceAverageType.ExpenseTagID = expenceTypes.ToList().Count + 1;
                expenceTypes.Add(expenceAverageType);
            }
            else
            {
                //expenceAverageType.StartDate = startDate;
            }
            this.currentExpenceAverageType = expenceAverageType;
            SubmitChanges();
        }

        public ExpenseTag GetCurrentExpenceAverageType()
        {
            ExpenseTag expenceAverageType = this.currentExpenceAverageType;
            return expenceAverageType;
        }

        public List<ExpenseTag> GetExpenceAverageTypes()
        {
            return expenceTypes.ToList();
        }

        public void SubmitChanges()
        {
            XElement doc = new XElement("expenceaveragedb");

            doc.Add(new XElement("accountname", this.accountName));
            doc.Add(new XElement("startdate", this.startDate.ToShortDateString()));

            List<ExpenseTag> expenceAverageTypesList = expenceTypes.ToList();
            foreach (ExpenseTag item in expenceAverageTypesList)
            {
                doc.Add(item.AsXML());
            }

            List<ExpenseTag> expenceLocationsList = expenceLocations.ToList();
            foreach (ExpenseTag item in expenceLocationsList)
            {
                doc.Add(item.AsXML());
            }

            List<ExpenseTag> expenceOccasionsList = expenceOccasions.ToList();
            foreach (ExpenseTag item in expenceOccasionsList)
            {
                doc.Add(item.AsXML());
            }

            List<ExpenseAverage2> expenceAveragesList = expenceAverages.ToListByDate();
            int i = 0;
            foreach (ExpenseAverage2 item in expenceAveragesList)
            {
                i++;
                item.ExpenceAverageID = i;
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
