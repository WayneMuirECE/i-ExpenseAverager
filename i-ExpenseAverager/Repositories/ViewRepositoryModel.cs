﻿using i_ExpenseAverager.Interfaces;
using i_ExpenseAverager.Models;
using i_ExpenseAverager.ViewModelLibrary;

namespace i_ExpenseAverager.Repositories
{
    public class ViewRepositoryModel
    {
        public readonly int DaysFor12Month = 367;
        public readonly int DaysFor6Month = 183;
        public readonly int DaysFor3Month = 92;
        public readonly int DaysFor1Month = 31;

        private IExpenseAverageXDB _xDB;

        public CalendarAveragesGroup CategoryAll { get; private set; }
        public CalendarAveragesGroup LocationAll { get; private set; }
        public List<CalendarAveragesGroup> CategoryList { get; private set; }
        public List<CalendarAveragesGroup> LocationList { get; private set; }

        public ViewRepositoryModel(IExpenseAverageXDB XDB)
        {
            _xDB = XDB;

            RefreshCategoriesFromDB();
        }

        public void RefreshCategoriesFromDB()
        {
            CategoryAll = new CalendarAveragesGroup("All");

            foreach (ExpenseTag item in _xDB.ExpenseTypes.ToList())
            {
                CategoryAll.Tags.Add(item);
            }

            CategoryList = new List<CalendarAveragesGroup> { CategoryAll };

            CalendarAveragesGroup newCategory;

            foreach (ExpenseTag item in _xDB.ExpenseTypes.ToList())
            {
                newCategory = new CalendarAveragesGroup(item.ExpenseTagName);
                newCategory.Tags.Add(item);
                CategoryList.Add(newCategory);
            }
        }

        public void RefreshLocationsFromDB()
        {
            LocationAll = new CalendarAveragesGroup("All");

            foreach (ExpenseTag item in _xDB.ExpenseLocations.ToList())
            {
                LocationAll.Tags.Add(item);
            }

            LocationList = new List<CalendarAveragesGroup> { LocationAll };

            CalendarAveragesGroup newLocation;

            foreach (ExpenseTag item in _xDB.ExpenseLocations.ToList())
            {
                newLocation = new CalendarAveragesGroup(item.ExpenseTagName);
                newLocation.Tags.Add(item);
                LocationList.Add(newLocation);
            }
        }

        public ChainClass RefreshDisplay(CalendarAveragesGroup category)
        {
            ChainClass year = new ChainClass(1, DaysFor12Month);
            ChainClass sixMonth = new ChainClass(1, DaysFor6Month);
            ChainClass threeMonth = new ChainClass(1, DaysFor3Month);
            ChainClass oneMonth = new ChainClass(1, DaysFor1Month);

            DateTime varDate = DateTime.Today.AddDays(-DaysFor12Month);

            if (varDate < _xDB.StartDate)
            {
                varDate = _xDB.StartDate;
            }

            DateTime tomorrow = DateTime.Today.AddDays(1);
            List<ExpenseAverage> daysexpenses;
            ExpenseAverageDay expenseDay;

            while (varDate < tomorrow)
            {
                daysexpenses = _xDB.ExpenseAverages.ToListForDate(varDate, category.Tags);
                expenseDay = new ExpenseAverageDay(varDate);
                expenseDay.DaysExpenses = daysexpenses;
                year.ChainHead.AddNode(expenseDay);
                varDate = varDate.AddDays(1);
            }

            double average = CalculateAverage(year, sixMonth);
            double dailyAverage = average;
            category.YearAvg = "$" + average.ToString("0.00");

            average = CalculateAverage(sixMonth, threeMonth);

            dailyAverage += average;
            category.SixMonthAvg = "$" + average.ToString("0.00");

            average = CalculateAverage(threeMonth, oneMonth);
            dailyAverage += average;
            category.ThreeMonthAvg = "$" + average.ToString("0.00");

            average = CalculateAverage(oneMonth);
            dailyAverage += average;
            category.MonthAvg = "$" + average.ToString("0.00");

            dailyAverage = (dailyAverage / 4);
            category.TotalAvg = "$" + dailyAverage.ToString("0.00");
            dailyAverage = dailyAverage / 7;
            category.DailyAvg = "$" + dailyAverage.ToString("0.00");

            return year;
        }

        private double CalculateAverage(ChainClass from, ChainClass to = null)
        {
            double total = 0.0;

            foreach (ExpenseAverageDay item in from.ChainHead.GetNodes())
            {
                if (to != null)
                {
                    to.ChainHead.AddNode(item);
                }

                total += item.DaysTotal;
            }

            return (total / from.ChainHead.GetNodes().Count()) * 7;
        }
    }
}
