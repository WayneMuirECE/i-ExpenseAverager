using i_ExpenseAverager.Models;
using i_ExpenseAverager.ViewModelLibrary;

namespace i_ExpenseAverager.Repositories
{
    public class ExpenseAverageViewXDB
    {
        private ExpenseAverage2XDB XDB;
        public readonly int daysFor12Month = 367;
        public readonly int daysFor6Month = 183;
        public readonly int daysFor3Month = 92;
        public readonly int daysFor1Month = 31;

        private ExpenseAverageCategory all;

        public ExpenseAverageCategory CategoryAll
        {
            get { return all; }
            private set { all = value; }
        }

        public List<ExpenseAverageCategory> categoryList;

        public ExpenseAverageViewXDB(ExpenseAverage2XDB XDB)
        {
            this.XDB = XDB;
            this.all = new ExpenseAverageCategory("All");
            foreach (ExpenseTag item in this.XDB.ExpenseTypes.ToList())
            {
                all.Tags.Add(item);
            }
            categoryList = new List<ExpenseAverageCategory>();
            this.categoryList.Add(all);
        }


        public ChainClass RefreshDisplay(ExpenseAverageCategory category)
        {
            double total = 0.0;

            ChainClass year = new ChainClass(1, daysFor12Month);
            ChainClass sixMonth = new ChainClass(1, daysFor6Month);
            ChainClass threeMonth = new ChainClass(1, daysFor3Month);
            ChainClass oneMonth = new ChainClass(1, daysFor1Month);

            DateTime varDate = DateTime.Today.AddDays(-daysFor12Month);
            if (varDate < XDB.StartDate)
            {
                varDate = XDB.StartDate;
            }

            DateTime tomorrow = DateTime.Today.AddDays(1);
            List<ExpenseAverage2> daysexpenses;
            ExpenseAverageDay expenseDay;
            while (varDate < tomorrow)
            {
                daysexpenses = XDB.ExpenseAverages.ToListForDate(varDate, category.Tags);
                expenseDay = new ExpenseAverageDay(varDate);
                expenseDay.DaysExpenses = daysexpenses;
                year.ChainHead.AddNode(expenseDay);
                varDate = varDate.AddDays(1);
            }

            total = 0.0;
            foreach (ExpenseAverageDay item in year.ChainHead.GetNodes())
            {
                sixMonth.ChainHead.AddNode(item);
                total += item.DaysTotal;
            }
            double average = (total / (double)year.ChainHead.GetNodes().Count()) * 7;
            double dailyAverage = average;
            category.YearAvg = "$" + average.ToString("0.00");
            total = 0.0;
            foreach (ExpenseAverageDay item in sixMonth.ChainHead.GetNodes())
            {
                threeMonth.ChainHead.AddNode(item);
                total += item.DaysTotal;
            }
            average = (total / (double)sixMonth.ChainHead.GetNodes().Count()) * 7;
            dailyAverage += average;
            category.SixMonthAvg = "$" + average.ToString("0.00");
            total = 0.0;
            foreach (ExpenseAverageDay item in threeMonth.ChainHead.GetNodes())
            {
                oneMonth.ChainHead.AddNode(item);
                total += item.DaysTotal;
            }
            average = (total / (double)threeMonth.ChainHead.GetNodes().Count()) * 7;
            dailyAverage += average;
            category.ThreeMonthAvg = "$" + average.ToString("0.00");

            total = 0.0;
            foreach (ExpenseAverageDay item in oneMonth.ChainHead.GetNodes())
            {
                total += item.DaysTotal;
            }
            average = (total / (double)oneMonth.ChainHead.GetNodes().Count()) * 7;
            dailyAverage += average;
            category.MonthAvg = "$" + average.ToString("0.00");

            dailyAverage = (dailyAverage / 4);
            category.TotalAvg = "$" + dailyAverage.ToString("0.00");
            dailyAverage = dailyAverage / 7;
            category.DailyAvg = "$" + dailyAverage.ToString("0.00");

            return year;
        }
    }
}
