using BlackFinch.Lending.Data.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFinch.Lending.Data
{
    public interface IDataHelper
    {
        List<LoanApplicant> GetLoanApplicants();

        List<LoanApplicant> AddApplicant(LoanApplicant loanApplicant);
    }

    /// <summary>
    /// Access the database
    /// </summary>
    public class DataHelper : IDataHelper
    {
        #region Private Variables

        private readonly string _databaseName;

        #endregion Private Variables

        #region Construction

        public DataHelper()
        {
            _databaseName = Path.Join(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "LoanApplicantsDb.json");
        }

        #endregion Construction

        #region Public Methods

        public List<LoanApplicant> GetLoanApplicants()
        {
            return ReadApplicantsFromDB();
        }

        public List<LoanApplicant> AddApplicant(LoanApplicant loanApplicant)
        {
            var allApplicants = ReadApplicantsFromDB();

            allApplicants.Add(loanApplicant);

            WriteLoanApplicantsToDB(allApplicants);

            return allApplicants;
        }

        #endregion Public Methods

        #region Private Methods

        private List<LoanApplicant> ReadApplicantsFromDB()
        {
            List<LoanApplicant> loanApplicants = null;

            if (File.Exists(_databaseName))
            {
                string json = File.ReadAllText(_databaseName);

                loanApplicants = JsonConvert.DeserializeObject<List<LoanApplicant>>(json);
            }
            else
                loanApplicants = new List<LoanApplicant>();

            return loanApplicants;
        }
        private void WriteLoanApplicantsToDB(List<LoanApplicant> loanApplicants)
        {
            string json = JsonConvert.SerializeObject(loanApplicants, Formatting.Indented);

            File.WriteAllText(_databaseName, json);
        }

        #endregion Private Methods
    }
}
