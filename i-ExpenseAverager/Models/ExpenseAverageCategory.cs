namespace i_ExpenseAverager.Models
{
    public class ExpenseAverageCategory
    {
        public string Name { get; set; }
        public List<ExpenseTag> Tags { get; } = new List<ExpenseTag>();
        public string YearAvg { get; set; }
        public string SixMonthAvg { get; set; }
        public string ThreeMonthAvg { get; set; }
        public string MonthAvg { get; set; }
        public string DailyAvg { get; set; }
        public string TotalAvg { get; set; }

        public ExpenseAverageCategory(string name)
        {
            Name = name;
        }

        public override string ToString() => Name;
    }

}
