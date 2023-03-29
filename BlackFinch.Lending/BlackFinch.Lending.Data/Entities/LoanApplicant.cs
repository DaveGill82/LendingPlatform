using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFinch.Lending.Data.Entities
{
    public class LoanApplicant
    {
        #region Public Properties

        /// <summary>
        /// Application ID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// The amount to borrow
        /// </summary>
        public decimal LoanAmount { get; set; }

        /// <summary>
        /// The asset value
        /// </summary>
        public decimal AssetValue { get; set; }

        /// <summary>
        /// The Loan to Value
        /// </summary>
        public decimal LoanToValue { get; set; }

        /// <summary>
        /// The applicants credit score
        /// </summary>
        public int CreditScore { get; set; }

        /// <summary>
        /// Is the application a success
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// The date of the application
        /// </summary>
        public DateTime DateRequested { get; set; }

        #endregion Public Properties

        #region Construction

        public LoanApplicant(decimal loanAmount, decimal assetValue, int creditScore)
        {
            this.ID = Guid.NewGuid().ToString();
            this.DateRequested = DateTime.Now;
            this.LoanAmount = loanAmount;
            this.AssetValue = assetValue;
            this.LoanToValue = (loanAmount / assetValue) * 100;
            this.CreditScore = creditScore;
        }

        #endregion Construction
    }
}
