using NUnit;
using Spendsmart.Models;


namespace SpendSmartTesting
{
    public class SpendSmartTests
    {
        // calling and setting up expenses for testing
        private Expense _Expense { get; set; } = null!;

        [SetUp]
        public void Setup()
        {
            // now setting that class into a new instance for testing
            // 3 things we can do in setup
            // 1. assign
            // 2. act
            // 3. assert
            _Expense = new Expense();

        }

        [Test]
        // changes name to class that you want to test
        public void Expense_test()
        {
            // assign
            var Value = 12;

            var Description = "test";

            var Date = "7/12/23";

            var Monthly = "yes";

            // Act
            _Expense.Value = Value;
            _Expense.Description = Description;
            _Expense.Date = Date;
            _Expense.Monthly = Monthly;

            // Assert
            Assert.AreEqual(Value, _Expense.Value);
            Assert.AreEqual(Description, _Expense.Description);
            Assert.AreEqual(Date, _Expense.Date);
            Assert.AreEqual(Monthly, _Expense.Monthly);


            Assert.Pass();
        }
    }
}