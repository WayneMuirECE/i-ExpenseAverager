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
            var mockXDB = new Mock<IExpenseAverageXDB>();
            var viewRepositoryModel = new ViewRepositoryModel(mockXDB.Object);
            var category = new ExpenseAverageCategory("TestCategory");
            // TODO: setup the tags for the category, the start date in the XDB, and the ExpenseAverages for the category and date

            // Act
            var result = viewRepositoryModel.RefreshDisplay(category);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}