using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subject
{
    public class LoanShark
    {
        /// <summary>
        /// We should now be able to load the rules for this object from memory
        /// </summary>
        public List<string> EligibilityRules { get; private set; }

        public LoanShark()
        {
            EligibilityRules = new List<string>
            {
                "loanApplication.LoanAmount > 0",
                "loanApplication.Customer.Age < 30",
                "loanApplication.Customer.Name",
                "loanApplication.LoanAmount < loanApplication.Customer.YearlyIncome"

            };
        }
    }
}
