using MauiApp1.Models;

namespace MauiApp1.Services
{
    public class MockWalletService : IWalletService
    {
        private Wallet _wallet;

        public MockWalletService()
        {
            _wallet = new Wallet
            {
                Balance = 5000
            };
        }

        public decimal GetBalance()
        {
            return _wallet.Balance;
        }

        public void TopUp(decimal amount)
        {
            _wallet.Balance += amount;
        }

        public bool Pay(decimal amount)
        {
            if (_wallet.Balance < amount)
            {
                return false;
            }
            _wallet.Balance -= amount;
            return true;
        }
    }
}
