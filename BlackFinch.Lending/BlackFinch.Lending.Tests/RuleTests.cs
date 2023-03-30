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

        [TestMethod]
        public void IsApplicationSuccess_Test1()
        {
            decimal loanAmount = 250000;
            decimal assetValue = 500000;
            int creditScore = 600;
            decimal loanToValue = (loanAmount / assetValue) * 100;

            var rulesHandler = new RulesHandler();

            Assert.IsFalse(rulesHandler.IsApplicationSuccess(loanAmount, assetValue, creditScore, loanToValue));
        }

        [TestMethod]
        public void IsApplicationSuccess_Test2()
        {
            decimal loanAmount = 250000;
            decimal assetValue = 500000;
            int creditScore = 800;
            decimal loanToValue = (loanAmount / assetValue) * 100;

            var rulesHandler = new RulesHandler();

            Assert.IsTrue(rulesHandler.IsApplicationSuccess(loanAmount, assetValue, creditScore, loanToValue));
        }

        [TestMethod]
        public void IsApplicationSuccess_Test3()
        {
            decimal loanAmount = 350000;
            decimal assetValue = 500000;
            int creditScore = 700;
            decimal loanToValue = (loanAmount / assetValue) * 100;

            var rulesHandler = new RulesHandler();

            Assert.IsFalse(rulesHandler.IsApplicationSuccess(loanAmount, assetValue, creditScore, loanToValue));
        }

        [TestMethod]
        public void IsApplicationSuccess_Test4()
        {
            decimal loanAmount = 350000;
            decimal assetValue = 500000;
            int creditScore = 900;
            decimal loanToValue = (loanAmount / assetValue) * 100;

            var rulesHandler = new RulesHandler();

            Assert.IsTrue(rulesHandler.IsApplicationSuccess(loanAmount, assetValue, creditScore, loanToValue));
        }

        [TestMethod]
        public void IsApplicationSuccess_Test5()
        {
            decimal loanAmount = 400000;
            decimal assetValue = 500000;
            int creditScore = 800;
            decimal loanToValue = (loanAmount / assetValue) * 100;

            var rulesHandler = new RulesHandler();

            Assert.IsFalse(rulesHandler.IsApplicationSuccess(loanAmount, assetValue, creditScore, loanToValue));
        }

        [TestMethod]
        public void IsApplicationSuccess_Test6()
        {
            decimal loanAmount = 400000;
            decimal assetValue = 500000;
            int creditScore = 999;
            decimal loanToValue = (loanAmount / assetValue) * 100;

            var rulesHandler = new RulesHandler();

            Assert.IsTrue(rulesHandler.IsApplicationSuccess(loanAmount, assetValue, creditScore, loanToValue));
        }

        [TestMethod]
        public void IsApplicationSuccess_Test7()
        {
            decimal loanAmount = 499999;
            decimal assetValue = 500000;
            int creditScore = 999;
            decimal loanToValue = (loanAmount / assetValue) * 100;

            var rulesHandler = new RulesHandler();

            Assert.IsFalse(rulesHandler.IsApplicationSuccess(loanAmount, assetValue, creditScore, loanToValue));
        }

        [TestMethod]
        public void IsApplicationSuccess_Test8()
        {
            decimal loanAmount = 1500000;
            decimal assetValue = 2000000;
            int creditScore = 999;
            decimal loanToValue = (loanAmount / assetValue) * 100;

            var rulesHandler = new RulesHandler();

            Assert.IsFalse(rulesHandler.IsApplicationSuccess(loanAmount, assetValue, creditScore, loanToValue));
        }

        [TestMethod]
        public void IsApplicationSuccess_Test9()
        {
            decimal loanAmount = 1500000;
            decimal assetValue = 3000000;
            int creditScore = 999;
            decimal loanToValue = (loanAmount / assetValue) * 100;

            var rulesHandler = new RulesHandler();

            Assert.IsTrue(rulesHandler.IsApplicationSuccess(loanAmount, assetValue, creditScore, loanToValue));
        }

        [TestMethod]
        public void IsApplicationSuccess_Test10()
        {
            decimal loanAmount = 1500000;
            decimal assetValue = 3000000;
            int creditScore = 800;
            decimal loanToValue = (loanAmount / assetValue) * 100;

            var rulesHandler = new RulesHandler();

            Assert.IsFalse(rulesHandler.IsApplicationSuccess(loanAmount, assetValue, creditScore, loanToValue));
        }

        [TestMethod]
        public void IsApplicationSuccess_Test11()
        {
            decimal loanAmount = 2000000;
            decimal assetValue = 3000000;
            int creditScore = 999;
            decimal loanToValue = (loanAmount / assetValue) * 100;

            var rulesHandler = new RulesHandler();

            Assert.IsFalse(rulesHandler.IsApplicationSuccess(loanAmount, assetValue, creditScore, loanToValue));
        }

        [TestMethod]
        public void IsApplicationSuccess_Test12()
        {
            decimal loanAmount = 1000;
            decimal assetValue = 2000;
            int creditScore = 999;
            decimal loanToValue = (loanAmount / assetValue) * 100;

            var rulesHandler = new RulesHandler();

            Assert.IsFalse(rulesHandler.IsApplicationSuccess(loanAmount, assetValue, creditScore, loanToValue));
        }
    }
}