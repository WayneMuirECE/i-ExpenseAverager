using i_ExpenseAverager.Interfaces;
using i_ExpenseAverager.Models;
using i_ExpenseAverager.Repositories;
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
        public void TestMethod1()
        {
        }
    }
}