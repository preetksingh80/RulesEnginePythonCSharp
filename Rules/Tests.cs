using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using NUnit.Framework;
using Subject;

namespace Rules
{
    [TestFixture]
    public class Tests
    {
       

        [Test]
        public void Customer_who_is_over_30_should_not_be_eligible()
        {
            var customer = new Customer {Age = 35, Name = "XYZ", YearlyIncome = 15000m}; // create the customer
            var loanAmount = 1000m;
            var loanApplication = new LoanApplication(customer, loanAmount); // create a loan application
            var loanShark = new LoanShark();
            var engine = new RulesEngine(loanApplication, loanShark);
            Assert.IsFalse(engine.IsEligible());
        }


        [Test]
        public void Customer_who_is_under_30_should_be_eligible()
        {
            var customer = new Customer { Age = 20, Name = "XYZ", YearlyIncome = 15000m }; // create the customer
            var loanAmount = 1000m;
            var loanApplication = new LoanApplication(customer, loanAmount); // create a loan application
            var loanShark = new LoanShark();
            var engine = new RulesEngine(loanApplication, loanShark);
            Assert.IsTrue(engine.IsEligible());
        }
       
    }
}
