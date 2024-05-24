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

            ExpenseTags expenseTags = new ExpenseTags("type");
            expenseTags.Add(new ExpenseTag("Gas"));

            _mockXDB.Setup(m => m.ExpenseTypes).Returns(expenseTags);

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
            ExpenseTag consumable = new ExpenseTag("Consumable");
            consumable.ExpenseTagID = 1;
            consumable.ExpenseTagType = "type";
            category.Tags.Add(consumable);
            ExpenseTag gasoline = new ExpenseTag("Gasoline");
            gasoline.ExpenseTagID = 2;
            gasoline.ExpenseTagType = "type";
            category.Tags.Add(gasoline);
            ExpenseTag medical = new ExpenseTag("Medical");
            medical.ExpenseTagID = 3;
            medical.ExpenseTagType = "type";
            category.Tags.Add(medical);

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
            ExpenseTag consumable = new ExpenseTag("Consumable");
            consumable.ExpenseTagID = 1;
            consumable.ExpenseTagType = "type";
            category.Tags.Add(consumable);
            ExpenseTag gasoline = new ExpenseTag("Gasoline");
            gasoline.ExpenseTagID = 2;
            gasoline.ExpenseTagType = "type";
            category.Tags.Add(gasoline);
            ExpenseTag medical = new ExpenseTag("Medical");
            medical.ExpenseTagID = 3;
            medical.ExpenseTagType = "type";
            category.Tags.Add(medical);

            // Act
            var result = viewRepositoryModel.RefreshDisplay(category);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("$7.62", category.DailyAvg);
            Assert.AreEqual("$53.34", category.MonthAvg);
        }
    }
}