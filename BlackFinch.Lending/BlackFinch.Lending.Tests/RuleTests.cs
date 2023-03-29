using BlackFinch.Lending.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlackFinch.Lending.Tests
{
    [TestClass]
    public class RuleTests
    {
        [TestMethod]
        public void Rule_IsBetweenLoanBoundaries_AboveUpper()
        {
            decimal loanAmount = 1600000;
            decimal assetValue = 5000000;
            int creditScore = 999;
            decimal loanToValue = (loanAmount / assetValue) * 100;

            var rulesHandler = new RulesHandler();

            Assert.IsFalse(rulesHandler.Rule_IsBetweenLoanBoundaries(loanAmount, assetValue, creditScore, loanToValue));
        }

        [TestMethod]
        public void IsApplicationSuccess_AboveUpper()
        {
            decimal loanAmount = 1600000;
            decimal assetValue = 5000000;
            int creditScore = 999;
            decimal loanToValue = (loanAmount / assetValue) * 100;

            var rulesHandler = new RulesHandler();

            Assert.IsFalse(rulesHandler.IsApplicationSuccess(loanAmount, assetValue, creditScore, loanToValue));
        }
    }
}