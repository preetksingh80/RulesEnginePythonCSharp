namespace Subject
{
    public class LoanApplication
    {
        public Customer Customer { get; private set; }

        public LoanApplication(Customer customer, decimal loanAmount)
        {
            Customer = customer;
            LoanAmount = loanAmount;
        }

        public decimal LoanAmount { get; private set; }
    }
}