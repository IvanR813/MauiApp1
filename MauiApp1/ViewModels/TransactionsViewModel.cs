using MauiApp1.Models;
using MauiApp1.Services;
using System.Collections.ObjectModel;

namespace MauiApp1.ViewModels
{
    public class TransactionsViewModel : BaseViewModel
    {
        private readonly ITransactionService _transactionService;
        private ObservableCollection<Transaction> _transactions;

        public TransactionsViewModel()
        {
            _transactionService = new MockTransactionService();
            Transactions = new ObservableCollection<Transaction>();
            LoadTransactions();
        }

        public ObservableCollection<Transaction> Transactions
        {
            get => _transactions;
            set => SetProperty(ref _transactions, value);
        }

        private void LoadTransactions()
        {
            var transactionList = _transactionService.GetTransactions();
            Transactions = new ObservableCollection<Transaction>(transactionList);
        }
    }
}
