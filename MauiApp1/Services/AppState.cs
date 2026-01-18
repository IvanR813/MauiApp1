using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Services
{
    public static class AppState
    {
        public static IAuthService AuthService { get; } = new MockAuthService();
        public static IWalletService WalletService { get; } = new MockWalletService();
        public static ITransactionService TransactionService { get; } = new MockTransactionService();

    }
}
