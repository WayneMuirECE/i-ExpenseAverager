using i_ExpenseAverager.Interfaces;
using Moq;

namespace i_ExpenseAveragerTests.Repositories
{
    [TestClass]
    public class UnitTest1
    {
        private Mock<IExpenseAverageXDB> _mockXDB;

        [TestInitialize]
        public void Initialize()
        {
            InitializeMocks();
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