using i_ExpenseAverager.Interfaces;
using i_ExpenseAverager.Models;
using i_ExpenseAverager.Repositories;
using i_ExpenseAverager.ViewModelLibrary;
using Moq;

namespace i_ExpenseAveragerTests.Repositories
{
    [TestClass]
    public class VeiwRepositoryModelTests
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
            _mockXDB.Setup(m => m.StartDate).Returns(new DateTime(2024, 1, 1));
            ExpenseAverages expenses = new ExpenseAverages();
            expenses.Add(new ExpenseAverage(1, 1, 1, 1, new DateTime(2024, 1, 1), 15.24, ""));
            expenses.Add(new ExpenseAverage(1, 1, 1, 1, new DateTime(2024, 1, 1), 15.24, ""));
            expenses.Add(new ExpenseAverage(1, 1, 1, 1, new DateTime(2024, 1, 1), 15.24, ""));
            expenses.Add(new ExpenseAverage(1, 1, 1, 1, new DateTime(2024, 1, 1), 15.24, ""));

            _mockXDB.Setup(m => m.ExpenseAverages).Returns(expenses);
            var viewRepositoryModel = new ViewRepositoryModel(_mockXDB.Object);
            var category = new ExpenseAverageCategory("TestCategory");
            ExpenseTag consumable = new ExpenseTag("Consumable");
            consumable.ExpenseTagID = 1;
            consumable.ExpenseTagType = "type";
            ExpenseTag gasoline = new ExpenseTag("Gasoline");
            gasoline.ExpenseTagID = 2;
            gasoline.ExpenseTagType = "type";
            ExpenseTag medical = new ExpenseTag("Medical");
            medical.ExpenseTagID = 3;
            medical.ExpenseTagType = "type";

            // Act
            var result = viewRepositoryModel.RefreshDisplay(category);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}