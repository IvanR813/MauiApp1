using MauiApp1.Models;

namespace MauiApp1.Services
{
    public interface ITransactionService
    {
        List<Transaction> GetTransactions();
        void AddTransaction(Transaction transaction);
    }
}
