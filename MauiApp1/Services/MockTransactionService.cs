using MauiApp1.Models;

namespace MauiApp1.Services
{
    public class MockTransactionService : ITransactionService
    {
        private List<Transaction> _transactions;

        public MockTransactionService()
        {
            _transactions = new List<Transaction>
            {
                new Transaction
                {
                    Id = Guid.NewGuid(),
                    Amount = -250.00m,
                    Date = DateTime.Now.AddDays(-2),
                    Description = "Canteen payment"
                },
                new Transaction
                {
                    Id = Guid.NewGuid(),
                    Amount = 5000.00m,
                    Date = DateTime.Now.AddDays(-5),
                    Description = "Initial wallet top-up"
                }
            };
        }

        public List<Transaction> GetTransactions()
        {
            return _transactions.OrderByDescending(t => t.Date).ToList();
        }

        public void AddTransaction(Transaction transaction)
        {
            if (transaction == null)
            {
                return;
            }

            if (transaction.Id == Guid.Empty)
            {
                transaction.Id = Guid.NewGuid();
            }

            if (transaction.Date == default(DateTime))
            {
                transaction.Date = DateTime.Now;
            }

            _transactions.Add(transaction);
        }
    }
}
