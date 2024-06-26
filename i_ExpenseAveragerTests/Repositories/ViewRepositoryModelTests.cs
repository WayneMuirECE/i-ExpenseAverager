using i_ExpenseAverager.Interfaces;
using i_ExpenseAverager.Models;
using i_ExpenseAverager.Repositories;
using i_ExpenseAverager.ViewModelLibrary;
using Moq;

namespace i_ExpenseAveragerTests.Repositories
{
    [TestClass]
    public class ViewRepositoryModelTests
    {
        private Mock<IExpenseAverageXDB> _mockXDB;
        private ViewRepositoryModel viewRepositoryModel;

        [TestInitialize]
        public void Initialize()
        {
            InitializeMocks();

            ExpenseTags expenseTypes = new ExpenseTags("type");
            expenseTypes.Add(new ExpenseTag("Gas"));

            _mockXDB.Setup(m => m.ExpenseTypes).Returns(expenseTypes);

            ExpenseTags expenseLocations = new ExpenseTags("loc");
            expenseLocations.Add(new ExpenseTag("Costco"));
            _mockXDB.Setup(m => m.ExpenseLocations).Returns(expenseLocations);

            ExpenseTags expenseOccasions = new ExpenseTags("occ");
            expenseOccasions.Add(new ExpenseTag("None"));
            _mockXDB.Setup(m => m.ExpenseOccasions).Returns(expenseOccasions);

            viewRepositoryModel = new ViewRepositoryModel(_mockXDB.Object);
        }

        private void InitializeMocks()
        {
            _mockXDB = new Mock<IExpenseAverageXDB>();
        }

        [TestMethod]
        public void RefreshCategoriesFromDB_ShouldContainExpenseTypesAllAndGas()
        {
            // Arrange
            // already done in Initialize()

            // Act
            viewRepositoryModel.RefreshCategoriesFromDB();

            // Assert
            Assert.AreEqual(2, viewRepositoryModel.CategoryList.Count);
            Assert.AreEqual("All", viewRepositoryModel.CategoryList[0].Name);
            Assert.AreEqual("Gas", viewRepositoryModel.CategoryList[1].Name);
        }

        [TestMethod]
        public void RefreshCategoriesFromDB_ShouldPopulateCategoryAll()
        {
            // Arrange
            // already done in Initialize()

            // Act
            viewRepositoryModel.RefreshCategoriesFromDB();

            // Assert
            Assert.IsNotNull(viewRepositoryModel.CategoryAll);
        }

        [TestMethod]
        public void RefreshDisplay_ShouldCalculateAveragesCorrectly()
        {
            // Arrange
            _mockXDB.Setup(m => m.StartDate).Returns(DateTime.Now.AddDays(-5));
            ExpenseAverages expenses = new ExpenseAverages();
            expenses.Add(new ExpenseAverage(1, 1, 1, 1, DateTime.Now.AddDays(-1), 15.24, ""));
            expenses.Add(new ExpenseAverage(1, 1, 1, 1, DateTime.Now.AddDays(-1), 15.24, ""));
            expenses.Add(new ExpenseAverage(1, 1, 1, 1, DateTime.Now.AddDays(-1), 15.24, ""));
            expenses.Add(new ExpenseAverage(1, 1, 1, 1, DateTime.Now.AddDays(-1), 15.24, ""));
            _mockXDB.Setup(m => m.ExpenseAverages).Returns(expenses);
           
            var viewRepositoryModel = new ViewRepositoryModel(_mockXDB.Object);
            var category = new CalendarAveragesGroup("TestCategory");
            category.Tags.Add(new ExpenseTag("Consumable", 1, "type"));
            category.Tags.Add(new ExpenseTag("Gasoline", 2, "type"));
            category.Tags.Add(new ExpenseTag("Medical", 3, "type"));

            // Act
            var result = viewRepositoryModel.RefreshDisplay(category);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("$10.16", category.DailyAvg);
            Assert.AreEqual("$71.12", category.MonthAvg);
        }

        [TestMethod]
        public void RefreshDisplay_ShouldCalculateAveragesCorrectlyOverOneWeek()
        {
            // Arrange
            _mockXDB.Setup(m => m.StartDate).Returns(DateTime.Now.AddDays(-7));
            ExpenseAverages expenses = new ExpenseAverages();
            expenses.Add(new ExpenseAverage(1, 1, 1, 1, DateTime.Now.AddDays(-1), 15.24, ""));
            expenses.Add(new ExpenseAverage(1, 1, 1, 1, DateTime.Now.AddDays(-1), 15.24, ""));
            expenses.Add(new ExpenseAverage(1, 1, 1, 1, DateTime.Now.AddDays(-1), 15.24, ""));
            expenses.Add(new ExpenseAverage(1, 1, 1, 1, DateTime.Now.AddDays(-1), 15.24, ""));
            _mockXDB.Setup(m => m.ExpenseAverages).Returns(expenses);

            var viewRepositoryModel = new ViewRepositoryModel(_mockXDB.Object);
            var category = new CalendarAveragesGroup("TestCategory");
            category.Tags.Add(new ExpenseTag("Consumable", 1, "type"));
            category.Tags.Add(new ExpenseTag("Gasoline", 2, "type"));
            category.Tags.Add(new ExpenseTag("Medical", 3, "type"));

            // Act
            var result = viewRepositoryModel.RefreshDisplay(category);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("$7.62", category.DailyAvg);
            Assert.AreEqual("$53.34", category.MonthAvg);
        }

        [TestMethod]
        public void RefreshDisplay_ShouldCalculateAveragesCorrectlyOverOneWeekWithDifferentDays()
        {
            // Arrange
            _mockXDB.Setup(m => m.StartDate).Returns(DateTime.Now.AddDays(-7));
            ExpenseAverages expenses = new ExpenseAverages();
            expenses.Add(new ExpenseAverage(1, 1, 1, 1, DateTime.Now.AddDays(-1), 15.24, ""));
            expenses.Add(new ExpenseAverage(1, 1, 1, 1, DateTime.Now.AddDays(-2), 15.24, ""));
            expenses.Add(new ExpenseAverage(1, 1, 1, 1, DateTime.Now.AddDays(-3), 15.24, ""));
            expenses.Add(new ExpenseAverage(1, 1, 1, 1, DateTime.Now.AddDays(-4), 15.24, ""));
            _mockXDB.Setup(m => m.ExpenseAverages).Returns(expenses);

            var viewRepositoryModel = new ViewRepositoryModel(_mockXDB.Object);
            var category = new CalendarAveragesGroup("TestCategory");
            category.Tags.Add(new ExpenseTag("Consumable", 1, "type"));
            category.Tags.Add(new ExpenseTag("Gasoline", 2, "type"));
            category.Tags.Add(new ExpenseTag("Medical", 3, "type"));

            // Act
            var result = viewRepositoryModel.RefreshDisplay(category);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("$7.62", category.DailyAvg);
            Assert.AreEqual("$53.34", category.MonthAvg);
        }
    }
}