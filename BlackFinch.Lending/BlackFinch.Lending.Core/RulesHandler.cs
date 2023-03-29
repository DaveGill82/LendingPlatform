namespace BlackFinch.Lending.Core
{
    public interface IRulesHandler
    {
        bool IsApplicationSuccess(decimal loanAmount, decimal assetValue, int creditScore, decimal loanToValue);
    }

    /// <summary>
    /// Test loan applications agaisnt rules
    /// </summary>
    public class RulesHandler : IRulesHandler
    {
        #region Private Variables

        private delegate bool RulesTestDelegate(decimal loanAmount, decimal assetValue, int creditScore, decimal loanToValue);

        private RulesTestDelegate Rules = null;

        #endregion Private Variables

        #region Construction

        public RulesHandler()
        {
            // Add new rule functions to the delegate to be used for testing
            this.Rules += Rule_IsBetweenLoanBoundaries;
            this.Rules += Rule_LoanToValue1;
            this.Rules += Rule_LoanToValue2;
            this.Rules += Rule_LoanToValue3;
            this.Rules += Rule_LoanToValue4;
            this.Rules += Rule_LoanToValue5;
        }

        #endregion Construction

        #region Public Methods

        /// <summary>
        /// Test whether the a application is a success
        /// </summary>
        /// <param name="loanAmount">The loan amount</param>
        /// <param name="assetValue">The value of the asset</param>
        /// <param name="creditScore">The applicants credit score</param>
        /// <param name="loanToValue">The calculated Loan to Value ratio</param>
        /// <returns></returns>
        public bool IsApplicationSuccess(decimal loanAmount, decimal assetValue, int creditScore, decimal loanToValue)
        {
            bool ret = true;

            foreach (RulesTestDelegate fun in this.Rules.GetInvocationList())
            {
                if (false == fun(loanAmount, assetValue, creditScore, loanToValue))
                {
                    ret = false;
                    break;
                }    
            }

            return ret;
        }

        public bool Rule_IsBetweenLoanBoundaries(decimal loanAmount, decimal assetValue, int creditScore, decimal loanToValue)
        {
            bool ret = true;

            if (loanAmount > 1500000 || loanAmount < 100000)
                ret = false;

            return ret;
        }

        public bool Rule_LoanToValue1(decimal loanAmount, decimal assetValue, int creditScore, decimal loanToValue)
        {
            bool ret = true;

            if (loanAmount >= 1000000)
            {
                if (loanToValue > 60 && creditScore < 950)
                {
                    ret = false;
                }
            }

            return ret;
        }

        public bool Rule_LoanToValue2(decimal loanAmount, decimal assetValue, int creditScore, decimal loanToValue)
        {
            bool ret = true;

            if (loanAmount < 1000000)
            {
                if (loanToValue < 60 && creditScore < 750)
                {
                    ret = false;
                }
            }

            return ret;
        }

        public bool Rule_LoanToValue3(decimal loanAmount, decimal assetValue, int creditScore, decimal loanToValue)
        {
            bool ret = true;

            if (loanAmount < 1000000)
            {
                if (loanToValue < 80 && creditScore < 800)
                {
                    ret = false;
                }
            }

            return ret;
        }

        public bool Rule_LoanToValue4(decimal loanAmount, decimal assetValue, int creditScore, decimal loanToValue)
        {
            bool ret = true;

            if (loanAmount < 1000000)
            {
                if (loanToValue < 90 && creditScore < 900)
                {
                    ret = false;
                }
            }

            return ret;
        }

        public bool Rule_LoanToValue5(decimal loanAmount, decimal assetValue, int creditScore, decimal loanToValue)
        {
            bool ret = true;

            if (loanAmount < 1000000)
            {
                if (loanToValue >= 90)
                {
                    ret = false;
                }
            }

            return ret;
        }

        #endregion Public Methods
    }
}